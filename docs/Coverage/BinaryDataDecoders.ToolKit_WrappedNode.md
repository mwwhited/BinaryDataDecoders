# BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNode

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                       |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `26`                                               |
| Coverablelines  | `26`                                               |
| Totallines      | `65`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `12`                                               |
| Branchcoverage  | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 0     | 100      | `ctor`         |
| 1          | 0     | 100      | `get_Previous` |
| 1          | 0     | 100      | `get_Current`  |
| 1          | 0     | 100      | `get_Next`     |
| 2          | 0     | 0        | `get_First`    |
| 2          | 0     | 0        | `get_Last`     |
| 8          | 0     | 0        | `Build`        |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\WrappedNode.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Diagnostics;
〰3:   using System.Runtime.InteropServices.ComTypes;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰7:   {
〰8:       [DebuggerDisplay("{Current}")]
〰9:       internal class WrappedNode : IWrappedNode
〰10:      {
‼11:          private WrappedNode(IXPathNavigable nav, IWrappedNode? previous)
〰12:          {
‼13:              var xpathNav = nav.CreateNavigator();
‼14:              xpathNav.MoveToRoot();
‼15:              Current = xpathNav;
‼16:              Previous = previous;
‼17:          }
〰18:  
‼19:          public IWrappedNode? Previous { get; }
‼20:          public XPathNavigator Current { get; }
〰21:  
‼22:          public IWrappedNode? Next { get; private set; }
〰23:  
〰24:          public IWrappedNode First
〰25:          {
〰26:              get
〰27:              {
‼28:                  IWrappedNode c = this;
‼29:                  while (c.Previous != null) c = c.Previous;
‼30:                  return c;
〰31:              }
〰32:          }
〰33:  
〰34:          public IWrappedNode Last
〰35:          {
〰36:              get
〰37:              {
‼38:                  IWrappedNode c = this;
‼39:                  while (c.Next != null) c = c.Next;
‼40:                  return c;
〰41:              }
〰42:          }
〰43:  
〰44:  
〰45:          public static IWrappedNode? Build(IEnumerable<IXPathNavigable?> children)
〰46:          {
‼47:              var enumerator = children.GetEnumerator();
‼48:              WrappedNode? first = null;
‼49:              WrappedNode? previous = null;
〰50:  
‼51:              while (enumerator.MoveNext())
〰52:              {
‼53:                  if (enumerator.Current == null) continue;
‼54:                  var newItem = new WrappedNode(enumerator.Current, previous);
‼55:                  if (previous != null)
〰56:                  {
‼57:                      previous.Next = newItem;
〰58:                  }
‼59:                  if (first == null) first = newItem;
‼60:                  previous = newItem;
〰61:              }
‼62:              return first;
〰63:          }
〰64:      }
〰65:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

