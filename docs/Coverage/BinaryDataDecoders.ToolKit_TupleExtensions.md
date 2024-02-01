# BinaryDataDecoders.ToolKit.Linq.TupleExtensions

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Linq.TupleExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                      |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `6`                                               |
| Coverablelines  | `6`                                               |
| Totallines      | `31`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |
| Coveredmethods  | `0`                                               |
| Totalmethods    | `6`                                               |
| Methodcoverage  | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name      |
| :--------- | :---- | :------- | :-------- |
| 1          | 0     | 100      | `ToArray` |
| 1          | 0     | 100      | `ToArray` |
| 1          | 0     | 100      | `ToList`  |
| 1          | 0     | 100      | `ToArray` |
| 1          | 0     | 100      | `ToArray` |
| 1          | 0     | 100      | `ToList`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Linq/TupleExtensions.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Runtime.CompilerServices;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Linq;
〰6:   
〰7:   public static class TupleExtensions
〰8:   {
〰9:       public static object[] ToArray(this ITuple tuple) =>
‼10:          Enumerable.Range(0, tuple.Length).Select(i => tuple[i]).ToArray();
〰11:      public static T[] ToArray<T>(this ITuple tuple) =>
‼12:          Enumerable.Range(0, tuple.Length).Select(i => (T)tuple[i]).ToArray();
〰13:      public static IReadOnlyList<T> ToList<T>(this ITuple tuple) =>
‼14:          Enumerable.Range(0, tuple.Length).Select(i => (T)tuple[i]).ToArray();
〰15:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Linq/TupleExtensions.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Runtime.CompilerServices;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Linq;
〰6:   
〰7:   public static class TupleExtensions
〰8:   {
〰9:       public static object[] ToArray(this ITuple tuple) =>
‼10:          Enumerable.Range(0, tuple.Length).Select(i => tuple[i]).ToArray();
〰11:      public static T[] ToArray<T>(this ITuple tuple) =>
‼12:          Enumerable.Range(0, tuple.Length).Select(i => (T)tuple[i]).ToArray();
〰13:      public static IReadOnlyList<T> ToList<T>(this ITuple tuple) =>
‼14:          Enumerable.Range(0, tuple.Length).Select(i => (T)tuple[i]).ToArray();
〰15:  }
〰16:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

