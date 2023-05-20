# BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNode

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                       |
| Coveredlines    | `17`                                               |
| Uncoveredlines  | `3`                                                |
| Coverablelines  | `20`                                               |
| Totallines      | `67`                                               |
| Linecoverage    | `85`                                               |
| Coveredbranches | `9`                                                |
| Totalbranches   | `12`                                               |
| Branchcoverage  | `75`                                               |
| Coveredmethods  | `3`                                                |
| Totalmethods    | `4`                                                |
| Methodcoverage  | `75`                                               |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 100   | 100      | `ctor`      |
| 2          | 100   | 50.0     | `get_First` |
| 2          | 0     | 0        | `get_Last`  |
| 8          | 100   | 100      | `Build`     |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/WrappedNode.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Diagnostics;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰6:   {
〰7:       [DebuggerDisplay("{Current}-{Source}")]
〰8:       internal class WrappedNode : IWrappedNode
〰9:       {
〰10:          private WrappedNode(string source, IXPathNavigable nav, IWrappedNode? previous)
〰11:          {
✔12:              var xpathNav = nav.CreateNavigator();
✔13:              xpathNav.MoveToRoot();
〰14:              Current = xpathNav;
〰15:              Previous = previous;
〰16:              Source = source;
✔17:          }
〰18:  
〰19:          public string Source { get; }
〰20:  
〰21:          public IWrappedNode? Previous { get; }
〰22:          public XPathNavigator Current { get; }
〰23:  
〰24:          public IWrappedNode? Next { get; private set; }
〰25:  
〰26:          public IWrappedNode First
〰27:          {
〰28:              get
〰29:              {
✔30:                  IWrappedNode c = this;
⚠31:                  while (c.Previous != null) c = c.Previous;
✔32:                  return c;
〰33:              }
〰34:          }
〰35:  
〰36:          public IWrappedNode Last
〰37:          {
〰38:              get
〰39:              {
‼40:                  IWrappedNode c = this;
‼41:                  while (c.Next != null) c = c.Next;
‼42:                  return c;
〰43:              }
〰44:          }
〰45:  
〰46:  
〰47:          public static IWrappedNode? Build(IEnumerable<(string source, IXPathNavigable? navigator)> children)
〰48:          {
✔49:              var enumerator = children.GetEnumerator();
✔50:              WrappedNode? first = null;
✔51:              WrappedNode? previous = null;
〰52:  
✔53:              while (enumerator.MoveNext())
〰54:              {
✔55:                  if (enumerator.Current.navigator == null) continue;
✔56:                  var newItem = new WrappedNode(enumerator.Current.source, enumerator.Current.navigator, previous);
✔57:                  if (previous != null)
〰58:                  {
✔59:                      previous.Next = newItem;
〰60:                  }
✔61:                  if (first == null) first = newItem;
✔62:                  previous = newItem;
〰63:              }
✔64:              return first;
〰65:          }
〰66:      }
〰67:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

