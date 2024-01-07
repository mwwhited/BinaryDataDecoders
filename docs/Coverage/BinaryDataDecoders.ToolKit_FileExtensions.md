# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.FileExtensions

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.FileExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `10`                                                           |
| Coverablelines  | `10`                                                           |
| Totallines      | `89`                                                           |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `4`                                                            |
| Branchcoverage  | `0`                                                            |
| Coveredmethods  | `0`                                                            |
| Totalmethods    | `4`                                                            |
| Methodcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 2          | 0     | 0        | `WriteToFile` |
| 1          | 0     | 100      | `ReadXml`     |
| 2          | 0     | 0        | `WriteToFile` |
| 1          | 0     | 100      | `ReadXml`     |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/FileExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.IO;
〰2:   using BinaryDataDecoders.ToolKit.Security;
〰3:   using System.IO;
〰4:   using System.Xml.Linq;
〰5:   using System.Xml.Serialization;
〰6:   using System.Xml.XPath;
〰7:   using static BinaryDataDecoders.ToolKit.ToolkitConstants;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰10:  
〰11:  /// <summary>
〰12:  /// Sandboxable wrapper around File IO functions intended for use with XslCompiledTransform
〰13:  /// </summary>
〰14:  /// <remarks>
〰15:  /// </remarks>
〰16:  /// <param name="sandbox">base path for sandboxing these functions</param>
〰17:  [XmlRoot(Namespace = XmlNamespaces.Base + nameof(FileExtensions))]
〰18:  public class FileExtensions(string sandbox)
〰19:  {
〰20:  
〰21:      /// <summary>
〰22:      ///
〰23:      /// </summary>
〰24:      /// <param name="source">input XPathNavigator to output</param>
〰25:      /// <param name="filePath">file path to write</param>
〰26:      /// <returns>source</returns>
〰27:      public XPathNavigator WriteToFile(XPathNavigator source, string filePath)
〰28:      {
‼29:          if (string.IsNullOrWhiteSpace(source.Value)) return source;
‼30:          var realPath = SandboxPath.EnsureSafePath(sandbox, filePath).CreateParentIfNotExists();
‼31:          File.WriteAllText(realPath, source.Value);
‼32:          return source;
〰33:      }
〰34:  
〰35:      /// <summary>
〰36:      /// XPathNavigator for XML content of given filePath
〰37:      /// </summary>
〰38:      /// <param name="filePath">file path to read</param>
〰39:      /// <returns>xml content of provided file</returns>
〰40:      public XPathNavigator ReadXml(string filePath) =>
〰41:          //TODO: should this be made safe to return an empty set if file not found?
〰42:          //TODO: should this be made safe to not throw if input is not XML
‼43:          XDocument.Load(SandboxPath.EnsureSafePath(sandbox, filePath)).CreateNavigator();
〰44:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/FileExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.IO;
〰2:   using BinaryDataDecoders.ToolKit.Security;
〰3:   using System.IO;
〰4:   using System.Xml.Linq;
〰5:   using System.Xml.Serialization;
〰6:   using System.Xml.XPath;
〰7:   using static BinaryDataDecoders.ToolKit.ToolkitConstants;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰10:  
〰11:  /// <summary>
〰12:  /// Sandboxable wrapper around File IO functions intended for use with XslCompiledTransform
〰13:  /// </summary>
〰14:  /// <remarks>
〰15:  /// </remarks>
〰16:  /// <param name="sandbox">base path for sandboxing these functions</param>
〰17:  [XmlRoot(Namespace = XmlNamespaces.Base + nameof(FileExtensions))]
〰18:  public class FileExtensions(string sandbox)
〰19:  {
〰20:  
〰21:      /// <summary>
〰22:      ///
〰23:      /// </summary>
〰24:      /// <param name="source">input XPathNavigator to output</param>
〰25:      /// <param name="filePath">file path to write</param>
〰26:      /// <returns>source</returns>
〰27:      public XPathNavigator WriteToFile(XPathNavigator source, string filePath)
〰28:      {
‼29:          if (string.IsNullOrWhiteSpace(source.Value)) return source;
‼30:          var realPath = SandboxPath.EnsureSafePath(sandbox, filePath).CreateParentIfNotExists();
‼31:          File.WriteAllText(realPath, source.Value);
‼32:          return source;
〰33:      }
〰34:  
〰35:      /// <summary>
〰36:      /// XPathNavigator for XML content of given filePath
〰37:      /// </summary>
〰38:      /// <param name="filePath">file path to read</param>
〰39:      /// <returns>xml content of provided file</returns>
〰40:      public XPathNavigator ReadXml(string filePath) =>
〰41:          //TODO: should this be made safe to return an empty set if file not found?
〰42:          //TODO: should this be made safe to not throw if input is not XML
‼43:          XDocument.Load(SandboxPath.EnsureSafePath(sandbox, filePath)).CreateNavigator();
〰44:  }
〰45:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

