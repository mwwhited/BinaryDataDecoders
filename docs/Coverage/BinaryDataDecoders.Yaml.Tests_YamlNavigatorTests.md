# BinaryDataDecoders.Yaml.Tests.YamlNavigatorTests

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.Yaml.Tests.YamlNavigatorTests` |
| Assembly        | `BinaryDataDecoders.Yaml.Tests`                    |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `5`                                                |
| Coverablelines  | `5`                                                |
| Totallines      | `24`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `0`                                                |
| Coveredmethods  | `0`                                                |
| Totalmethods    | `1`                                                |
| Methodcoverage  | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `ToNavigableTest` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Yaml.Tests/YamlNavigatorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System.IO;
〰5:   
〰6:   namespace BinaryDataDecoders.Yaml.Tests;
〰7:   
〰8:   [TestClass]
〰9:   public class YamlNavigatorTests
〰10:  {
〰11:      public TestContext TestContext { get; set; }
〰12:  
〰13:      [DataTestMethod, TestCategory(TestCategories.DevLocal)]
〰14:      [DataRow("Example.yml")]
〰15:      [DataRow("dotnet-core.yml")]
〰16:      //[DataRow("codeql-analysis.yml")]
〰17:      public void ToNavigableTest(string resourceName)
〰18:      {
‼19:          var nav = new YamlNavigator();
‼20:          var stream = this.GetResourceStream(resourceName);
‼21:          var xpath = nav.ToNavigable(stream).CreateNavigator();
‼22:          this.TestContext.AddResult(xpath, Path.ChangeExtension(resourceName, ".xml"));
‼23:      }
〰24:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

