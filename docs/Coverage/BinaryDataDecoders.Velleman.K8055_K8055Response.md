# BinaryDataDecoders.Velleman.K8055.K8055Response

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.Velleman.K8055.K8055Response` |
| Assembly        | `BinaryDataDecoders.Velleman.K8055`               |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `12`                                              |
| Coverablelines  | `12`                                              |
| Totallines      | `43`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Velleman.K8055/K8055Response.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Velleman.K8055
〰5:   {
〰6:       [StructLayout(LayoutKind.Explicit, Size = 9)]
〰7:   #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰8:       public struct K8055Response : IK8055Object
〰9:       {
〰10:          // 00-00-04-04-fd-0a-00-0b-00
〰11:          [FieldOffset(0)]
〰12:          public byte ReportId;
〰13:          [FieldOffset(1)]
〰14:          public DigitalInputs DigitalInputs;
〰15:          [FieldOffset(2)]
〰16:          public byte Reserved2;
〰17:          [FieldOffset(3)]
〰18:          public byte Analog1;
〰19:          [FieldOffset(4)]
〰20:          public byte Analog2;
〰21:          [FieldOffset(5)]
〰22:          public ushort Counter1;
〰23:          [FieldOffset(6)]
〰24:          public byte Reserved6;
〰25:          [FieldOffset(7)]
〰26:          public ushort Counter2;
〰27:          [FieldOffset(8)]
〰28:          public byte Reserved8;
〰29:  
‼30:          public override string ToString() => new
‼31:          {
‼32:              ReportId,
‼33:              DigitalInputs,
‼34:              Reserved2,
‼35:              Analog1,
‼36:              Analog2,
‼37:              Counter1,
‼38:              Reserved6,
‼39:              Counter2,
‼40:              Reserved8,
‼41:          }.ToString();
〰42:      }
〰43:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

