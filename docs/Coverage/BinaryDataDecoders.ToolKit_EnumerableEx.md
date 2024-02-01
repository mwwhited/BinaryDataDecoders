# BinaryDataDecoders.ToolKit.Collections.EnumerableEx

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.EnumerableEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                          |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `4`                                                   |
| Coverablelines  | `4`                                                   |
| Totallines      | `49`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `0`                                                   |
| Coveredmethods  | `0`                                                   |
| Totalmethods    | `4`                                                   |
| Methodcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 1          | 0     | 100      | `GetReversibleEnumerator`  |
| 1          | 0     | 100      | `MakeReversibleEnumerator` |
| 1          | 0     | 100      | `GetReversibleEnumerator`  |
| 1          | 0     | 100      | `MakeReversibleEnumerator` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Collections/EnumerableEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Collections;
〰4:   
〰5:   /// <summary>
〰6:   /// Custom extensions for IEnumerable
〰7:   /// </summary>
〰8:   public static class EnumerableEx
〰9:   {
〰10:      /// <summary>
〰11:      /// expose IEnumerable a reversible enumerator
〰12:      /// </summary>
〰13:      /// <typeparam name="T"></typeparam>
〰14:      /// <param name="enumerable"></param>
〰15:      /// <returns></returns>
‼16:      public static IReversibleEnumerator<T> GetReversibleEnumerator<T>(this IEnumerable<T> enumerable) => new ReversableEnumerator<T>(enumerable);
〰17:      /// <summary>
〰18:      /// convert enumerator to a reversible enumerator
〰19:      /// </summary>
〰20:      /// <typeparam name="T"></typeparam>
〰21:      /// <param name="enumerator"></param>
〰22:      /// <returns></returns>
‼23:      public static IReversibleEnumerator<T> MakeReversibleEnumerator<T>(this IEnumerator<T> enumerator) => new ReversableEnumerator<T>(enumerator);
〰24:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Collections/EnumerableEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Collections;
〰4:   
〰5:   /// <summary>
〰6:   /// Custom extensions for IEnumerable
〰7:   /// </summary>
〰8:   public static class EnumerableEx
〰9:   {
〰10:      /// <summary>
〰11:      /// expose IEnumerable a reversible enumerator
〰12:      /// </summary>
〰13:      /// <typeparam name="T"></typeparam>
〰14:      /// <param name="enumerable"></param>
〰15:      /// <returns></returns>
‼16:      public static IReversibleEnumerator<T> GetReversibleEnumerator<T>(this IEnumerable<T> enumerable) => new ReversableEnumerator<T>(enumerable);
〰17:      /// <summary>
〰18:      /// convert enumerator to a reversible enumerator
〰19:      /// </summary>
〰20:      /// <typeparam name="T"></typeparam>
〰21:      /// <param name="enumerator"></param>
〰22:      /// <returns></returns>
‼23:      public static IReversibleEnumerator<T> MakeReversibleEnumerator<T>(this IEnumerator<T> enumerator) => new ReversableEnumerator<T>(enumerator);
〰24:  }
〰25:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

