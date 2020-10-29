
# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_PathExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 19                                                           | 
| Coverablelines       | 19                                                           | 
| Totallines           | 113                                                          | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 4                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\PathExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
| 1          | 0     | 100      | GetFileName | 
| 1          | 0     | 100      | GetFileNameWithoutExtension | 
| 1          | 0     | 100      | GetExtension | 
| 2          | 0     | 0        | ChangeExtension | 
| 1          | 0     | 100      | ListFiles | 
| 2          | 0     | 0        | ListFilesFiltered | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\PathExtensions.cs

```CSharp
〰1:   
〰2:   using BinaryDataDecoders.ToolKit.Security;
〰3:   using System;
〰4:   using System.Diagnostics;
〰5:   using System.IO;
〰6:   using System.Linq;
〰7:   using System.Xml.Linq;
〰8:   using System.Xml.Serialization;
〰9:   using System.Xml.XPath;
〰10:  using static BinaryDataDecoders.ToolKit.ToolkitConstants;
〰11:  
〰12:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰13:  {
〰14:      /// <summary>
〰15:      /// wrapper around File IO functions intended for use with XslCompiledTransform
〰16:      /// </summary>
〰17:      [XmlRoot(Namespace = XmlNamespaces.Base + nameof(PathExtensions))]
〰18:      public class PathExtensions
〰19:      {
〰20:          /// <summary>
〰21:          ///
〰22:          /// </summary>
〰23:          /// <param name="sandbox">base path used to sand-box requests</param>
‼24:          public PathExtensions(string sandbox)
〰25:          {
‼26:              _sandbox = sandbox;
‼27:              _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼28:          }
〰29:          private readonly string _sandbox;
〰30:          private readonly XNamespace _ns;
〰31:  
〰32:          /// <summary>
〰33:          /// Returns the file name and extension of the specified path string.
〰34:          /// </summary>
〰35:          /// <param name="file">The path string from which to obtain the file name and extension.</param>
〰36:          /// <returns>
〰37:          /// The characters after the last directory separator character in path. If the last
〰38:          /// character of path is a directory or volume separator character, this method returns
〰39:          /// System.String.Empty. If path is null, this method returns null.
〰40:          /// </returns>
‼41:          public string GetFileName(string file) => Path.GetFileName(file);
〰42:          /// <summary>
〰43:          /// Returns the file name of the specified path string without the extension.
〰44:          /// </summary>
〰45:          /// <param name="file">The path of the file.</param>
〰46:          /// <returns>
〰47:          /// The string returned by System.IO.Path.GetFileName(System.ReadOnlySpan{System.Char}),
〰48:          /// minus the last period (.) and all characters following it.
〰49:          /// </returns>
‼50:          public string GetFileNameWithoutExtension(string file) => Path.GetFileNameWithoutExtension(file);
〰51:          /// <summary>
〰52:          /// Returns the extension (including the period ".") of the specified path string.
〰53:          /// </summary>
〰54:          /// <param name="file">The path string from which to get the extension.</param>
〰55:          /// <returns></returns>
‼56:          public string GetExtension(string file) => Path.GetExtension(file);
〰57:  
〰58:          /// <summary>
〰59:          /// Changes the extension of a path string.
〰60:          /// </summary>
〰61:          /// <param name="file">The path information to modify. The path cannot contain any of the characters
〰62:          /// defined in System.IO.Path.GetInvalidPathChars.</param>
〰63:          /// <param name="extension">The new extension (with or without a leading period). Specify null to remove
〰64:          /// an existing extension from path.</param>
〰65:          /// <returns>The modified path information. On Windows-based desktop platforms, if path is
〰66:          /// null or an empty string (""), the path information is returned unmodified. If
〰67:          /// extension is null, the returned string contains the specified path with its extension
〰68:          /// removed. If path has no extension, and extension is not null, the returned path
〰69:          /// string contains extension appended to the end of path.</returns>
‼70:          public string ChangeExtension(string file, string extension) => Path.ChangeExtension(file, string.IsNullOrWhiteSpace(extension) ? null : extension);
〰71:  
〰72:          /// <summary>
〰73:          /// Returns the names of files (including their paths) that match the specified search
〰74:          /// pattern in the specified directory.
〰75:          /// </summary>
〰76:          /// <param name="path">The relative or absolute path to the directory to search. This string is not
〰77:          /// case-sensitive.</param>
〰78:          /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
〰79:          /// that match the specified search pattern, or an empty array if no files are found.</returns>
〰80:          public XPathNavigator ListFiles(string path) =>
‼81:              new XElement(_ns + "files",
‼82:                  from f in Directory.GetFiles(SandboxPath.EnsureSafePath(_sandbox, path))
‼83:                  select new XElement(_ns + "file", f)
‼84:              ).ToXPathNavigable().CreateNavigator();
〰85:  
〰86:          /// <summary>
〰87:          /// Returns the names of files (including their paths) that match the specified search
〰88:          /// pattern in the specified directory.
〰89:          /// </summary>
〰90:          /// <param name="path">The relative or absolute path to the directory to search. This string is not
〰91:          /// case-sensitive.</param>
〰92:          /// <param name="pattern">The search string to match against the names of files in path. This parameter
〰93:          /// can contain a combination of valid literal path and wildcard (* and ?) characters,
〰94:          /// but it doesn't support regular expressions.</param>
〰95:          /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
〰96:          /// that match the specified search pattern, or an empty array if no files are found.</returns>
〰97:          public XPathNavigator ListFilesFiltered(string path, string pattern)
〰98:          {
‼99:              var cleanedPath = SandboxPath.EnsureSafePath(_sandbox, path);
〰100: #if DEBUG
〰101:             Console.WriteLine($"==> Path: {path}");
〰102:             Console.WriteLine($"==> Pattern: {pattern}");
〰103:             Console.WriteLine($"==> Cleaned: {cleanedPath}");
〰104: #endif
‼105:             var files = Directory.Exists(cleanedPath) ? Directory.GetFiles(cleanedPath, pattern) : Enumerable.Empty<string>(); ;
‼106:             var xml = new XElement(_ns + "files",
‼107:                   from f in files
‼108:                   select new XElement(_ns + "file", new XText(f))
‼109:               );
‼110:             return xml.ToXPathNavigable().CreateNavigator();
〰111:         }
〰112:     }
〰113: }

```
## Footer 
[Return to Summary](Summary.md)

