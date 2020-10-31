# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.StringExtensions

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.StringExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `7`                                                              |
| Coverablelines  | `7`                                                              |
| Totallines      | `39`                                                             |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `4`                                                              |
| Branchcoverage  | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ctor`        |
| 1          | 0     | 100      | `TrimPerLine` |
| 1          | 0     | 100      | `PadLeft`     |
| 1          | 0     | 100      | `PadRight`    |
| 4          | 0     | 0        | `New`         |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\StringExtensions.cs

```CSharp
〰1:   using System.IO;
〰2:   using System.Xml.Linq;
〰3:   using System.Linq;
〰4:   using static BinaryDataDecoders.ToolKit.ToolkitConstants;
〰5:   using System.Xml.Serialization;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰8:   {
〰9:       /// <summary>
〰10:      /// A wrapper around string functions intended for use with XslCompiledTransform
〰11:      /// </summary>
〰12:      [XmlRoot(Namespace = XmlNamespaces.Base + nameof(StringExtensions))]
〰13:      public class StringExtensions
〰14:      {
〰15:          private readonly XNamespace _ns;
〰16:  
〰17:          /// <summary>
〰18:          /// Create instance of StringExtensions
〰19:          /// </summary>
‼20:          public StringExtensions()
〰21:          {
‼22:              _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼23:          }
〰24:  
〰25:          /// <summary>
〰26:          /// remove leading and trailing whitespace for multiline strings
〰27:          /// </summary>
〰28:          /// <param name="input">iput multiline string</param>
〰29:          /// <returns>cleaned multiline string</returns>
〰30:          public string TrimPerLine(string input) =>
‼31:              string.Join("\r\n", input.Split("\r\n").Select(l => l.Trim().Trim('\t', '\r', '\n', ' ')));
〰32:  
〰33:  
‼34:          public string PadLeft(string input, int totalWidth) => input.PadLeft(totalWidth);
‼35:          public string PadRight(string input, int totalWidth) => input.PadRight(totalWidth);
‼36:          public string New(string @char, int length) => string.IsNullOrEmpty(@char) || length < 0 ? "" : new string(@char[0], length);
〰37:  
〰38:      }
〰39:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

