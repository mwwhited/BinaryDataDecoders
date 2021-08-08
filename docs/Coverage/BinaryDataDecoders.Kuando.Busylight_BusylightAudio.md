# BinaryDataDecoders.Kuando.Busylight.BusylightAudio

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Kuando.Busylight.BusylightAudio` |
| Assembly        | `BinaryDataDecoders.Kuando.Busylight`                |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `5`                                                  |
| Coverablelines  | `5`                                                  |
| Totallines      | `24`                                                 |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `0`                                                  |

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
〰3:   namespace BinaryDataDecoders.Kuando.Busylight
〰4:   {
〰5:       [StructLayout(LayoutKind.Explicit, Size = 1)]
〰6:       public struct BusylightAudio
〰7:       {
〰8:           public BusylightAudio(
〰9:               byte track,
〰10:              byte volume
〰11:              )
〰12:          {
‼13:              SoundByte = (byte)(0x80 | ((track & 0x0f) << 3) | (volume & 0x07));
‼14:          }
〰15:  
〰16:          [FieldOffset(0)]
〰17:          public byte SoundByte;
〰18:  
‼19:          public byte Track => (byte)((SoundByte >> 3) & 0x0f);
‼20:          public byte Volume => (byte)(SoundByte & 0x07);
〰21:  
‼22:          public static BusylightAudio None { get; } = new BusylightAudio();
〰23:      }
〰24:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

