﻿using BinaryDataDecoders.ToolKit.IO;
using BinaryDataDecoders.ToolKit.Security;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using static BinaryDataDecoders.ToolKit.ToolkitConstants;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;

/// <summary>
/// Sandboxable wrapper around File IO functions intended for use with XslCompiledTransform
/// </summary>
/// <remarks>
/// </remarks>
/// <param name="sandbox">base path for sandboxing these functions</param>
[XmlRoot(Namespace = XmlNamespaces.Base + nameof(FileExtensions))]
public class FileExtensions(string sandbox)
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source">input XPathNavigator to output</param>
    /// <param name="filePath">file path to write</param>
    /// <returns>source</returns>
    public XPathNavigator WriteToFile(XPathNavigator source, string filePath)
    {
        if (string.IsNullOrWhiteSpace(source.Value)) return source;
        var realPath = SandboxPath.EnsureSafePath(sandbox, filePath).CreateParentIfNotExists();
        File.WriteAllText(realPath, source.Value);
        return source;
    }

    /// <summary>
    /// XPathNavigator for XML content of given filePath
    /// </summary>
    /// <param name="filePath">file path to read</param>
    /// <returns>xml content of provided file</returns>
    public XPathNavigator ReadXml(string filePath) =>
        //TODO: should this be made safe to return an empty set if file not found?
        //TODO: should this be made safe to not throw if input is not XML
        XDocument.Load(SandboxPath.EnsureSafePath(sandbox, filePath)).CreateNavigator();
}
