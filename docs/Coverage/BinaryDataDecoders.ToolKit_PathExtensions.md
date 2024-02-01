# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `38`                                                           |
| Coverablelines  | `38`                                                           |
| Totallines      | `255`                                                          |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `8`                                                            |
| Branchcoverage  | `0`                                                            |
| Coveredmethods  | `0`                                                            |
| Totalmethods    | `16`                                                           |
| Methodcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name                          |
| :--------- | :---- | :------- | :---------------------------- |
| 1          | 0     | 100      | `ctor`                        |
| 1          | 0     | 100      | `GetDirectoryName`            |
| 1          | 0     | 100      | `GetFileName`                 |
| 1          | 0     | 100      | `GetFileNameWithoutExtension` |
| 1          | 0     | 100      | `GetExtension`                |
| 2          | 0     | 0        | `ChangeExtension`             |
| 1          | 0     | 100      | `ListFiles`                   |
| 2          | 0     | 0        | `ListFilesFiltered`           |
| 1          | 0     | 100      | `ctor`                        |
| 1          | 0     | 100      | `GetDirectoryName`            |
| 1          | 0     | 100      | `GetFileName`                 |
| 1          | 0     | 100      | `GetFileNameWithoutExtension` |
| 1          | 0     | 100      | `GetExtension`                |
| 2          | 0     | 0        | `ChangeExtension`             |
| 1          | 0     | 100      | `ListFiles`                   |
| 2          | 0     | 0        | `ListFilesFiltered`           |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/PathExtensions.cs

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
〰12:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰13:  
〰14:  /// <summary>
〰15:  /// wrapper around File IO functions intended for use with XslCompiledTransform
〰16:  /// </summary>
〰17:  [XmlRoot(Namespace = XmlNamespaces.Base + nameof(PathExtensions))]
〰18:  public class PathExtensions
〰19:  {
〰20:      /// <summary>
〰21:      ///
〰22:      /// </summary>
〰23:      /// <param name="sandbox">base path used to sand-box requests</param>
〰24:      public PathExtensions(string sandbox)
〰25:      {
‼26:          _sandbox = sandbox;
‼27:          _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼28:      }
〰29:      private readonly string _sandbox;
〰30:      private readonly XNamespace _ns;
〰31:  
〰32:      /// <summary>
〰33:      /// Returns the directory information for the specified path string.
〰34:      /// </summary>
〰35:      /// <param name="path">The path of a file or directory.</param>
〰36:      /// <returns>
〰37:      /// Directory information for path, or null if path denotes a root directory or is
〰38:      /// null. Returns System.String.Empty if path does not contain directory information.
〰39:      /// </returns>
〰40:      public string? GetDirectoryName(string file) =>
‼41:          Path.GetDirectoryName(file);
〰42:  
〰43:      /// <summary>
〰44:      /// Returns the file name and extension of the specified path string.
〰45:      /// </summary>
〰46:      /// <param name="file">The path string from which to obtain the file name and extension.</param>
〰47:      /// <returns>
〰48:      /// The characters after the last directory separator character in path. If the last
〰49:      /// character of path is a directory or volume separator character, this method returns
〰50:      /// System.String.Empty. If path is null, this method returns null.
〰51:      /// </returns>
〰52:      public string? GetFileName(string file) =>
‼53:          Path.GetFileName(file);
〰54:      /// <summary>
〰55:      /// Returns the file name of the specified path string without the extension.
〰56:      /// </summary>
〰57:      /// <param name="file">The path of the file.</param>
〰58:      /// <returns>
〰59:      /// The string returned by System.IO.Path.GetFileName(System.ReadOnlySpan{System.Char}),
〰60:      /// minus the last period (.) and all characters following it.
〰61:      /// </returns>
〰62:      public string? GetFileNameWithoutExtension(string file) =>
‼63:          Path.GetFileNameWithoutExtension(file);
〰64:      /// <summary>
〰65:      /// Returns the extension (including the period ".") of the specified path string.
〰66:      /// </summary>
〰67:      /// <param name="file">The path string from which to get the extension.</param>
〰68:      /// <returns></returns>
〰69:      public string? GetExtension(string file) =>
‼70:          Path.GetExtension(file);
〰71:  
〰72:      /// <summary>
〰73:      /// Changes the extension of a path string.
〰74:      /// </summary>
〰75:      /// <param name="file">The path information to modify. The path cannot contain any of the characters
〰76:      /// defined in System.IO.Path.GetInvalidPathChars.</param>
〰77:      /// <param name="extension">The new extension (with or without a leading period). Specify null to remove
〰78:      /// an existing extension from path.</param>
〰79:      /// <returns>The modified path information. On Windows-based desktop platforms, if path is
〰80:      /// null or an empty string (""), the path information is returned unmodified. If
〰81:      /// extension is null, the returned string contains the specified path with its extension
〰82:      /// removed. If path has no extension, and extension is not null, the returned path
〰83:      /// string contains extension appended to the end of path.</returns>
〰84:      public string? ChangeExtension(string file, string extension) =>
‼85:          Path.ChangeExtension(file, string.IsNullOrWhiteSpace(extension) ? null : extension);
〰86:  
〰87:      /// <summary>
〰88:      /// Returns the names of files (including their paths) that match the specified search
〰89:      /// pattern in the specified directory.
〰90:      /// </summary>
〰91:      /// <param name="path">The relative or absolute path to the directory to search. This string is not
〰92:      /// case-sensitive.</param>
〰93:      /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
〰94:      /// that match the specified search pattern, or an empty array if no files are found.</returns>
〰95:      public XPathNavigator? ListFiles(string path) =>
‼96:          new XElement(_ns + "files",
‼97:              from f in Directory.GetFiles(SandboxPath.EnsureSafePath(_sandbox, path))
‼98:              select new XElement(_ns + "file", f)
‼99:          ).ToXPathNavigable().CreateNavigator();
〰100: 
〰101:     /// <summary>
〰102:     /// Returns the names of files (including their paths) that match the specified search
〰103:     /// pattern in the specified directory.
〰104:     /// </summary>
〰105:     /// <param name="path">The relative or absolute path to the directory to search. This string is not
〰106:     /// case-sensitive.</param>
〰107:     /// <param name="pattern">The search string to match against the names of files in path. This parameter
〰108:     /// can contain a combination of valid literal path and wildcard (* and ?) characters,
〰109:     /// but it doesn't support regular expressions.</param>
〰110:     /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
〰111:     /// that match the specified search pattern, or an empty array if no files are found.</returns>
〰112:     public XPathNavigator? ListFilesFiltered(string path, string pattern)
〰113:     {
‼114:         var cleanedPath = SandboxPath.EnsureSafePath(_sandbox, path);
〰115: #if DEBUG && false
〰116:         Console.WriteLine($"==> Path: {path}");
〰117:         Console.WriteLine($"==> Pattern: {pattern}");
〰118:         Console.WriteLine($"==> Cleaned: {cleanedPath}");
〰119: #endif
‼120:         var files = Directory.Exists(cleanedPath) ? Directory.GetFiles(cleanedPath, pattern) : Enumerable.Empty<string>(); ;
‼121:         var xml = new XElement(_ns + "files",
‼122:               from f in files
‼123:               select new XElement(_ns + "file", new XText(f))
‼124:           );
‼125:         return xml.ToXPathNavigable().CreateNavigator();
〰126:     }
〰127: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/PathExtensions.cs

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
〰12:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰13:  
〰14:  /// <summary>
〰15:  /// wrapper around File IO functions intended for use with XslCompiledTransform
〰16:  /// </summary>
〰17:  [XmlRoot(Namespace = XmlNamespaces.Base + nameof(PathExtensions))]
〰18:  public class PathExtensions
〰19:  {
〰20:      /// <summary>
〰21:      ///
〰22:      /// </summary>
〰23:      /// <param name="sandbox">base path used to sand-box requests</param>
〰24:      public PathExtensions(string sandbox)
〰25:      {
‼26:          _sandbox = sandbox;
‼27:          _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼28:      }
〰29:      private readonly string _sandbox;
〰30:      private readonly XNamespace _ns;
〰31:  
〰32:      /// <summary>
〰33:      /// Returns the directory information for the specified path string.
〰34:      /// </summary>
〰35:      /// <param name="path">The path of a file or directory.</param>
〰36:      /// <returns>
〰37:      /// Directory information for path, or null if path denotes a root directory or is
〰38:      /// null. Returns System.String.Empty if path does not contain directory information.
〰39:      /// </returns>
〰40:      public string? GetDirectoryName(string file) =>
‼41:          Path.GetDirectoryName(file);
〰42:  
〰43:      /// <summary>
〰44:      /// Returns the file name and extension of the specified path string.
〰45:      /// </summary>
〰46:      /// <param name="file">The path string from which to obtain the file name and extension.</param>
〰47:      /// <returns>
〰48:      /// The characters after the last directory separator character in path. If the last
〰49:      /// character of path is a directory or volume separator character, this method returns
〰50:      /// System.String.Empty. If path is null, this method returns null.
〰51:      /// </returns>
〰52:      public string? GetFileName(string file) =>
‼53:          Path.GetFileName(file);
〰54:      /// <summary>
〰55:      /// Returns the file name of the specified path string without the extension.
〰56:      /// </summary>
〰57:      /// <param name="file">The path of the file.</param>
〰58:      /// <returns>
〰59:      /// The string returned by System.IO.Path.GetFileName(System.ReadOnlySpan{System.Char}),
〰60:      /// minus the last period (.) and all characters following it.
〰61:      /// </returns>
〰62:      public string? GetFileNameWithoutExtension(string file) =>
‼63:          Path.GetFileNameWithoutExtension(file);
〰64:      /// <summary>
〰65:      /// Returns the extension (including the period ".") of the specified path string.
〰66:      /// </summary>
〰67:      /// <param name="file">The path string from which to get the extension.</param>
〰68:      /// <returns></returns>
〰69:      public string? GetExtension(string file) =>
‼70:          Path.GetExtension(file);
〰71:  
〰72:      /// <summary>
〰73:      /// Changes the extension of a path string.
〰74:      /// </summary>
〰75:      /// <param name="file">The path information to modify. The path cannot contain any of the characters
〰76:      /// defined in System.IO.Path.GetInvalidPathChars.</param>
〰77:      /// <param name="extension">The new extension (with or without a leading period). Specify null to remove
〰78:      /// an existing extension from path.</param>
〰79:      /// <returns>The modified path information. On Windows-based desktop platforms, if path is
〰80:      /// null or an empty string (""), the path information is returned unmodified. If
〰81:      /// extension is null, the returned string contains the specified path with its extension
〰82:      /// removed. If path has no extension, and extension is not null, the returned path
〰83:      /// string contains extension appended to the end of path.</returns>
〰84:      public string? ChangeExtension(string file, string extension) =>
‼85:          Path.ChangeExtension(file, string.IsNullOrWhiteSpace(extension) ? null : extension);
〰86:  
〰87:      /// <summary>
〰88:      /// Returns the names of files (including their paths) that match the specified search
〰89:      /// pattern in the specified directory.
〰90:      /// </summary>
〰91:      /// <param name="path">The relative or absolute path to the directory to search. This string is not
〰92:      /// case-sensitive.</param>
〰93:      /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
〰94:      /// that match the specified search pattern, or an empty array if no files are found.</returns>
〰95:      public XPathNavigator? ListFiles(string path) =>
‼96:          new XElement(_ns + "files",
‼97:              from f in Directory.GetFiles(SandboxPath.EnsureSafePath(_sandbox, path))
‼98:              select new XElement(_ns + "file", f)
‼99:          ).ToXPathNavigable().CreateNavigator();
〰100: 
〰101:     /// <summary>
〰102:     /// Returns the names of files (including their paths) that match the specified search
〰103:     /// pattern in the specified directory.
〰104:     /// </summary>
〰105:     /// <param name="path">The relative or absolute path to the directory to search. This string is not
〰106:     /// case-sensitive.</param>
〰107:     /// <param name="pattern">The search string to match against the names of files in path. This parameter
〰108:     /// can contain a combination of valid literal path and wildcard (* and ?) characters,
〰109:     /// but it doesn't support regular expressions.</param>
〰110:     /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
〰111:     /// that match the specified search pattern, or an empty array if no files are found.</returns>
〰112:     public XPathNavigator? ListFilesFiltered(string path, string pattern)
〰113:     {
‼114:         var cleanedPath = SandboxPath.EnsureSafePath(_sandbox, path);
〰115: #if DEBUG && false
〰116:         Console.WriteLine($"==> Path: {path}");
〰117:         Console.WriteLine($"==> Pattern: {pattern}");
〰118:         Console.WriteLine($"==> Cleaned: {cleanedPath}");
〰119: #endif
‼120:         var files = Directory.Exists(cleanedPath) ? Directory.GetFiles(cleanedPath, pattern) : Enumerable.Empty<string>(); ;
‼121:         var xml = new XElement(_ns + "files",
‼122:               from f in files
‼123:               select new XElement(_ns + "file", new XText(f))
‼124:           );
‼125:         return xml.ToXPathNavigable().CreateNavigator();
〰126:     }
〰127: }
〰128: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

