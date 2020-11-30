# BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.XsltExtensionFactoryTests

## Summary

| Key             | Value                                                                |
| :-------------- | :------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.XsltExtensionFactoryTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                   |
| Coveredlines    | `0`                                                                  |
| Uncoveredlines  | `26`                                                                 |
| Coverablelines  | `26`                                                                 |
| Totallines      | `81`                                                                 |
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
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.Xml.Xsl;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Diagnostics;
〰6:   using System.Reflection;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Tests.Xml.Xsl
〰9:   {
〰10:      [TestClass]
〰11:      public class XsltExtensionFactoryTests
〰12:      {
‼13:          public TestContext TestContext { get; set; }
〰14:  
〰15:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰16:          public void BuildXsltExtensionTest()
〰17:          {
‼18:              var factory = new XsltExtensionFactory();
〰19:  
‼20:              var toWrap = new FakeClass();
〰21:  
‼22:              var wrapped = factory.BuildXsltExtension(toWrap);
‼23:              var wrappedType = wrapped.GetType();
〰24:  
〰25:              {
‼26:                  var mi = wrappedType.GetMethod("do-work", BindingFlags.Public | BindingFlags.Instance);
‼27:                  var ret = mi?.Invoke(wrapped, new object[] { "Hi!" });
‼28:                  this.TestContext.WriteLine($"{"do-work"}: {ret}");
〰29:              }
〰30:              {
‼31:                  var mi = wrappedType.GetMethod("big-work", BindingFlags.Public | BindingFlags.Instance);
‼32:                  var ret = mi?.Invoke(wrapped, new object[] { "Hi!", "2", "3", "4", "5", "6" });
‼33:                  this.TestContext.WriteLine($"{"big-work"}: {ret}");
〰34:              }
〰35:              {
‼36:                  var mi = wrappedType.GetMethod("more-work", BindingFlags.Public | BindingFlags.Instance);
‼37:                  var ret = mi?.Invoke(wrapped, new object[] { "Hi!" });
‼38:                  this.TestContext.WriteLine($"{"more-work"}: {ret}");
〰39:              }
〰40:              {
‼41:                  var mi = wrappedType.GetMethod("other-work", BindingFlags.Public | BindingFlags.Instance);
‼42:                  var ret = mi?.Invoke(wrapped, Array.Empty<object>());
‼43:                  this.TestContext.WriteLine($"{"other-work"}: {ret}");
〰44:              }
〰45:              {
‼46:                  var mi = wrappedType.GetMethod("and-work", BindingFlags.Public | BindingFlags.Instance);
‼47:                  var ret = mi?.Invoke(wrapped, Array.Empty<object>());
‼48:                  this.TestContext.WriteLine($"{"and-work"}: {ret}");
〰49:              }
〰50:  
‼51:          }
〰52:  
〰53:  
〰54:          public class FakeClass
〰55:          {
〰56:              [XsltFunction("big-work")]
〰57:              public string DoWork3(string x1, string x2, string x3, string x4, string x5, string x6)
〰58:              {
‼59:                  return string.Join("_", x1, x2, x3, x4, x5, x6);
〰60:              }
〰61:  
〰62:              [XsltFunction("do-work")]
‼63:              public string DoWork(string input) => input;
〰64:  
〰65:              [XsltFunction("more-work")]
〰66:              public void MoreWork(string input)
〰67:              {
〰68:                  Debug.WriteLine(input);
‼69:              }
〰70:  
〰71:              [XsltFunction("other-work")]
〰72:              public void OtherWork()
〰73:              {
〰74:                  Debug.WriteLine("hello!");
‼75:              }
〰76:  
〰77:              [XsltFunction("and-work")]
‼78:              public string AndWork() => "noice";
〰79:          }
〰80:      }
〰81:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

