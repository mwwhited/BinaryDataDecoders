# BinaryDataDecoders.Yaml.Tests.YamlNavigatorTests

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.Yaml.Tests.YamlNavigatorTests` |
| Assembly        | `BinaryDataDecoders.Yaml.Tests`                    |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `6`                                                |
| Coverablelines  | `6`                                                |
| Totallines      | `27`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 1          | 0     | 100      | `ToNavigableTest` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Yaml.Tests\YamlNavigatorTests.cs

```CSharp
〰1:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰2:   using BinaryDataDecoders.Yaml;
〰3:   using BinaryDataDecoders.TestUtilities;
〰4:   using BinaryDataDecoders.ToolKit;
〰5:   using System.Threading.Tasks;
〰6:   using System.IO;
〰7:   
〰8:   namespace BinaryDataDecoders.Yaml.Tests
〰9:   {
〰10:      [TestClass]
〰11:      public class YamlNavigatorTests
〰12:      {
‼13:          public TestContext TestContext { get; set; }
〰14:  
〰15:          [DataTestMethod]
〰16:          [DataRow("Example.yml")]
〰17:          [DataRow("dotnet-core.yml")]
〰18:          [DataRow("codeql-analysis.yml")]
〰19:          public void ToNavigableTest(string resourceName)
〰20:          {
‼21:              var nav = new YamlNavigator();
‼22:              var stream = this.GetResourceStream(resourceName);
‼23:              var xpath = nav.ToNavigable(stream).CreateNavigator();
‼24:              this.TestContext.AddResult(xpath, Path.ChangeExtension(resourceName, ".xml"));
‼25:          }
〰26:      }
〰27:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

