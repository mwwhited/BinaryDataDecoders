
# BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_XPathExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.XPath.XPathExtensions         | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 4                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 22                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 1                                                            | 
| Totalbranches        | 2                                                            | 
| Branchcoverage       | 50                                                           | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ToXPathExpression | 
| 2          | 100   | 50.0     | MergeNavigators | 
| 1          | 100   | 100      | MergeWith | 
| 1          | 100   | 100      | MergeWith | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.PathSegments;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.Linq;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰8:   {
〰9:       public static class XPathExtensions
〰10:      {
〰11:          public static string ToXPathExpression(this IPathSegment path) =>
✔12:              new XPathExpressionBuilder().BuildXPathExpression(path);
〰13:  
〰14:          public static IXPathNavigable MergeNavigators(this IEnumerable<IXPathNavigable> navigators) =>
⚠15:              new WrappedNavigator(WrappedNode.Build(navigators) ?? throw new ArgumentNullException(nameof(navigators)));
〰16:  
〰17:          public static IXPathNavigable MergeWith(this IXPathNavigable navigator, params IXPathNavigable[] navigators) =>
✔18:               navigator.MergeWith(navigators.AsEnumerable());
〰19:          public static IXPathNavigable MergeWith(this IXPathNavigable navigator, IEnumerable<IXPathNavigable> navigators) =>
✔20:              new[] { navigator }.Concat(navigators).MergeNavigators();
〰21:      }
〰22:  }

```
## Footer 
[Return to Summary](Summary.md)

