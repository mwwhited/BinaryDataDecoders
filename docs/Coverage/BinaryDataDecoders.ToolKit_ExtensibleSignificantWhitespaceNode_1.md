
# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleSignificantWhitespaceNode`1
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_ExtensibleSignificantWhitespaceNode_1.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleSignificantWh | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 6                                                            | 
| Coverablelines       | 6                                                            | 
| Totallines           | 22                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleSignificantWhitespaceNode.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleSignificantWhitespaceNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰5:   {
〰6:       internal class ExtensibleSignificantWhitespaceNode<T> : ExtensibleSimpleNodeBase<T>
〰7:       {
〰8:           public ExtensibleSignificantWhitespaceNode(
〰9:                INode parent,
〰10:               XName name,
〰11:               T item,
〰12:               string value
‼13:              ) : base(
‼14:                  parent, name, item, "",
‼15:                  XPathNodeType.SignificantWhitespace
‼16:                  )
〰17:          {
‼18:              FirstChild = new ExtensibleTextNode<T>(this, name, item, value);
‼19:          }
〰20:      }
〰21:  }
〰22:  

```
## Footer 
[Return to Summary](Summary.md)

