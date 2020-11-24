# BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                           |
| Coveredlines    | `4`                                                    |
| Uncoveredlines  | `19`                                                   |
| Coverablelines  | `23`                                                   |
| Totallines      | `70`                                                   |
| Linecoverage    | `17.3`                                                 |
| Coveredbranches | `1`                                                    |
| Totalbranches   | `18`                                                   |
| Branchcoverage  | `5.5`                                                  |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 100   | 100      | `ToXPathExpression` |
| 2          | 100   | 50.0     | `MergeNavigators`   |
| 1          | 100   | 100      | `MergeWith`         |
| 1          | 100   | 100      | `MergeWith`         |
| 1          | 0     | 100      | `AsNavigatorSet`    |
| 16         | 0     | 0        | `AsNodeSet`         |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.PathSegments;
〰2:   using System;
〰3:   using System.Collections;
〰4:   using System.Collections.Generic;
〰5:   using System.Linq;
〰6:   using System.Xml.Linq;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰10:  {
〰11:      public static class XPathExtensions
〰12:      {
〰13:          public static string ToXPathExpression(this IPathSegment path) =>
✔14:              new XPathExpressionBuilder().BuildXPathExpression(path);
〰15:  
〰16:          public static IXPathNavigable MergeNavigators(this IEnumerable<(string source, IXPathNavigable? navigator)> navigators) =>
⚠17:              new WrappedNavigator(WrappedNode.Build(navigators) ?? throw new ArgumentNullException(nameof(navigators)));
〰18:  
〰19:          public static IXPathNavigable MergeWith(this (string source, IXPathNavigable? navigator) navigator, params (string source, IXPathNavigable? navigator)[] navigators) =>
✔20:               navigator.MergeWith(navigators.AsEnumerable());
〰21:          public static IXPathNavigable MergeWith(this (string source, IXPathNavigable? navigator) navigator, IEnumerable<(string source, IXPathNavigable? navigator)> navigators) =>
✔22:              new[] { ( navigator) }.Concat(navigators).MergeNavigators();
〰23:  
〰24:          public static IEnumerable<XPathNavigator> AsNavigatorSet(this XPathNodeIterator iterator) =>
‼25:              iterator.OfType<IXPathNavigable>().Select(node => node.CreateNavigator());
〰26:  
〰27:          public static IEnumerable<XPathNavigator> AsNodeSet(this object item)
〰28:          {
‼29:              if (item is IEnumerable items)
〰30:              {
‼31:                  var enumerable = items.GetEnumerator();
‼32:                  while (enumerable.MoveNext())
〰33:                  {
‼34:                      var current = enumerable.Current;
〰35:  
〰36:                      switch (current)
〰37:                      {
〰38:                          case IXPathNavigable nav:
‼39:                              yield return nav.CreateNavigator();
‼40:                              break;
〰41:  
〰42:                          case IEnumerable<XPathNavigator> navs:
‼43:                              foreach (var nav in navs)
〰44:                              {
‼45:                                  yield return nav.CreateNavigator();
〰46:                              }
‼47:                              break;
〰48:  
〰49:                          case XPathNodeIterator iterator:
‼50:                              while (iterator.MoveNext())
〰51:                              {
‼52:                                  yield return iterator.Current.CreateNavigator();
〰53:                              }
‼54:                              break;
〰55:  
〰56:                          default:
‼57:                              var text = new XText($"{current}");
‼58:                              yield return text.ToXPathNavigable().CreateNavigator();
〰59:                              break;
〰60:                      }
〰61:                  }
‼62:              }
〰63:              else
〰64:              {
‼65:                  foreach (var child in AsNodeSet(new[] { item }))
‼66:                      yield return child;
〰67:              }
‼68:          }
〰69:      }
〰70:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

