# BinaryDataDecoders.Kuando.Busylight.BusylightAudio

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Kuando.Busylight.BusylightAudio` |
| Assembly        | `BinaryDataDecoders.Kuando.Busylight`                |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `4`                                                  |
| Coverablelines  | `4`                                                  |
| Totallines      | `18`                                                 |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `0`                                                  |
| Coveredmethods  | `0`                                                  |
| Totalmethods    | `4`                                                  |
| Methodcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 0     | 100      | `ctor`       |
| 1          | 0     | 100      | `get_Track`  |
| 1          | 0     | 100      | `get_Volume` |
| 1          | 0     | 100      | `get_None`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Kuando.Busylight/BusylightAudio.cs

```CSharp
〰1:   using System.Runtime.InteropServices;
〰2:   
〰3:   namespace BinaryDataDecoders.Kuando.Busylight;
〰4:   
〰5:   [StructLayout(LayoutKind.Explicit, Size = 1)]
〰6:   public struct BusylightAudio(
〰7:       byte track,
〰8:       byte volume
〰9:           )
〰10:  {
〰11:      [FieldOffset(0)]
‼12:      public byte SoundByte = (byte)(0x80 | ((track & 0x0f) << 3) | (volume & 0x07));
〰13:  
‼14:      public readonly byte Track => (byte)((SoundByte >> 3) & 0x0f);
‼15:      public readonly byte Volume => (byte)(SoundByte & 0x07);
〰16:  
‼17:      public static BusylightAudio None => new();
〰18:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

