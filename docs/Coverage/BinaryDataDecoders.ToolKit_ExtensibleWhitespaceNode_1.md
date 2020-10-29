
# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleWhitespaceNode`1
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_ExtensibleWhitespaceNode_1.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleWhitespaceNod | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 2                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 2                                                            | 
| Totallines           | 18                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleWhitespaceNode.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleWhitespaceNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰5:   {
〰6:   
〰7:       internal class ExtensibleWhitespaceNode<T> : ExtensibleSimpleNodeBase<T>
〰8:       {
〰9:           public ExtensibleWhitespaceNode(
〰10:               INode parent,
〰11:               XName name,
〰12:               T item,
〰13:               string value
✔14:              ) : base(parent, name, item, value, XPathNodeType.Whitespace)
〰15:          {
✔16:          }
〰17:      }
〰18:  }

```
## Footer 
[Return to Summary](Summary.md)

