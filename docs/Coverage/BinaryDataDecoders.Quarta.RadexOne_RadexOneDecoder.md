# BinaryDataDecoders.Quarta.RadexOne.RadexOneDecoder

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.RadexOneDecoder` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                 |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `16`                                                 |
| Coverablelines  | `16`                                                 |
| Totallines      | `38`                                                 |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `9`                                                  |
| Branchcoverage  | `0`                                                  |
| Coveredmethods  | `0`                                                  |
| Totalmethods    | `1`                                                  |
| Methodcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 9          | 0     | 0        | `Decode` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/RadexOneDecoder.cs

```CSharp
〰1:   using System;
〰2:   using System.Buffers;
〰3:   using System.Runtime.InteropServices;
〰4:   
〰5:   namespace BinaryDataDecoders.Quarta.RadexOne
〰6:   {
〰7:       /// <summary>
〰8:       /// used to convert buffered data to correct value type
〰9:       /// </summary>
〰10:      public class RadexOneDecoder : IRadexOneDecoder
〰11:      {
〰12:          /// <summary>
〰13:          /// used to convert buffered data to correct value type
〰14:          /// </summary>
〰15:          /// <param name="sequence">input data type</param>
〰16:          /// <returns>converted value type</returns>
〰17:          public IRadexObject Decode(ReadOnlySequence<byte> sequence)
〰18:          {
‼19:              Span<byte> data = new byte[sequence.Length];
‼20:              sequence.CopyTo(data);
‼21:              var values = MemoryMarshal.Cast<byte, ushort>(data);
〰22:  
‼23:              return values[2] switch
‼24:              {
‼25:                  0 => MemoryMarshal.Cast<byte, DevicePing>(data)[0],
‼26:                  _ => values[6] switch
‼27:                  {
‼28:                      0x00_01 => MemoryMarshal.Cast<byte, ReadSerialNumberResponse>(data)[0],
‼29:                      0x08_00 => MemoryMarshal.Cast<byte, ReadValuesResponse>(data)[0],
‼30:                      0x08_01 => MemoryMarshal.Cast<byte, ReadSettingsResponse>(data)[0],
‼31:                      0x08_02 => MemoryMarshal.Cast<byte, WriteSettingsResponse>(data)[0],
‼32:                      0x08_03 => MemoryMarshal.Cast<byte, ResetAccumulatedResponse>(data)[0],
‼33:                      _ => throw new NotSupportedException($"Object type: {values[6]: X2} unknown")
‼34:                  }
‼35:              };
〰36:          }
〰37:      }
〰38:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

