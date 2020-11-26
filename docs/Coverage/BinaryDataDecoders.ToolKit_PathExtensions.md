# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `20`                                                           |
| Coverablelines  | `20`                                                           |
| Totallines      | `123`                                                          |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `4`                                                            |
| Branchcoverage  | `0`                                                            |

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
〰33:          /// Returns the directory information for the specified path string.
〰34:          /// </summary>
〰35:          /// <param name="path">The path of a file or directory.</param>
〰36:          /// <returns>
〰37:          /// Directory information for path, or null if path denotes a root directory or is
〰38:          /// null. Returns System.String.Empty if path does not contain directory information.
〰39:          /// </returns>
‼40:          public string GetDirectoryName(string file) => Path.GetDirectoryName(file);
〰41:  
〰42:          /// <summary>
〰43:          /// Returns the file name and extension of the specified path string.
〰44:          /// </summary>
〰45:          /// <param name="file">The path string from which to obtain the file name and extension.</param>
〰46:          /// <returns>
〰47:          /// The characters after the last directory separator character in path. If the last
〰48:          /// character of path is a directory or volume separator character, this method returns
〰49:          /// System.String.Empty. If path is null, this method returns null.
〰50:          /// </returns>
‼51:          public string GetFileName(string file) => Path.GetFileName(file);
〰52:          /// <summary>
〰53:          /// Returns the file name of the specified path string without the extension.
〰54:          /// </summary>
〰55:          /// <param name="file">The path of the file.</param>
〰56:          /// <returns>
〰57:          /// The string returned by System.IO.Path.GetFileName(System.ReadOnlySpan{System.Char}),
〰58:          /// minus the last period (.) and all characters following it.
〰59:          /// </returns>
‼60:          public string GetFileNameWithoutExtension(string file) => Path.GetFileNameWithoutExtension(file);
〰61:          /// <summary>
〰62:          /// Returns the extension (including the period ".") of the specified path string.
〰63:          /// </summary>
〰64:          /// <param name="file">The path string from which to get the extension.</param>
〰65:          /// <returns></returns>
‼66:          public string GetExtension(string file) => Path.GetExtension(file);
〰67:  
〰68:          /// <summary>
〰69:          /// Changes the extension of a path string.
〰70:          /// </summary>
〰71:          /// <param name="file">The path information to modify. The path cannot contain any of the characters
〰72:          /// defined in System.IO.Path.GetInvalidPathChars.</param>
〰73:          /// <param name="extension">The new extension (with or without a leading period). Specify null to remove
〰74:          /// an existing extension from path.</param>
〰75:          /// <returns>The modified path information. On Windows-based desktop platforms, if path is
〰76:          /// null or an empty string (""), the path information is returned unmodified. If
〰77:          /// extension is null, the returned string contains the specified path with its extension
〰78:          /// removed. If path has no extension, and extension is not null, the returned path
〰79:          /// string contains extension appended to the end of path.</returns>
‼80:          public string ChangeExtension(string file, string extension) => Path.ChangeExtension(file, string.IsNullOrWhiteSpace(extension) ? null : extension);
〰81:  
〰82:          /// <summary>
〰83:          /// Returns the names of files (including their paths) that match the specified search
〰84:          /// pattern in the specified directory.
〰85:          /// </summary>
〰86:          /// <param name="path">The relative or absolute path to the directory to search. This string is not
〰87:          /// case-sensitive.</param>
〰88:          /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
〰89:          /// that match the specified search pattern, or an empty array if no files are found.</returns>
〰90:          public XPathNavigator ListFiles(string path) =>
‼91:              new XElement(_ns + "files",
‼92:                  from f in Directory.GetFiles(SandboxPath.EnsureSafePath(_sandbox, path))
‼93:                  select new XElement(_ns + "file", f)
‼94:              ).ToXPathNavigable().CreateNavigator();
〰95:  
〰96:          /// <summary>
〰97:          /// Returns the names of files (including their paths) that match the specified search
〰98:          /// pattern in the specified directory.
〰99:          /// </summary>
〰100:         /// <param name="path">The relative or absolute path to the directory to search. This string is not
〰101:         /// case-sensitive.</param>
〰102:         /// <param name="pattern">The search string to match against the names of files in path. This parameter
〰103:         /// can contain a combination of valid literal path and wildcard (* and ?) characters,
〰104:         /// but it doesn't support regular expressions.</param>
〰105:         /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
〰106:         /// that match the specified search pattern, or an empty array if no files are found.</returns>
〰107:         public XPathNavigator ListFilesFiltered(string path, string pattern)
〰108:         {
‼109:             var cleanedPath = SandboxPath.EnsureSafePath(_sandbox, path);
〰110: #if DEBUG && false
〰111:             Console.WriteLine($"==> Path: {path}");
〰112:             Console.WriteLine($"==> Pattern: {pattern}");
〰113:             Console.WriteLine($"==> Cleaned: {cleanedPath}");
〰114: #endif
‼115:             var files = Directory.Exists(cleanedPath) ? Directory.GetFiles(cleanedPath, pattern) : Enumerable.Empty<string>(); ;
‼116:             var xml = new XElement(_ns + "files",
‼117:                   from f in files
‼118:                   select new XElement(_ns + "file", new XText(f))
‼119:               );
‼120:             return xml.ToXPathNavigable().CreateNavigator();
〰121:         }
〰122:     }
〰123: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

