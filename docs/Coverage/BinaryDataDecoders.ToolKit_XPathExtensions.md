
# BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_XPathExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions         | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 1                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 1                                                            | 
| Totallines           | 10                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ToXPathExpression | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰4:   {
〰5:       public static class XPathExtensions
〰6:       {
〰7:           public static string ToXPathExpression(this IPathSegment path) =>
✔8:               new XPathExpressionBuilder().BuildXPathExpression(path);
〰9:       }
〰10:  }

```
## Footer 
[Return to Summary](Summary.md)

