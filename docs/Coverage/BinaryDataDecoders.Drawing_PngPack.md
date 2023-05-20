# BinaryDataDecoders.Drawing.Packers.PngPack

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.Packers.PngPack` |
| Assembly        | `BinaryDataDecoders.Drawing`                 |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `28`                                         |
| Coverablelines  | `28`                                         |
| Totallines      | `54`                                         |
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
〰7:   namespace BinaryDataDecoders.Drawing.Packers
〰8:   {
〰9:       public class PngPack
〰10:      {
〰11:          public byte[] Pack(byte[] input)
〰12:          {
‼13:              var length = input.Length;
‼14:              var requiredPixels = Math.Ceiling(length / 4d) + 1;
‼15:              var width = Math.Ceiling(Math.Sqrt(requiredPixels));
‼16:              var height = Math.Ceiling(requiredPixels / width);
〰17:  
‼18:              var pixelFormat = PixelFormat.Format32bppArgb;
‼19:              using (var bitmap = new Bitmap((int)width, (int)height, pixelFormat))
‼20:              using (var outStream = new MemoryStream())
〰21:              {
‼22:                  var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, pixelFormat);
‼23:                  var ptr = bitmapData.Scan0;
‼24:                  Marshal.Copy(BitConverter.GetBytes(length), 0, ptr, 4);
‼25:                  Marshal.Copy(input, 0, ptr + 4, length);
〰26:  
‼27:                  bitmap.UnlockBits(bitmapData);
‼28:                  bitmap.Save(outStream, ImageFormat.Png);
‼29:                  return outStream.ToArray();
〰30:              }
‼31:          }
〰32:  
〰33:          public byte[] Unpack(byte[] input)
〰34:          {
‼35:              var pixelFormat = PixelFormat.Format32bppArgb;
‼36:              using (var inputStream = new MemoryStream(input))
‼37:              using (var bitmap = new Bitmap(inputStream))
〰38:              {
‼39:                  var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, pixelFormat);
〰40:  
‼41:                  var ptr = bitmapData.Scan0;
‼42:                  var lengthBuffer = new byte[4];
‼43:                  Marshal.Copy(ptr, lengthBuffer, 0, 4);
‼44:                  var length = BitConverter.ToInt32(lengthBuffer, 0);
‼45:                  var outBuffer = new byte[length];
‼46:                  Marshal.Copy(ptr + 4, outBuffer, 0, length);
〰47:  
‼48:                  bitmap.UnlockBits(bitmapData);
〰49:  
‼50:                  return outBuffer;
〰51:              }
‼52:          }
〰53:      }
〰54:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

