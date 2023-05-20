# BinaryDataDecoders.ToolKit.Tests.Collections.ReversableEnumeratorTests

## Summary

| Key             | Value                                                                    |
| :-------------- | :----------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Collections.ReversableEnumeratorTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                       |
| Coveredlines    | `0`                                                                      |
| Uncoveredlines  | `29`                                                                     |
| Coverablelines  | `29`                                                                     |
| Totallines      | `62`                                                                     |
| Linecoverage    | `0`                                                                      |
| Coveredbranches | `0`                                                                      |
| Totalbranches   | `24`                                                                     |
| Branchcoverage  | `0`                                                                      |
| Coveredmethods  | `0`                                                                      |
| Totalmethods    | `1`                                                                      |
| Methodcoverage  | `0`                                                                      |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 24         | 0     | 0        | `MoveNextMovePreviousTest` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/Collections/ReversableEnumeratorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.Collections;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System.Text;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Tests.Collections
〰7:   {
〰8:       [TestClass]
〰9:       public class ReversableEnumeratorTests
〰10:      {
〰11:          public TestContext TestContext { get; set; }
〰12:  
〰13:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰14:          public void MoveNextMovePreviousTest()
〰15:          {
‼16:              var set = new object[] { 1, 2, 3, 4, 5 }.GetReversibleEnumerator();
〰17:  
‼18:              var sb = new StringBuilder();
‼19:              sb.AppendLine("MoveNext>");
‼20:              while (set.MoveNext())
〰21:              {
‼22:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰23:              }
‼24:              sb.AppendLine();
‼25:              sb.AppendLine("MovePrevious>");
‼26:              while (set.MovePrevious())
〰27:              {
‼28:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰29:              }
‼30:              sb.AppendLine();
‼31:              sb.AppendLine("MoveNext>");
‼32:              while (set.MoveNext())
〰33:              {
‼34:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰35:              }
〰36:  
‼37:              sb.AppendLine();
‼38:              sb.AppendLine("Reset>");
‼39:              set.Reset();
〰40:  
‼41:              sb.AppendLine("MoveNext>");
‼42:              while (set.MoveNext())
〰43:              {
‼44:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰45:              }
‼46:              sb.AppendLine();
‼47:              sb.AppendLine("MovePrevious>");
‼48:              while (set.MovePrevious())
〰49:              {
‼50:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰51:              }
‼52:              sb.AppendLine();
‼53:              sb.AppendLine("MoveNext>");
‼54:              while (set.MoveNext())
〰55:              {
‼56:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰57:              }
〰58:  
‼59:              TestContext.WriteLine(sb.ToString());
‼60:          }
〰61:      }
〰62:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

