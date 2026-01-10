using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using ILogger = NuGet.Common.ILogger;

namespace BinaryDataDecoders.PackMan.Cli;

internal class Program
{
    static async Task Main(string[] args)
    {


        var services = new ServiceCollection()
            .AddApplicationServices(args)
            .AddCommandLineOption<CommandLineOptions>()
            ;

        services.TryAddTransient<INugetManager, NugetManager>();
        services.TryAddTransient<ILogger, NugetLoggerBridge>();

        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<INugetManager>();

        // https://docs.microsoft.com/en-us/nuget/reference/nuget-client-sdkhttps://docs.microsoft.com/en-us/nuget/reference/nuget-client-sdk
        // https://gist.github.com/cpyfferoen/74092a74b165e85aed5ca1d51973b9d2
        // https://stackoverflow.com/questions/60885348/nuget-client-sdk-connecting-to-a-private-nuget-feed-through-code

        try
        {
            var cmdLine = serviceProvider.GetRequiredService<CommandLineOptions>();

            if (cmdLine.GetVersion)
            {
                //TODO: fix this !
                // Console.WriteLine($"{GitVersionInformation.FullSemVer}");
                throw new NotSupportedException();
            }

            var versionXml = service.OpenXml(cmdLine.SourceFile, followImports: cmdLine.FollowImports);

            if (!string.IsNullOrWhiteSpace(cmdLine.GetProperty))
            {
                var value = service.GetProperties(versionXml)
                                   .Where(p => string.Equals(p.propertyName, cmdLine.GetProperty, StringComparison.InvariantCultureIgnoreCase))
                                   .Select(p => p.value)
                                   .FirstOrDefault();
                Console.WriteLine($"{value}");
                return;
            }
#if DEBUG
            Console.WriteLine($"{nameof(cmdLine.OutputFile)}={cmdLine.OutputFile}");
            Console.WriteLine($"{nameof(cmdLine.SourceFile)}={cmdLine.SourceFile}");
            Console.WriteLine($"{nameof(cmdLine.NoNuget)}={cmdLine.NoNuget}");
            Console.WriteLine($"{nameof(cmdLine.NoSave)}={cmdLine.NoSave}");
            Console.WriteLine($"{nameof(cmdLine.TargetVersions)}={cmdLine.TargetVersions}");
            Console.WriteLine($"{nameof(cmdLine.NugetUrl)}={cmdLine.NugetUrl}");
            Console.WriteLine($"{nameof(cmdLine.FeedType)}={cmdLine.FeedType}");
            Console.WriteLine($"{nameof(cmdLine.GetProperties)}={cmdLine.GetProperties}");
            Console.WriteLine($"{nameof(cmdLine.FollowImports)}={cmdLine.FollowImports}");
            Console.WriteLine($"{nameof(cmdLine.UpdateProjects)}={cmdLine.UpdateProjects}");
            Console.WriteLine($"{nameof(cmdLine.Projects)}={cmdLine.Projects}");
#endif

            service.UpdateTargetVersions(versionXml, service.SplitVersions(cmdLine.TargetVersions));

            if (cmdLine.UpdateProjects)
            {
                var matcher = new Matcher(StringComparison.InvariantCultureIgnoreCase);

                var pathProjectPath = string.IsNullOrWhiteSpace(cmdLine.ProjectsPath) ? Environment.CurrentDirectory : cmdLine.ProjectsPath;

                var patterns = cmdLine.Projects?.Split(';');
                if (patterns != null)
                {
                    foreach (var pattern in patterns)
                    {
                        if (pattern.StartsWith('!'))
                        {
                            matcher.AddExclude(pattern[1..]);
                        }
                        else
                        {
                            matcher.AddInclude(pattern);
                        }
                    }
                }

                var projects = matcher.GetResultsInFullPath(pathProjectPath).ToArray();

                foreach (var project in projects)
                {
                    Console.WriteLine($"{nameof(project)}: {project}");
                    var projectXml = XElement.Load(project);

                    var targetFramework = projectXml.Descendants("PropertyGroup").Select(x => (string?)x.Element("TargetFramework")).FirstOrDefault();
                    if (string.IsNullOrEmpty(targetFramework))
                    {
                        throw new NotSupportedException();
                    }

                    var packages =
                         (from ig in versionXml.Root?.Descendants("ItemGroup")
                          let conditionAttribute = (string?)ig.Attribute("Condition")
                          where conditionAttribute == null || conditionAttribute.Contains(targetFramework, StringComparison.InvariantCultureIgnoreCase)
                          from pv in ig.Elements("PackageVersion")
                          let p = (string?)pv.Attribute("Include")
                          let v = (string?)pv.Attribute("Version")
                          select new
                          {
                              Package = p,
                              Version = v,
                          }).ToArray();

                    var packageReferences = projectXml.Descendants("PackageReference").ToArray();
                    var changed = false;
                    foreach (var packageReference in packageReferences)
                    {
                        var p = (string?)packageReference.Attribute("Include");
                        if (string.IsNullOrWhiteSpace(p))
                            continue;
                        var va = packageReference.Attribute("Version");

                        if (va == null)
                        {
                            packageReference.Add(va = new XAttribute("Version", ""));
                        }

                        var v = (string?)va;
                        //if (string.IsNullOrWhiteSpace(v)) continue;

                        //if (v.StartsWith("$(") && v.EndsWith(")"))
                        //{
                        //    changed = true;
                        //    var y = properties.FirstOrDefault(i => string.Equals(i.Property, v[2..^1], StringComparison.InvariantCultureIgnoreCase))?.Value;
                        //    va.Value = y;
                        //    continue;
                        //}

                        var t = packages.FirstOrDefault(i => string.Equals(i.Package, p, StringComparison.InvariantCultureIgnoreCase))?.Version;
                        if (!string.IsNullOrWhiteSpace(t) && !string.Equals(v, t, StringComparison.InvariantCultureIgnoreCase))
                        {
                            changed = true;
                            va.Value = t;
                        }
                    }
                    if (changed)
                    {
                        projectXml.Save(project);
                    }
                }
            }

            if (!cmdLine.NoNuget)
                await service.UpdateNugetVersionsAsync(versionXml, cmdLine.NugetUrl, cmdLine.FeedType, CancellationToken.None);
            if (!cmdLine.NoSave)
                service.Save(versionXml, string.IsNullOrWhiteSpace(cmdLine.OutputFile) ? cmdLine.SourceFile : cmdLine.OutputFile);

            if (cmdLine.GetProperties)
            {
                foreach (var i in service.GetProperties(versionXml))
                    Console.WriteLine($"{i.propertyName}={i.value}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            Environment.Exit(1);
        }
    }
}
