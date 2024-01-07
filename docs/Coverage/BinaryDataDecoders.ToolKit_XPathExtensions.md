# BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                           |
| Coveredlines    | `4`                                                    |
| Uncoveredlines  | `48`                                                   |
| Coverablelines  | `52`                                                   |
| Totallines      | `147`                                                  |
| Linecoverage    | `7.6`                                                  |
| Coveredbranches | `1`                                                    |
| Totalbranches   | `36`                                                   |
| Branchcoverage  | `2.7`                                                  |
| Coveredmethods  | `4`                                                    |
| Totalmethods    | `12`                                                   |
| Methodcoverage  | `33.3`                                                 |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `ToXPathExpression` |
| 2          | 0     | 0        | `MergeNavigators`   |
| 1          | 0     | 100      | `MergeWith`         |
| 1          | 0     | 100      | `MergeWith`         |
| 1          | 0     | 100      | `AsNavigatorSet`    |
| 16         | 0     | 0        | `AsNodeSet`         |
| 1          | 100   | 100      | `ToXPathExpression` |
| 2          | 100   | 50.0     | `MergeNavigators`   |
| 1          | 100   | 100      | `MergeWith`         |
| 1          | 100   | 100      | `MergeWith`         |
| 1          | 0     | 100      | `AsNavigatorSet`    |
| 16         | 0     | 0        | `AsNodeSet`         |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/XPathExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.PathSegments;
〰2:   using System;
〰3:   using System.Collections;
〰4:   using System.Collections.Generic;
〰5:   using System.Linq;
〰6:   using System.Xml.Linq;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰10:  
〰11:  public static class XPathExtensions
〰12:  {
〰13:      public static string ToXPathExpression(this IPathSegment path) =>
‼14:          new XPathExpressionBuilder().BuildXPathExpression(path);
〰15:  
〰16:      public static IXPathNavigable MergeNavigators(this IEnumerable<(string source, IXPathNavigable? navigator)> navigators) =>
‼17:          new WrappedNavigator(WrappedNode.Build(navigators) ?? throw new ArgumentNullException(nameof(navigators)));
〰18:  
〰19:      public static IXPathNavigable MergeWith(this (string source, IXPathNavigable? navigator) navigator, params (string source, IXPathNavigable? navigator)[] navigators) =>
‼20:           navigator.MergeWith(navigators.AsEnumerable());
〰21:      public static IXPathNavigable MergeWith(this (string source, IXPathNavigable? navigator) navigator, IEnumerable<(string source, IXPathNavigable? navigator)> navigators) =>
‼22:          new[] { (navigator) }.Concat(navigators).MergeNavigators();
〰23:  
〰24:      public static IEnumerable<XPathNavigator> AsNavigatorSet(this XPathNodeIterator iterator) =>
‼25:          iterator.OfType<IXPathNavigable>()
‼26:                  .Select(node => node.CreateNavigator())
‼27:                  .Where(node => node != null)
‼28:                  .OfType<XPathNavigator>()
〰29:                  ;
〰30:  
〰31:      public static IEnumerable<XPathNavigator> AsNodeSet(this object item)
〰32:      {
‼33:          if (item is IEnumerable items)
〰34:          {
‼35:              var enumerable = items.GetEnumerator();
‼36:              while (enumerable.MoveNext())
〰37:              {
‼38:                  var current = enumerable.Current;
〰39:  
〰40:                  switch (current)
〰41:                  {
〰42:                      case IXPathNavigable nav:
‼43:                          yield return nav.CreateNavigator();
‼44:                          break;
〰45:  
〰46:                      case IEnumerable<XPathNavigator> navs:
‼47:                          foreach (var nav in navs)
〰48:                          {
‼49:                              yield return nav.CreateNavigator();
〰50:                          }
‼51:                          break;
〰52:  
〰53:                      case XPathNodeIterator iterator:
‼54:                          while (iterator.MoveNext())
〰55:                          {
‼56:                              yield return iterator.Current.CreateNavigator();
〰57:                          }
‼58:                          break;
〰59:  
〰60:                      default:
‼61:                          var text = new XText($"{current}");
‼62:                          yield return text.ToXPathNavigable().CreateNavigator();
〰63:                          break;
〰64:                  }
〰65:              }
‼66:          }
〰67:          else
〰68:          {
‼69:              foreach (var child in AsNodeSet(new[] { item }))
‼70:                  yield return child;
〰71:          }
‼72:      }
〰73:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/XPath/XPathExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.PathSegments;
〰2:   using System;
〰3:   using System.Collections;
〰4:   using System.Collections.Generic;
〰5:   using System.Linq;
〰6:   using System.Xml.Linq;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰10:  
〰11:  public static class XPathExtensions
〰12:  {
〰13:      public static string ToXPathExpression(this IPathSegment path) =>
✔14:          new XPathExpressionBuilder().BuildXPathExpression(path);
〰15:  
〰16:      public static IXPathNavigable MergeNavigators(this IEnumerable<(string source, IXPathNavigable? navigator)> navigators) =>
⚠17:          new WrappedNavigator(WrappedNode.Build(navigators) ?? throw new ArgumentNullException(nameof(navigators)));
〰18:  
〰19:      public static IXPathNavigable MergeWith(this (string source, IXPathNavigable? navigator) navigator, params (string source, IXPathNavigable? navigator)[] navigators) =>
✔20:           navigator.MergeWith(navigators.AsEnumerable());
〰21:      public static IXPathNavigable MergeWith(this (string source, IXPathNavigable? navigator) navigator, IEnumerable<(string source, IXPathNavigable? navigator)> navigators) =>
✔22:          new[] { (navigator) }.Concat(navigators).MergeNavigators();
〰23:  
〰24:      public static IEnumerable<XPathNavigator> AsNavigatorSet(this XPathNodeIterator iterator) =>
‼25:          iterator.OfType<IXPathNavigable>()
‼26:                  .Select(node => node.CreateNavigator())
‼27:                  .Where(node => node != null)
‼28:                  .OfType<XPathNavigator>()
〰29:                  ;
〰30:  
〰31:      public static IEnumerable<XPathNavigator> AsNodeSet(this object item)
〰32:      {
‼33:          if (item is IEnumerable items)
〰34:          {
‼35:              var enumerable = items.GetEnumerator();
‼36:              while (enumerable.MoveNext())
〰37:              {
‼38:                  var current = enumerable.Current;
〰39:  
〰40:                  switch (current)
〰41:                  {
〰42:                      case IXPathNavigable nav:
‼43:                          yield return nav.CreateNavigator();
‼44:                          break;
〰45:  
〰46:                      case IEnumerable<XPathNavigator> navs:
‼47:                          foreach (var nav in navs)
〰48:                          {
‼49:                              yield return nav.CreateNavigator();
〰50:                          }
‼51:                          break;
〰52:  
〰53:                      case XPathNodeIterator iterator:
‼54:                          while (iterator.MoveNext())
〰55:                          {
‼56:                              yield return iterator.Current.CreateNavigator();
〰57:                          }
‼58:                          break;
〰59:  
〰60:                      default:
‼61:                          var text = new XText($"{current}");
‼62:                          yield return text.ToXPathNavigable().CreateNavigator();
〰63:                          break;
〰64:                  }
〰65:              }
‼66:          }
〰67:          else
〰68:          {
‼69:              foreach (var child in AsNodeSet(new[] { item }))
‼70:                  yield return child;
〰71:          }
‼72:      }
〰73:  }
〰74:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

