# BinaryDataDecoders.Drawing.MultiScaleImages.ZOrderCurveEx

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.MultiScaleImages.ZOrderCurveEx` |
| Assembly        | `BinaryDataDecoders.Drawing`                                |
| Coveredlines    | `0`                                                         |
| Uncoveredlines  | `38`                                                        |
| Coverablelines  | `38`                                                        |
| Totallines      | `58`                                                        |
| Linecoverage    | `0`                                                         |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `0`                                                         |

## Metrics

| Complexity | Lines | Branches | Name                  |
| :--------- | :---- | :------- | :-------------------- |
| 1          | 0     | 100      | `Reduce`              |
| 1          | 0     | 100      | `Expand`              |
| 1          | 0     | 100      | `GetZOrderCurvePoint` |
| 1          | 0     | 100      | `GetZOrderCurveValue` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing/MultiScaleImages/ZOrderCurveEx.cs

```CSharp
〰1:   using System.Drawing;
〰2:   
〰3:   namespace BinaryDataDecoders.Drawing.MultiScaleImages
〰4:   {
〰5:       public static class ZOrderCurveEx
〰6:       {
〰7:           public static uint Reduce(this uint value)
〰8:           {
‼9:               return value & 0x00000001
‼10:                  | (value & 0x00000004) >> 0x1
‼11:                  | (value & 0x00000010) >> 0x2
‼12:                  | (value & 0x00000040) >> 0x3
‼13:                  | (value & 0x00000100) >> 0x4
‼14:                  | (value & 0x00000400) >> 0x5
‼15:                  | (value & 0x00001000) >> 0x6
‼16:                  | (value & 0x00004000) >> 0x7
‼17:                  | (value & 0x00010000) >> 0x8
‼18:                  | (value & 0x00040000) >> 0x9
‼19:                  | (value & 0x00100000) >> 0xA
‼20:                  | (value & 0x00400000) >> 0xB
‼21:                  | (value & 0x01000000) >> 0XC
‼22:                  | (value & 0x04000000) >> 0XD
‼23:                  | (value & 0x10000000) >> 0xE
‼24:                  | (value & 0x40000000) >> 0xF;
〰25:          }
〰26:          public static uint Expand(this uint value)
〰27:          {
‼28:              return value & 0x00000001
‼29:                  | (value & 0x00000002) << 0x1
‼30:                  | (value & 0x00000004) << 0x2
‼31:                  | (value & 0x00000008) << 0x3
‼32:                  | (value & 0x00000010) << 0x4
‼33:                  | (value & 0x00000020) << 0x5
‼34:                  | (value & 0x00000040) << 0x6
‼35:                  | (value & 0x00000080) << 0x7
‼36:                  | (value & 0x00000100) << 0x8
‼37:                  | (value & 0x00000200) << 0x9
‼38:                  | (value & 0x00000400) << 0xA
‼39:                  | (value & 0x00000800) << 0xB
‼40:                  | (value & 0x00001000) << 0XC
‼41:                  | (value & 0x00002000) << 0XD
‼42:                  | (value & 0x00004000) << 0xE
‼43:                  | (value & 0x00008000) << 0xF;
〰44:          }
〰45:          public static Point GetZOrderCurvePoint(this uint value)
〰46:          {
‼47:              return new Point(
‼48:                  (int)value.Reduce(),
‼49:                  (int)((uint)(value >> 1)).Reduce()
‼50:                  );
〰51:          }
〰52:          public static uint GetZOrderCurveValue(this Point point)
〰53:          {
‼54:              return ((uint)point.X).Expand()
‼55:                   | ((uint)point.Y).Expand() << 1;
〰56:          }
〰57:      }
〰58:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

