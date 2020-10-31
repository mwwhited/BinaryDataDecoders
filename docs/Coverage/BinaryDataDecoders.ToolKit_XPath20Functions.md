
# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XPath20Functions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_XPath20Functions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XPath20Functio | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 7                                                            | 
| Coverablelines       | 7                                                            | 
| Totallines           | 25                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\XPath20Functions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | abs | 
| 1          | 0     | 100      | distinct_values | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\XPath20Functions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.Collections;
〰4:   using System.Linq;
〰5:   using System.Xml.Serialization;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰9:   {
〰10:      [XmlRoot(Namespace = @"http://www.w3.org/2005/xpath-functions")]
〰11:      public class XPath20Functions
〰12:      {
‼13:          public decimal abs(decimal input) => Math.Abs(input);
〰14:  
〰15:          // https://www.w3.org/2005/xpath-functions/
〰16:  
〰17:          public XPathNodeIterator distinct_values(XPathNodeIterator input) =>
‼18:               new EnumerableXPathNodeIterator(
‼19:                  from i in input.OfType<IXPathNavigable>()
‼20:                  let n = i.CreateNavigator()
‼21:                  group n by n.Value into grouped
‼22:                  from i in grouped
‼23:                  select grouped.First());
〰24:      }
〰25:  }

```
## Footer 
[Return to Summary](Summary.md)

