# BinaryDataDecoders.ToolKit.Linq.EnumerableEx

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Linq.EnumerableEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                   |
| Coveredlines    | `0`                                            |
| Uncoveredlines  | `16`                                           |
| Coverablelines  | `16`                                           |
| Totallines      | `55`                                           |
| Linecoverage    | `0`                                            |
| Coveredbranches | `0`                                            |
| Totalbranches   | `8`                                            |
| Branchcoverage  | `0`                                            |
| Coveredmethods  | `0`                                            |
| Totalmethods    | `4`                                            |
| Methodcoverage  | `0`                                            |

## Metrics

| Complexity | Lines | Branches | Name      |
| :--------- | :---- | :------- | :-------- |
| 1          | 0     | 100      | `cctor`   |
| 4          | 0     | 0        | `Shuffle` |
| 1          | 0     | 100      | `cctor`   |
| 4          | 0     | 0        | `Shuffle` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Linq/EnumerableEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Linq;
〰6:   
〰7:   public static class EnumerableEx
〰8:   {
‼9:       private static Random RandomGenerator { get; } = new Random();
〰10:  
〰11:      public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random? randomGenerator = null)
〰12:      {
‼13:          randomGenerator ??= EnumerableEx.RandomGenerator;
〰14:  
〰15:          //http://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle -algorithm
‼16:          var elements = source.ToArray();
‼17:          for (int i = elements.Length - 1; i >= 0; i--)
〰18:          {
〰19:              // Swap element "i" with a random earlier element it (or itself)
〰20:              // ... except we don't really need to swap it fully, as we can
〰21:              // return it immediately, and afterwards it's irrelevant.
‼22:              var swapIndex = randomGenerator.Next(i + 1);
‼23:              yield return elements[swapIndex];
‼24:              elements[swapIndex] = elements[i];
〰25:          }
‼26:      }
〰27:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Linq/EnumerableEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Linq;
〰6:   
〰7:   public static class EnumerableEx
〰8:   {
‼9:       private static Random RandomGenerator { get; } = new Random();
〰10:  
〰11:      public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random? randomGenerator = null)
〰12:      {
‼13:          randomGenerator ??= EnumerableEx.RandomGenerator;
〰14:  
〰15:          //http://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle -algorithm
‼16:          var elements = source.ToArray();
‼17:          for (int i = elements.Length - 1; i >= 0; i--)
〰18:          {
〰19:              // Swap element "i" with a random earlier element it (or itself)
〰20:              // ... except we don't really need to swap it fully, as we can
〰21:              // return it immediately, and afterwards it's irrelevant.
‼22:              var swapIndex = randomGenerator.Next(i + 1);
‼23:              yield return elements[swapIndex];
‼24:              elements[swapIndex] = elements[i];
〰25:          }
‼26:      }
〰27:  }
〰28:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

