using NuGet.Protocol;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryDataDecoders.PackMan.Cli;

public interface INugetManager
{
    XDocument OpenXml(string versionPropsFile, bool followImports = false);
    IEnumerable<(string name, string? version)> SplitVersions(string? inputVersions);
    Task UpdateNugetVersionsAsync(XDocument versionXml, string nugetUrl, FeedType feedType, CancellationToken cancellationToken);
    void UpdateTargetVersions(XDocument xDocument, IEnumerable<(string name, string? version)> properties);
    void Save(XDocument versionXml, string filePath);

    IEnumerable<(string propertyName, string value)> GetProperties(XDocument versionXml);
}