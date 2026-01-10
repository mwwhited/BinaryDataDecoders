using Microsoft.Extensions.Logging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using ILogger = NuGet.Common.ILogger;

namespace BinaryDataDecoders.PackMan.Cli;

public class NugetManager(
    ILogger nugetLogger,
    ILogger<NugetManager> logger) : INugetManager
{
    public IEnumerable<(string name, string? version)> SplitVersions(string? inputVersions)
    {
        if (string.IsNullOrWhiteSpace(inputVersions))
            yield break;

        foreach (var targetVersion in inputVersions.Split(';'))
        {
            var parts = targetVersion.Split([','], 2);
            if (string.IsNullOrWhiteSpace(parts[0]))
                continue;

            yield return (parts[0].Trim(), parts.ElementAtOrDefault(1)?.Trim());
        }
    }

    public XDocument OpenXml(string versionPropsFile, bool withImport = false)
    {
        if (!File.Exists(versionPropsFile))
        {
            return new XDocument(
                new XElement("Project")
                );
        }

        var xml = XDocument.Load(versionPropsFile, LoadOptions.PreserveWhitespace);

        if (withImport)
        {
            var imports = xml.Descendants("Import").ToArray();
            var directory = Path.GetDirectoryName(versionPropsFile);
            foreach (var import in imports)
            {
                var importFile = (string)import.Attribute("Project");
                var importPath = Path.GetFullPath(Path.Combine(directory ?? ".", importFile));
                var imported = OpenXml(importPath, withImport);
                import.ReplaceWith(imported.Root.Nodes());
            }
        }

        return xml;
    }

    public void UpdateTargetVersions(XDocument xDocument, IEnumerable<(string name, string? version)> properties)
    {
        var propertyGroups = xDocument.Descendants("PropertyGroup");
        foreach (var property in properties)
        {
            var propertyVersion = propertyGroups.Descendants(property.name);
            foreach (var x in propertyVersion)
            {
                logger.LogInformation($@"Set ""{{{nameof(property.name)}}}"" to ""{{{nameof(property.version)}}}""", property.name, property.version);
                x.Value = property.version ?? "";
            }
        }
    }

    public async Task UpdateNugetVersionsAsync(XDocument versionXml, string nugetUrl, FeedType feedType, CancellationToken cancellationToken)
    {
        var packages = from packageVersion in versionXml.Descendants("PackageVersion")
                       let condition = packageVersion.Parent.Attribute("Condition")
                       select (packageVersion, condition);

        var cache = new SourceCacheContext();
        var repository = Repository.Factory.GetCoreV3(nugetUrl, feedType);
        var resource = await repository.GetResourceAsync<FindPackageByIdResource>();

        foreach (var package in packages)
        {
            if (cancellationToken.IsCancellationRequested)
                break;

            var packageName = (string?)package.packageVersion.Attribute("Include");
            var versionAttribute = package.packageVersion.Attribute("Version");
            var version = (string?)versionAttribute;
            if (!NuGetVersion.TryParse(version, out var current))
            {
                // _logger.LogInformation($"Found version {packageName}: {version} => Not Supported");
                continue;
            }

            var lockedVersion = ((bool?)package.packageVersion.Element("_LockVersion")) ?? false;
            if (lockedVersion)
            {
                logger.LogInformation($"Skip version check {{{nameof(packageName)}}}: {{{nameof(version)}}} => SKIPPED", packageName, version);
                continue;
            }

            var versions = await resource.GetAllVersionsAsync(
                packageName,
                cache,
                nugetLogger,
                cancellationToken);

            var condition = (string)package.condition;

            if (string.IsNullOrEmpty(condition))
            {
                var target = versions.Reverse().Where(v => !v.IsPrerelease).FirstOrDefault();

                if (target != null && target != current)
                {
                    versionAttribute.Value = target.ToString();
                    logger.LogInformation($"Found upgrade version {{{nameof(packageName)}}}: {{{nameof(version)}}} => {{{nameof(target)}}}", packageName, version, target);
                    if (target.IsLegacyVersion)
                        logger.LogInformation($"{{{nameof(packageName)}}}: {{{nameof(version)}}} is legacy, update soon", packageName, version);
                }
                else if (current.IsLegacyVersion)
                {
                    logger.LogInformation($"Already up to date {{{nameof(packageName)}}}: {{{nameof(version)}}}", packageName, version);
                    logger.LogInformation($"{{{nameof(packageName)}}}: {{{nameof(version)}}} is legacy, update soon", packageName, version);
                }
            }
            else
            {
                var targets = from v in versions.Reverse()
                              where current.IsPrerelease || !v.IsPrerelease
                              where current.Major == v.Major
                              select v;
                var target = targets.FirstOrDefault();

                if (target != null && target != current)
                {
                    versionAttribute.Value = target.ToString();
                    logger.LogInformation($"Found upgrade version {{{nameof(packageName)}}}: {{{nameof(version)}}} => {{{nameof(target)}}}", packageName, version, target);
                    if (target.IsLegacyVersion)
                        logger.LogInformation($"{{{nameof(packageName)}}}: {{{nameof(version)}}} is legacy, update soon", packageName, version);
                }
                else if (current.IsLegacyVersion)
                {
                    logger.LogInformation($"Already up to date {{{nameof(packageName)}}}: {{{nameof(version)}}}", packageName, version);
                    logger.LogInformation($"{{{nameof(packageName)}}}: {{{nameof(version)}}} is legacy, update soon", packageName, version);
                }
            }

            // https://devblogs.microsoft.com/nuget/how-to-scan-nuget-packages-for-security-vulnerabilities/

            //if (versions.FirstOrDefault(i => i == current)?.IsLegacyVersion?? false)
            //{
            //    Console.WriteLine($"IS LEGACY: {packageName}");
            //}
            //if (versions.FirstOrDefault(i => i == current)?.IsPrerelease ?? false)
            //{
            //    Console.WriteLine($"IS PRERELEASE: {packageName}");
            //}

            //var checkLegacy = versions.FirstOrDefault(i => i == current)?.IsLegacyVersion;
            //Console.WriteLine($@"\t==> This is a {(checkLegacy switch
            //{
            //    null => "Unknown",
            //    true => "Legacy",
            //    false => "Current"
            //})} Package {packageName}: {version}");
        }
    }

    public void Save(XDocument versionXml, string filePath)
    {
        var fullPath = Path.GetFullPath(filePath);
        var dir = Path.GetDirectoryName(fullPath);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        versionXml.Save(filePath);
        logger.LogInformation($"Saved content to {{{nameof(filePath)}}}", filePath);
    }

    public IEnumerable<(string propertyName, string value)> GetProperties(XDocument versionXml)
    {
        var propertyXml = versionXml.Descendants("PropertyGroup").SelectMany(x => x.Elements());

        var query = from x in propertyXml
                    where !string.IsNullOrWhiteSpace(x.Value)
                    group x.Value by x.Name.LocalName into item
                    select (item.Key, item.FirstOrDefault());

        return query;
    }
}
