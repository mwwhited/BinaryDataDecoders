# BinaryDataDecoders.ToolKit.MemoryCompare`1

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.MemoryCompare`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                 |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `4`                                          |
| Coverablelines  | `4`                                          |
| Totallines      | `35`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `4`                                          |
| Branchcoverage  | `0`                                          |
| Coveredmethods  | `0`                                          |
| Totalmethods    | `4`                                          |
| Methodcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 2          | 0     | 0        | `Equals`      |
| 1          | 0     | 100      | `GetHashCode` |
| 2          | 0     | 0        | `Equals`      |
| 1          | 0     | 100      | `GetHashCode` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/MemoryCompare.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit;
〰5:   
〰6:   /// <summary>
〰7:   /// class to suport comparing System.Memory&lt;&gt;
〰8:   /// </summary>
〰9:   /// <typeparam name="T"></typeparam>
〰10:  public class MemoryCompare<T> : IEqualityComparer<Memory<T>>
〰11:       where T : IEquatable<T>
〰12:  {
〰13:      /// <inheritdoc />
‼14:      public bool Equals(Memory<T> x, Memory<T> y) => x.Span.Length == y.Span.Length && x.Span.IndexOf(y.Span) == 0;
〰15:      /// <inheritdoc />
‼16:      public int GetHashCode(Memory<T> obj) => obj.Length;
〰17:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/MemoryCompare.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit;
〰5:   
〰6:   /// <summary>
〰7:   /// class to suport comparing System.Memory&lt;&gt;
〰8:   /// </summary>
〰9:   /// <typeparam name="T"></typeparam>
〰10:  public class MemoryCompare<T> : IEqualityComparer<Memory<T>>
〰11:       where T : IEquatable<T>
〰12:  {
〰13:      /// <inheritdoc />
‼14:      public bool Equals(Memory<T> x, Memory<T> y) => x.Span.Length == y.Span.Length && x.Span.IndexOf(y.Span) == 0;
〰15:      /// <inheritdoc />
‼16:      public int GetHashCode(Memory<T> obj) => obj.Length;
〰17:  }
〰18:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

