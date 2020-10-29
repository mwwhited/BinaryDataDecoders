
# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.StringExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_StringExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.StringExtensio | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 4                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 35                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\StringExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
| 1          | 0     | 100      | TrimPerLine | 
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
〰34:      }
〰35:  }

```
## Footer 
[Return to Summary](Summary.md)

