# BinaryDataDecoders.IO.Functions.ChecksumCalculator

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Functions.ChecksumCalculator` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                 |
| Coveredlines    | `4`                                                  |
| Uncoveredlines  | `4`                                                  |
| Coverablelines  | `8`                                                  |
| Totallines      | `49`                                                 |
| Linecoverage    | `50`                                                 |
| Coveredbranches | `2`                                                  |
| Totalbranches   | `4`                                                  |
| Branchcoverage  | `50`                                                 |
| Coveredmethods  | `1`                                                  |
| Totalmethods    | `2`                                                  |
| Methodcoverage  | `50`                                                 |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 2          | 0     | 0        | `Simple16` |
| 2          | 100   | 100      | `Simple16` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Functions/ChecksumCalculator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Functions;
〰4:   
〰5:   /// <summary>
〰6:   /// This class contains various checksum calculation algorithms
〰7:   /// </summary>
〰8:   public class ChecksumCalculator : IChecksumCalculator
〰9:   {
〰10:      /// <summary>
〰11:      /// I'm not really sure is there is a &quot;proper&quot; name for this algorithm.
〰12:      ///
〰13:      /// Difference of all values in Span&lt;ushort&gt;
〰14:      /// </summary>
〰15:      /// <param name="buffer">input span to calculate span over. </param>
〰16:      /// <returns>checksum value</returns>
〰17:      public ushort Simple16(ReadOnlySpan<ushort> buffer)
〰18:      {
‼19:          int sum = -1;
‼20:          foreach (var term in buffer)
‼21:              sum -= term;
‼22:          return (ushort)(sum % 0xffff);
〰23:      }
〰24:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.IO.Abstractions/Functions/ChecksumCalculator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Functions;
〰4:   
〰5:   /// <summary>
〰6:   /// This class contains various checksum calculation algorithms
〰7:   /// </summary>
〰8:   public class ChecksumCalculator : IChecksumCalculator
〰9:   {
〰10:      /// <summary>
〰11:      /// I'm not really sure is there is a &quot;proper&quot; name for this algorithm.
〰12:      ///
〰13:      /// Difference of all values in Span&lt;ushort&gt;
〰14:      /// </summary>
〰15:      /// <param name="buffer">input span to calculate span over. </param>
〰16:      /// <returns>checksum value</returns>
〰17:      public ushort Simple16(ReadOnlySpan<ushort> buffer)
〰18:      {
✔19:          int sum = -1;
✔20:          foreach (var term in buffer)
✔21:              sum -= term;
✔22:          return (ushort)(sum % 0xffff);
〰23:      }
〰24:  }
〰25:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

