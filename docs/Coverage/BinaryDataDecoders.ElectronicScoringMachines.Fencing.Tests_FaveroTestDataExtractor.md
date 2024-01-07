# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.Favero.FaveroTestDataExtractor

## Summary

| Key             | Value                                                                                       |
| :-------------- | :------------------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.Favero.FaveroTestDataExtractor` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests`                                |
| Coveredlines    | `0`                                                                                         |
| Uncoveredlines  | `16`                                                                                        |
| Coverablelines  | `16`                                                                                        |
| Totallines      | `53`                                                                                        |
| Linecoverage    | `0`                                                                                         |
| Coveredbranches | `0`                                                                                         |
| Totalbranches   | `12`                                                                                        |
| Branchcoverage  | `0`                                                                                         |
| Coveredmethods  | `0`                                                                                         |
| Totalmethods    | `1`                                                                                         |
| Methodcoverage  | `0`                                                                                         |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 12         | 0     | 0        | `TestDataExtractor` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests/Favero/FaveroTestDataExtractor.cs

```CSharp
〰1:   using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using BinaryDataDecoders.ToolKit;
〰4:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰5:   using System;
〰6:   using System.IO;
〰7:   using System.Linq;
〰8:   using static BinaryDataDecoders.ToolKit.DelimiterOptions;
〰9:   
〰10:  namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.Favero;
〰11:  
〰12:  [TestClass]
〰13:  public class FaveroTestDataExtractor
〰14:  {
〰15:      public TestContext TestContext { get; set; }
〰16:  
〰17:      [TestMethod, TestCategory(TestCategories.DevLocal)]
〰18:      [Ignore]
〰19:      public void TestDataExtractor()
〰20:      {
‼21:          var path = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\Favero\RawData.txt";
〰22:  
‼23:          var chunks = File.ReadAllText(path)
‼24:                           .Where(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f'))
‼25:                           .AsMemory()
‼26:                           .BytesFromHexString()
‼27:                           .Split(0xff, Carry)
‼28:                           ;
〰29:  
〰30:          //var segments = (from c in chunks
〰31:          //                select c.ToArray().ToHexString(",0x"))
〰32:          //               .Distinct()
〰33:          //               .OrderBy(i => i)
〰34:          //               .Aggregate(new StringBuilder(), (sb, v) => sb.Append("0x").Append(v).AppendLine())
〰35:          //               .ToString();
〰36:          // this.TestContext.WriteLine(segments);
〰37:  
‼38:          var parser = new FaveroStateParser();
‼39:          foreach (var c in chunks.Distinct())
〰40:          {
〰41:              try
〰42:              {
‼43:                  var state = parser.Parse(c.Span);
‼44:                  this.TestContext.WriteLine(state.ToString());
‼45:              }
‼46:              catch
〰47:              {
‼48:                  this.TestContext.WriteLine($"ERROR Decoding {c.ToArray().ToHexString()}");
‼49:              }
〰50:          }
‼51:      }
〰52:  }
〰53:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

