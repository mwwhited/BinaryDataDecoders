# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.FileExtensions

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.FileExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `6`                                                            |
| Coverablelines  | `6`                                                            |
| Totallines      | `48`                                                           |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `2`                                                            |
| Branchcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ctor`        |
| 2          | 0     | 0        | `WriteToFile` |
| 1          | 0     | 100      | `ReadXml`     |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\FileExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.IO;
〰2:   using BinaryDataDecoders.ToolKit.Security;
〰3:   using System.IO;
〰4:   using System.Xml.Linq;
〰5:   using System.Xml.Serialization;
〰6:   using System.Xml.XPath;
〰7:   using static BinaryDataDecoders.ToolKit.ToolkitConstants;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰10:  {
〰11:      /// <summary>
〰12:      /// Sandboxable wrapper around File IO functions intended for use with XslCompiledTransform
〰13:      /// </summary>
〰14:      [XmlRoot(Namespace = XmlNamespaces.Base + nameof(FileExtensions))]
〰15:      public class FileExtensions
〰16:      {
〰17:          private readonly string _sandbox;
〰18:  
〰19:          /// <summary>
〰20:          /// </summary>
〰21:          /// <param name="sandbox">base path for sandboxing these functions</param>
‼22:          public FileExtensions(string sandbox) => _sandbox = sandbox;
〰23:  
〰24:          /// <summary>
〰25:          ///
〰26:          /// </summary>
〰27:          /// <param name="source">input XPathNavigator to output</param>
〰28:          /// <param name="filePath">file path to write</param>
〰29:          /// <returns>source</returns>
〰30:          public XPathNavigator WriteToFile(XPathNavigator source, string filePath)
〰31:          {
‼32:              if (string.IsNullOrWhiteSpace(source.Value)) return source;
‼33:              var realPath = SandboxPath.EnsureSafePath(_sandbox, filePath).CreateParentIfNotExists();
‼34:              File.WriteAllText(realPath, source.Value);
‼35:              return source;
〰36:          }
〰37:  
〰38:          /// <summary>
〰39:          /// XPathNavigator for XML content of given filePath
〰40:          /// </summary>
〰41:          /// <param name="filePath">file path to read</param>
〰42:          /// <returns>xml content of provided file</returns>
〰43:          public XPathNavigator ReadXml(string filePath) =>
〰44:              //TODO: should this be made safe to return an empty set if file not found?
〰45:              //TODO: should this be made safe to not throw if input is not XML
‼46:              XDocument.Load(SandboxPath.EnsureSafePath(_sandbox, filePath)).CreateNavigator();
〰47:      }
〰48:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

