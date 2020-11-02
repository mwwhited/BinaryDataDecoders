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
〰6:   using System.Text;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰9:   {
〰10:      /// <summary>
〰11:      /// A wrapper around string functions intended for use with XslCompiledTransform
〰12:      /// </summary>
〰13:      [XmlRoot(Namespace = XmlNamespaces.Base + nameof(StringExtensions))]
〰14:      public class StringExtensions
〰15:      {
〰16:          private readonly XNamespace _ns;
〰17:  
〰18:          /// <summary>
〰19:          /// Create instance of StringExtensions
〰20:          /// </summary>
‼21:          public StringExtensions()
〰22:          {
‼23:              _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼24:          }
〰25:  
〰26:          /// <summary>
〰27:          /// remove leading and trailing whitespace for multiline strings
〰28:          /// </summary>
〰29:          /// <param name="input">iput multiline string</param>
〰30:          /// <returns>cleaned multiline string</returns>
〰31:          public string TrimPerLine(string input) =>
‼32:              string.Join("\r\n", input.Split("\r\n").Select(l => l.Trim().Trim('\t', '\r', '\n', ' ')));
〰33:  
〰34:  
‼35:          public string PadLeft(string input, int totalWidth) => input.PadLeft(totalWidth);
‼36:          public string PadRight(string input, int totalWidth) => input.PadRight(totalWidth);
‼37:          public string New(string @char, int length) => string.IsNullOrEmpty(@char) || length < 0 ? "" : new string(@char[0], length);
〰38:      }
〰39:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

