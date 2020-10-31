# BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                           |
| Coveredlines    | `4`                                                    |
| Uncoveredlines  | `1`                                                    |
| Coverablelines  | `5`                                                    |
| Totallines      | `71`                                                   |
| Linecoverage    | `80`                                                   |
| Coveredbranches | `1`                                                    |
| Totalbranches   | `2`                                                    |
| Branchcoverage  | `50`                                                   |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 100   | 100      | `ToXPathExpression` |
| 2          | 100   | 50.0     | `MergeNavigators`   |
| 1          | 100   | 100      | `MergeWith`         |
| 1          | 100   | 100      | `MergeWith`         |
| 1          | 0     | 100      | `AsNavigatorSet`    |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.PathSegments;
〰2:   using System;
〰3:   using System.Collections;
〰4:   using System.Collections.Generic;
〰5:   using System.Linq;
〰6:   using System.Xml;
〰7:   using System.Xml.Linq;
〰8:   using System.Xml.XPath;
〰9:   
〰10:  namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰11:  {
〰12:      public static class XPathExtensions
〰13:      {
〰14:          public static string ToXPathExpression(this IPathSegment path) =>
✔15:              new XPathExpressionBuilder().BuildXPathExpression(path);
〰16:  
〰17:          public static IXPathNavigable MergeNavigators(this IEnumerable<IXPathNavigable> navigators) =>
⚠18:              new WrappedNavigator(WrappedNode.Build(navigators) ?? throw new ArgumentNullException(nameof(navigators)));
〰19:  
〰20:          public static IXPathNavigable MergeWith(this IXPathNavigable navigator, params IXPathNavigable[] navigators) =>
✔21:               navigator.MergeWith(navigators.AsEnumerable());
〰22:          public static IXPathNavigable MergeWith(this IXPathNavigable navigator, IEnumerable<IXPathNavigable> navigators) =>
✔23:              new[] { navigator }.Concat(navigators).MergeNavigators();
〰24:  
〰25:          public static IEnumerable<XPathNavigator> AsNavigatorSet(this XPathNodeIterator iterator) =>
‼26:              iterator.OfType<IXPathNavigable>().Select(node => node.CreateNavigator());
〰27:  
〰28:          public static IEnumerable<XPathNavigator> AsNodeSet(this object item)
〰29:          {
〰30:              if (item is IEnumerable items)
〰31:              {
〰32:                  var enumerable = items.GetEnumerator();
〰33:                  while (enumerable.MoveNext())
〰34:                  {
〰35:                      var current = enumerable.Current;
〰36:  
〰37:                      switch (current)
〰38:                      {
〰39:                          case IXPathNavigable nav:
〰40:                              yield return nav.CreateNavigator();
〰41:                              break;
〰42:  
〰43:                          case IEnumerable<XPathNavigator> navs:
〰44:                              foreach (var nav in navs)
〰45:                              {
〰46:                                  yield return nav.CreateNavigator();
〰47:                              }
〰48:                              break;
〰49:  
〰50:                          case XPathNodeIterator iterator:
〰51:                              while (iterator.MoveNext())
〰52:                              {
〰53:                                  yield return iterator.Current.CreateNavigator();
〰54:                              }
〰55:                              break;
〰56:  
〰57:                          default:
〰58:                              var text = new XText($"{current}");
〰59:                              yield return text.ToXPathNavigable().CreateNavigator();
〰60:                              break;
〰61:                      }
〰62:                  }
〰63:              }
〰64:              else
〰65:              {
〰66:                  foreach (var child in AsNodeSet(new[] { item }))
〰67:                      yield return child;
〰68:              }
〰69:          }
〰70:      }
〰71:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

