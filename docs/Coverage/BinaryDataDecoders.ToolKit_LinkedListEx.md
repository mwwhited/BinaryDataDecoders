# BinaryDataDecoders.ToolKit.Collections.LinkedListEx

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.LinkedListEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                          |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `6`                                                   |
| Coverablelines  | `6`                                                   |
| Totallines      | `19`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `6`                                                   |
| Branchcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 6          | 0     | 0        | `AsEnumerableReversed` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Collections/LinkedListEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Collections
〰4:   {
〰5:       public static class LinkedListEx
〰6:       {
〰7:           public static IEnumerable<T> AsEnumerableReversed<T>(this LinkedList<T> current)
〰8:           {
‼9:               var item = current.Last;
‼10:              if (item == null) yield break;
〰11:              do
〰12:              {
‼13:                  yield return item.Value;
‼14:                  item = item.Previous;
〰15:              }
‼16:              while (item?.Previous != null);
‼17:          }
〰18:      }
〰19:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

