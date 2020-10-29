
# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleRootNode`1
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_ExtensibleRootNode_1.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleRootNode`1    | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 3                                                            | 
| Uncoveredlines       | 5                                                            | 
| Coverablelines       | 8                                                            | 
| Totallines           | 27                                                           | 
| Linecoverage         | 37.5                                                         | 
| Coveredbranches      | 2                                                            | 
| Totalbranches        | 4                                                            | 
| Branchcoverage       | 50                                                           | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleRootNode.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 4          | 100   | 50.0     | get_Name | 
| 1          | 100   | 100      | get_Parent | 
| 1          | 0     | 100      | get_Value | 
| 1          | 0     | 100      | get_Next | 
| 1          | 0     | 100      | get_Previous | 
| 1          | 0     | 100      | get_FirstAttribute | 
| 1          | 0     | 100      | get_FirstNamespace | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleRootNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰6:   {
〰7:       [DebuggerDisplay("R:>{Name}")]
〰8:       internal class ExtensibleRootNode<T> : IElementNode, IRootNode
〰9:       {
✔10:          public ExtensibleRootNode(INode child) => FirstChild = child;
〰11:  
〰12:          public INode? FirstChild { get; }
〰13:  
⚠14:          public XName Name => FirstChild?.Name ?? "root";
〰15:  
✔16:          public INode? Parent => null;
‼17:          public string? Value => null;
〰18:  
‼19:          public INode? Next => null;
‼20:          public INode? Previous => null;
〰21:  
‼22:          public IAttributeNode? FirstAttribute => null;
‼23:          public INamespaceNode? FirstNamespace => null;
〰24:  
〰25:          public XPathNodeType NodeType { get; } = XPathNodeType.Root;
〰26:      }
〰27:  }

```
## Footer 
[Return to Summary](Summary.md)

