# BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions.TrxExtensions

## Summary

| Key             | Value                                                               |
| :-------------- | :------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions.TrxExtensions` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                                  |
| Coveredlines    | `0`                                                                 |
| Uncoveredlines  | `24`                                                                |
| Coverablelines  | `24`                                                                |
| Totallines      | `65`                                                                |
| Linecoverage    | `0`                                                                 |
| Coveredbranches | `0`                                                                 |
| Totalbranches   | `24`                                                                |
| Branchcoverage  | `0`                                                                 |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 24         | 0     | 0        | `GetTestTargets` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/Xml/Xsl/Extensions/TrxExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   using System.Linq;
〰4:   using System.Reflection;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.XPath;
〰7:   using BinaryDataDecoders.ToolKit;
〰8:   
〰9:   namespace BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions
〰10:  {
〰11:      /// <summary>
〰12:      /// wrapper around MS Test Results intended for use with XslCompiledTransform
〰13:      /// </summary>
〰14:      public class TrxExtensions
〰15:      {
〰16:          /// <summary>
〰17:          ///
〰18:          /// </summary>
〰19:          /// <param name="input">{http://microsoft.com/schemas/VisualStudio/TeamTest/2010}TestMethod</param>
〰20:          /// <returns></returns>
〰21:          public XPathNavigator GetTestTargets(XPathNavigator? input)
〰22:          {
‼23:              XNamespace ns = this.GetXmlNamespace() + ":out";
〰24:              try
〰25:              {
〰26:  
〰27:                  /*
〰28:                <TestMethod codeBase="C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator.Tests\bin\Debug\netcoreapp3.1\BinaryDataDecoders.ExpressionCalculator.Tests.dll"
〰29:                      adapterTypeName="executor://mstestadapter/v2"
〰30:                      className="BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int64ExpressionParserTests"
〰31:                      name="GetDistinctVariablesTests" />
〰32:                  */
〰33:  
‼34:                  var codeBase = input?.GetAttribute("codeBase", "");
‼35:                  var className = input?.GetAttribute("className", "");
‼36:                  var name = input?.GetAttribute("name", "");
〰37:  
‼38:                  if (!File.Exists(codeBase)) return new XElement(ns + "targets", new XComment($"File: \"{codeBase}\" not found")).ToXPathNavigable().CreateNavigator();
〰39:  
‼40:                  var assembly = string.IsNullOrWhiteSpace(codeBase) ? null : Assembly.LoadFrom(codeBase);
‼41:                  var testClass = string.IsNullOrWhiteSpace(className) ? null : assembly?.GetType(className);
‼42:                  var testMethod = string.IsNullOrWhiteSpace(name) ? null : testClass?.GetMethod(name);
‼43:                  var attributes = testMethod?.GetCustomAttributes<TestTargetAttribute>() ?? Enumerable.Empty<TestTargetAttribute>();
〰44:  
‼45:                  var xml = new XElement(ns + "targets",
‼46:                      from a in attributes
‼47:                      select new XElement(ns + "target",
‼48:                          new XAttribute("name", a.Class.Name),
‼49:                          new XAttribute("namespace", a.Class.Namespace),
‼50:                          new XAttribute("assembly", a.Class.Assembly.FullName),
‼51:                          (string.IsNullOrWhiteSpace(a.Member) ? null : new XAttribute("member", a.Member))
‼52:                          )
‼53:                      );
〰54:  
‼55:                  var xPathNavigable = xml.ToXPathNavigable();
‼56:                  var xPathNavigator = xPathNavigable.CreateNavigator();
‼57:                  return xPathNavigator;
〰58:              }
‼59:              catch (Exception ex)
〰60:              {
‼61:                  return new XElement(ns + "targets", new XComment(ex.Message)).ToXPathNavigable().CreateNavigator();
〰62:              }
‼63:          }
〰64:      }
〰65:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

