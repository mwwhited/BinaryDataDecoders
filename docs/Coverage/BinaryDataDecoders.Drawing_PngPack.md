# BinaryDataDecoders.Drawing.Packers.PngPack

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.Packers.PngPack` |
| Assembly        | `BinaryDataDecoders.Drawing`                 |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `28`                                         |
| Coverablelines  | `28`                                         |
| Totallines      | `49`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `0`                                          |
| Coveredmethods  | `0`                                          |
| Totalmethods    | `2`                                          |
| Methodcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 0     | 100      | `Pack`   |
| 1          | 0     | 100      | `Unpack` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing/Packers/PngPack.cs

```CSharp
〰1:   using System;
〰2:   using System.Drawing;
〰3:   using System.Drawing.Imaging;
〰4:   using System.IO;
〰5:   using System.Runtime.InteropServices;
〰6:   
〰7:   namespace BinaryDataDecoders.Drawing.Packers;
〰8:   
〰9:   public class PngPack
〰10:  {
〰11:      public byte[] Pack(byte[] input)
〰12:      {
‼13:          var length = input.Length;
‼14:          var requiredPixels = Math.Ceiling(length / 4d) + 1;
‼15:          var width = Math.Ceiling(Math.Sqrt(requiredPixels));
‼16:          var height = Math.Ceiling(requiredPixels / width);
〰17:  
‼18:          var pixelFormat = PixelFormat.Format32bppArgb;
‼19:          using var bitmap = new Bitmap((int)width, (int)height, pixelFormat);
‼20:          using var outStream = new MemoryStream();
‼21:          var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, pixelFormat);
‼22:          var ptr = bitmapData.Scan0;
‼23:          Marshal.Copy(BitConverter.GetBytes(length), 0, ptr, 4);
‼24:          Marshal.Copy(input, 0, ptr + 4, length);
〰25:  
‼26:          bitmap.UnlockBits(bitmapData);
‼27:          bitmap.Save(outStream, ImageFormat.Png);
‼28:          return outStream.ToArray();
‼29:      }
〰30:  
〰31:      public byte[] Unpack(byte[] input)
〰32:      {
‼33:          var pixelFormat = PixelFormat.Format32bppArgb;
‼34:          using var inputStream = new MemoryStream(input);
‼35:          using var bitmap = new Bitmap(inputStream);
‼36:          var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, pixelFormat);
〰37:  
‼38:          var ptr = bitmapData.Scan0;
‼39:          var lengthBuffer = new byte[4];
‼40:          Marshal.Copy(ptr, lengthBuffer, 0, 4);
‼41:          var length = BitConverter.ToInt32(lengthBuffer, 0);
‼42:          var outBuffer = new byte[length];
‼43:          Marshal.Copy(ptr + 4, outBuffer, 0, length);
〰44:  
‼45:          bitmap.UnlockBits(bitmapData);
〰46:  
‼47:          return outBuffer;
‼48:      }
〰49:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

