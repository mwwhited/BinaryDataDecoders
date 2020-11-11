# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.Favero.FaveroTestDataExtractor

## Summary

| Key             | Value                                                                                       |
| :-------------- | :------------------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.Favero.FaveroTestDataExtractor` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests`                                |
| Coveredlines    | `0`                                                                                         |
| Uncoveredlines  | `17`                                                                                        |
| Coverablelines  | `17`                                                                                        |
| Totallines      | `51`                                                                                        |
| Linecoverage    | `0`                                                                                         |
| Coveredbranches | `0`                                                                                         |
| Totalbranches   | `12`                                                                                        |
| Branchcoverage  | `0`                                                                                         |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `get_TestContext`   |
| 12         | 0     | 0        | `TestDataExtractor` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests\Favero\FaveroTestDataExtractor.cs

```CSharp
〰1:   using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.IO;
〰6:   using System.Linq;
〰7:   using static BinaryDataDecoders.ToolKit.DelimiterOptions;
〰8:   
〰9:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.Favero
〰10:  {
〰11:      [TestClass]
〰12:      public class FaveroTestDataExtractor
〰13:      {
‼14:          public TestContext TestContext { get; set; }
〰15:  
〰16:          [TestMethod, Ignore]
〰17:          public void TestDataExtractor()
〰18:          {
‼19:              var path = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\Favero\RawData.txt";
〰20:  
‼21:              var chunks = File.ReadAllText(path)
‼22:                               .Where(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f'))
‼23:                               .AsMemory()
‼24:                               .BytesFromHexString()
‼25:                               .Split(0xff, Carry)
‼26:                               ;
〰27:  
〰28:              //var segments = (from c in chunks
〰29:              //                select c.ToArray().ToHexString(",0x"))
〰30:              //               .Distinct()
〰31:              //               .OrderBy(i => i)
〰32:              //               .Aggregate(new StringBuilder(), (sb, v) => sb.Append("0x").Append(v).AppendLine())
〰33:              //               .ToString();
〰34:              // this.TestContext.WriteLine(segments);
〰35:  
‼36:              var parser = new FaveroStateParser();
‼37:              foreach (var c in chunks.Distinct())
〰38:              {
〰39:                  try
〰40:                  {
‼41:                      var state = parser.Parse(c.Span);
‼42:                      this.TestContext.WriteLine(state.ToString());
‼43:                  }
‼44:                  catch
〰45:                  {
‼46:                      this.TestContext.WriteLine($"ERROR Decoding {c.ToArray().ToHexString()}");
‼47:                  }
〰48:              }
‼49:          }
〰50:      }
〰51:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

