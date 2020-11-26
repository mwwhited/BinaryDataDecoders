# BinaryDataDecoders.Quarta.RadexOne.ResetAccumulatedResponse

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.ResetAccumulatedResponse` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                          |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `1`                                                           |
| Coverablelines  | `1`                                                           |
| Totallines      | `44`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/ResetAccumulatedResponse.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Quarta.RadexOne
〰5:   {
〰6:       /// <summary>
〰7:       /// Response from device when Reset Accumulated is requested
〰8:       /// </summary>
〰9:       [MessageMatchPattern(
〰10:          "7AFF-2080-1600-00000000-0000|0308+",
〰11:          Mask = "ffff-ffff-ffff-00000000-0000|ffff+"
〰12:          )]
〰13:      [StructLayout(LayoutKind.Explicit, Size = 18)]
〰14:      public struct ResetAccumulatedResponse : IRadexObject
〰15:      {
〰16:          // <: 7aff 2080 0600 4e01 0000 107f 0308 0000 fcf7
〰17:  
〰18:          [FieldOffset(0)]
〰19:          private readonly ushort Prefix;
〰20:          [FieldOffset(2)]
〰21:          private readonly ushort Command;
〰22:          [FieldOffset(4)]
〰23:          private readonly ushort ExtensionLength;
〰24:          /// <summary>
〰25:          /// packetnumber is returned by response and may be used for correlation.
〰26:          /// </summary>
〰27:          [FieldOffset(6)]
〰28:          public readonly uint PacketNumber;
〰29:          [FieldOffset(10)]
〰30:          private readonly ushort CheckSum0;
〰31:  
〰32:          [FieldOffset(12)]
〰33:          private readonly ushort SubCommand;
〰34:          [FieldOffset(16)]
〰35:          private readonly ushort CheckSum1;
〰36:  
〰37:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰38:          public override string ToString()
〰39:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰40:          {
‼41:              return $"Reset Accumulated:\t({PacketNumber}:0x{PacketNumber:X2})";
〰42:          }
〰43:      }
〰44:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

