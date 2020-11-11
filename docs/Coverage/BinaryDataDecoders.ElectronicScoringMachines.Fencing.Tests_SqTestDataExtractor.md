# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.SaintGeorge.SqTestDataExtractor

## Summary

| Key             | Value                                                                                        |
| :-------------- | :------------------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.SaintGeorge.SqTestDataExtractor` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests`                                 |
| Coveredlines    | `0`                                                                                          |
| Uncoveredlines  | `13`                                                                                         |
| Coverablelines  | `13`                                                                                         |
| Totallines      | `37`                                                                                         |
| Linecoverage    | `0`                                                                                          |
| Coveredbranches | `0`                                                                                          |
| Totalbranches   | `0`                                                                                          |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `get_TestContext`   |
| 1          | 0     | 100      | `TestDataExtractor` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests\SaintGeorge\SqTestDataExtractor.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.IO;
〰5:   using System.Linq;
〰6:   using System.Text;
〰7:   
〰8:   using static BinaryDataDecoders.ToolKit.Bytes;
〰9:   using static BinaryDataDecoders.ToolKit.DelimiterOptions;
〰10:  
〰11:  namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.SaintGeorge
〰12:  {
〰13:      [TestClass]
〰14:      public class SqTestDataExtractor
〰15:      {
‼16:          public TestContext TestContext { get; set; }
〰17:  
〰18:          [TestMethod, Ignore]
〰19:          public void TestDataExtractor()
〰20:          {
‼21:              var path = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\SaintGeorge\outfile.bin";
‼22:              var data = File.ReadAllBytes(path);
‼23:              var memory = data.AsMemory();
〰24:  
‼25:              var chunks = memory.Split(delimiter: Soh, option: Carry);
〰26:  
‼27:              var segments = (from c in chunks
‼28:                              select c.ToArray().ToHexString(",0x"))
‼29:                             .Distinct()
‼30:                             .OrderBy(i => i)
‼31:                             .Aggregate(new StringBuilder(), (sb, v) => sb.Append("0x").Append(v).AppendLine())
‼32:                             .ToString();
‼33:              this.TestContext.WriteLine(segments);
〰34:  
‼35:          }
〰36:      }
〰37:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

