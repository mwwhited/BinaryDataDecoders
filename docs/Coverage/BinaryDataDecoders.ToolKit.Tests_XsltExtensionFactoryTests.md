# BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.XsltExtensionFactoryTests

## Summary

| Key             | Value                                                                |
| :-------------- | :------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.XsltExtensionFactoryTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                   |
| Coveredlines    | `0`                                                                  |
| Uncoveredlines  | `26`                                                                 |
| Coverablelines  | `26`                                                                 |
| Totallines      | `80`                                                                 |
| Linecoverage    | `0`                                                                  |
| Coveredbranches | `0`                                                                  |
| Totalbranches   | `10`                                                                 |
| Branchcoverage  | `0`                                                                  |

## Metrics

| Complexity | Lines | Branches | Name                     |
| :--------- | :---- | :------- | :----------------------- |
| 1          | 0     | 100      | `get_TestContext`        |
| 10         | 0     | 0        | `BuildXsltExtensionTest` |
| 1          | 0     | 100      | `DoWork3`                |
| 1          | 0     | 100      | `DoWork`                 |
| 1          | 0     | 100      | `MoreWork`               |
| 1          | 0     | 100      | `OtherWork`              |
| 1          | 0     | 100      | `AndWork`                |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/Xml/Xsl/XsltExtensionFactoryTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.Xsl;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Diagnostics;
〰5:   using System.Reflection;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Tests.Xml.Xsl
〰8:   {
〰9:       [TestClass]
〰10:      public class XsltExtensionFactoryTests
〰11:      {
‼12:          public TestContext TestContext { get; set; }
〰13:  
〰14:          [TestMethod]
〰15:          public void BuildXsltExtensionTest()
〰16:          {
‼17:              var factory = new XsltExtensionFactory();
〰18:  
‼19:              var toWrap = new FakeClass();
〰20:  
‼21:              var wrapped = factory.BuildXsltExtension(toWrap);
‼22:              var wrappedType = wrapped.GetType();
〰23:  
〰24:              {
‼25:                  var mi = wrappedType.GetMethod("do-work", BindingFlags.Public | BindingFlags.Instance);
‼26:                  var ret = mi?.Invoke(wrapped, new object[] { "Hi!" });
‼27:                  this.TestContext.WriteLine($"{"do-work"}: {ret}");
〰28:              }
〰29:              {
‼30:                  var mi = wrappedType.GetMethod("big-work", BindingFlags.Public | BindingFlags.Instance);
‼31:                  var ret = mi?.Invoke(wrapped, new object[] { "Hi!", "2", "3", "4", "5", "6" });
‼32:                  this.TestContext.WriteLine($"{"big-work"}: {ret}");
〰33:              }
〰34:              {
‼35:                  var mi = wrappedType.GetMethod("more-work", BindingFlags.Public | BindingFlags.Instance);
‼36:                  var ret = mi?.Invoke(wrapped, new object[] { "Hi!" });
‼37:                  this.TestContext.WriteLine($"{"more-work"}: {ret}");
〰38:              }
〰39:              {
‼40:                  var mi = wrappedType.GetMethod("other-work", BindingFlags.Public | BindingFlags.Instance);
‼41:                  var ret = mi?.Invoke(wrapped, Array.Empty<object>());
‼42:                  this.TestContext.WriteLine($"{"other-work"}: {ret}");
〰43:              }
〰44:              {
‼45:                  var mi = wrappedType.GetMethod("and-work", BindingFlags.Public | BindingFlags.Instance);
‼46:                  var ret = mi?.Invoke(wrapped, Array.Empty<object>());
‼47:                  this.TestContext.WriteLine($"{"and-work"}: {ret}");
〰48:              }
〰49:  
‼50:          }
〰51:  
〰52:  
〰53:          public class FakeClass
〰54:          {
〰55:              [XsltFunction("big-work")]
〰56:              public string DoWork3(string x1, string x2, string x3, string x4, string x5, string x6)
〰57:              {
‼58:                  return string.Join("_", x1, x2, x3, x4, x5, x6);
〰59:              }
〰60:  
〰61:              [XsltFunction("do-work")]
‼62:              public string DoWork(string input) => input;
〰63:  
〰64:              [XsltFunction("more-work")]
〰65:              public void MoreWork(string input)
〰66:              {
〰67:                  Debug.WriteLine(input);
‼68:              }
〰69:  
〰70:              [XsltFunction("other-work")]
〰71:              public void OtherWork()
〰72:              {
〰73:                  Debug.WriteLine("hello!");
‼74:              }
〰75:  
〰76:              [XsltFunction("and-work")]
‼77:              public string AndWork() => "noice";
〰78:          }
〰79:      }
〰80:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

