# BinaryDataDecoders.ToolKit.Tests.Collections.ReversableEnumeratorTests

## Summary

| Key             | Value                                                                    |
| :-------------- | :----------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Collections.ReversableEnumeratorTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                       |
| Coveredlines    | `0`                                                                      |
| Uncoveredlines  | `30`                                                                     |
| Coverablelines  | `30`                                                                     |
| Totallines      | `61`                                                                     |
| Linecoverage    | `0`                                                                      |
| Coveredbranches | `0`                                                                      |
| Totalbranches   | `24`                                                                     |
| Branchcoverage  | `0`                                                                      |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 1          | 0     | 100      | `get_TestContext`          |
| 24         | 0     | 0        | `MoveNextMovePreviousTest` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit.Tests\Collections\ReversableEnumeratorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Collections;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Tests.Collections
〰6:   {
〰7:       [TestClass]
〰8:       public class ReversableEnumeratorTests
〰9:       {
‼10:          public TestContext TestContext { get; set; }
〰11:  
〰12:          [TestMethod]
〰13:          public void MoveNextMovePreviousTest()
〰14:          {
‼15:              var set = new object[] { 1, 2, 3, 4, 5 }.GetReversibleEnumerator();
〰16:  
‼17:              var sb = new StringBuilder();
‼18:              sb.AppendLine("MoveNext>");
‼19:              while (set.MoveNext())
〰20:              {
‼21:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰22:              }
‼23:              sb.AppendLine();
‼24:              sb.AppendLine("MovePrevious>");
‼25:              while (set.MovePrevious())
〰26:              {
‼27:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰28:              }
‼29:              sb.AppendLine();
‼30:              sb.AppendLine("MoveNext>");
‼31:              while (set.MoveNext())
〰32:              {
‼33:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰34:              }
〰35:  
‼36:              sb.AppendLine();
‼37:              sb.AppendLine("Reset>");
‼38:              set.Reset();
〰39:  
‼40:              sb.AppendLine("MoveNext>");
‼41:              while (set.MoveNext())
〰42:              {
‼43:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰44:              }
‼45:              sb.AppendLine();
‼46:              sb.AppendLine("MovePrevious>");
‼47:              while (set.MovePrevious())
〰48:              {
‼49:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰50:              }
‼51:              sb.AppendLine();
‼52:              sb.AppendLine("MoveNext>");
‼53:              while (set.MoveNext())
〰54:              {
‼55:                  sb.Append(set.Current ?? "!NULL!").Append(";");
〰56:              }
〰57:  
‼58:              TestContext.WriteLine(sb.ToString());
‼59:          }
〰60:      }
〰61:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

