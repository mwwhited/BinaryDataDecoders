# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.SaintGeorge.SqTestDataExtractor

## Summary

| Key             | Value                                                                                        |
| :-------------- | :------------------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.SaintGeorge.SqTestDataExtractor` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests`                                 |
| Coveredlines    | `0`                                                                                          |
| Uncoveredlines  | `13`                                                                                         |
| Coverablelines  | `13`                                                                                         |
| Totallines      | `39`                                                                                         |
| Linecoverage    | `0`                                                                                          |
| Coveredbranches | `0`                                                                                          |
| Totalbranches   | `0`                                                                                          |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `get_TestContext`   |
| 1          | 0     | 100      | `TestDataExtractor` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests/SaintGeorge/SqTestDataExtractor.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.IO;
〰6:   using System.Linq;
〰7:   using System.Text;
〰8:   
〰9:   using static BinaryDataDecoders.IO.Bytes;
〰10:  using static BinaryDataDecoders.ToolKit.DelimiterOptions;
〰11:  
〰12:  namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.SaintGeorge
〰13:  {
〰14:      [TestClass]
〰15:      public class SqTestDataExtractor
〰16:      {
‼17:          public TestContext TestContext { get; set; }
〰18:  
〰19:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰20:          [Ignore]
〰21:          public void TestDataExtractor()
〰22:          {
‼23:              var path = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\SaintGeorge\outfile.bin";
‼24:              var data = File.ReadAllBytes(path);
‼25:              var memory = data.AsMemory();
〰26:  
‼27:              var chunks = memory.Split(delimiter: Soh, option: Carry);
〰28:  
‼29:              var segments = (from c in chunks
‼30:                              select c.ToArray().ToHexString(",0x"))
‼31:                             .Distinct()
‼32:                             .OrderBy(i => i)
‼33:                             .Aggregate(new StringBuilder(), (sb, v) => sb.Append("0x").Append(v).AppendLine())
‼34:                             .ToString();
‼35:              this.TestContext.WriteLine(segments);
〰36:  
‼37:          }
〰38:      }
〰39:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

