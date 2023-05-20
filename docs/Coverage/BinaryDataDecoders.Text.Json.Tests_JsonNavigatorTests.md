# BinaryDataDecoders.Text.Json.Tests.JsonNavigatorTests

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Text.Json.Tests.JsonNavigatorTests` |
| Assembly        | `BinaryDataDecoders.Text.Json.Tests`                    |
| Coveredlines    | `18`                                                    |
| Uncoveredlines  | `0`                                                     |
| Coverablelines  | `18`                                                    |
| Totallines      | `49`                                                    |
| Linecoverage    | `100`                                                   |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `0`                                                     |
| Coveredmethods  | `1`                                                     |
| Totalmethods    | `1`                                                     |
| Methodcoverage  | `100`                                                   |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 100   | 100      | `JsonNavigatorTest` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Json.Tests/JsonNavigatorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System.Text.Json;
〰4:   
〰5:   namespace BinaryDataDecoders.Text.Json.Tests
〰6:   {
〰7:       [TestClass]
〰8:       public class JsonNavigatorTests
〰9:       {
〰10:          public TestContext TestContext { get; set; }
〰11:  
〰12:          [TestMethod]
〰13:          [TestCategory(TestCategories.Unit)]
〰14:          [TestTarget(typeof(JsonNavigatorFactory), Member = nameof(JsonNavigatorFactory.ToNavigable))]
〰15:          public void JsonNavigatorTest()
〰16:          {
✔17:              var fs = @"{""r"":123,""o"":{""f"":""v""}}";
✔18:              var json = JsonDocument.Parse(fs);
〰19:  
✔20:              var oNavigator = json.ToNavigable().CreateNavigator();
✔21:              oNavigator.MoveToRoot();
✔22:              this.TestContext.WriteLine(oNavigator.OuterXml);
〰23:  
✔24:              var rootName = oNavigator.Select("/");
✔25:              Assert.IsTrue(rootName.MoveNext());
✔26:              Assert.AreEqual("Object", rootName.Current.Name);
〰27:  
✔28:              var r = oNavigator.Select("/Object/r");
✔29:              Assert.IsTrue(r.MoveNext());
✔30:              Assert.AreEqual(123, r.Current.ValueAsInt);
〰31:  
✔32:              var f = oNavigator.Select("/Object/o/f");
✔33:              Assert.IsTrue(f.MoveNext());
✔34:              Assert.AreEqual("v", f.Current.Value);
〰35:  
✔36:              var fa = oNavigator.Select("/Object/o/f/@kind");
✔37:              Assert.IsTrue(fa.MoveNext());
✔38:              Assert.AreEqual("String", fa.Current.Value);
〰39:              /*
〰40:              <Object kind="Object">
〰41:                <r kind="Number">123</r>
〰42:                <o kind="Object">
〰43:                  <f kind="String">v</f>
〰44:                </o>
〰45:              </Object>
〰46:              */
✔47:          }
〰48:      }
〰49:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

