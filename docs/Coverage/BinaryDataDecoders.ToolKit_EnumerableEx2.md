# BinaryDataDecoders.ToolKit.Linq.EnumerableEx

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Linq.EnumerableEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                   |
| Coveredlines    | `0`                                            |
| Uncoveredlines  | `9`                                            |
| Coverablelines  | `9`                                            |
| Totallines      | `29`                                           |
| Linecoverage    | `0`                                            |
| Coveredbranches | `0`                                            |
| Totalbranches   | `4`                                            |
| Branchcoverage  | `0`                                            |
| Coveredmethods  | `0`                                            |
| Totalmethods    | `2`                                            |
| Methodcoverage  | `0`                                            |

## Metrics

| Complexity | Lines | Branches | Name      |
| :--------- | :---- | :------- | :-------- |
| 1          | 0     | 100      | `cctor`   |
| 4          | 0     | 0        | `Shuffle` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Linq/EnumerableEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Linq
〰6:   {
〰7:       public static class EnumerableEx
〰8:       {
‼9:           private static Random RandomGenerator { get; } = new Random();
〰10:  
〰11:          public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random? randomGenerator = null)
〰12:          {
‼13:              if (randomGenerator == null)
‼14:                  randomGenerator = EnumerableEx.RandomGenerator;
〰15:  
〰16:              //http://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle -algorithm
‼17:              var elements = source.ToArray();
‼18:              for (int i = elements.Length - 1; i >= 0; i--)
〰19:              {
〰20:                  // Swap element "i" with a random earlier element it (or itself)
〰21:                  // ... except we don't really need to swap it fully, as we can
〰22:                  // return it immediately, and afterwards it's irrelevant.
‼23:                  var swapIndex = randomGenerator.Next(i + 1);
‼24:                  yield return elements[swapIndex];
‼25:                  elements[swapIndex] = elements[i];
〰26:              }
‼27:          }
〰28:      }
〰29:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

