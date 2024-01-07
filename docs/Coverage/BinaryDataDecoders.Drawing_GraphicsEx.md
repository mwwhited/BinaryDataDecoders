# BinaryDataDecoders.Drawing.MultiScaleImages.GraphicsEx

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.MultiScaleImages.GraphicsEx` |
| Assembly        | `BinaryDataDecoders.Drawing`                             |
| Coveredlines    | `0`                                                      |
| Uncoveredlines  | `12`                                                     |
| Coverablelines  | `12`                                                     |
| Totallines      | `30`                                                     |
| Linecoverage    | `0`                                                      |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |
| Coveredmethods  | `0`                                                      |
| Totalmethods    | `3`                                                      |
| Methodcoverage  | `0`                                                      |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `MaxLevel` |
| 1          | 0     | 100      | `Scale`    |
| 1          | 0     | 100      | `OffSetBy` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing/MultiScaleImages/GraphicsEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Drawing;
〰3:   
〰4:   namespace BinaryDataDecoders.Drawing.MultiScaleImages;
〰5:   
〰6:   public static class GraphicsEx
〰7:   {
〰8:       public static double MaxLevel(this Size size)
〰9:       {
‼10:          var maxLength = Math.Max(size.Width, size.Height);
‼11:          var maxLevel = Math.Ceiling(Math.Log(maxLength, 2));
‼12:          return maxLevel;
〰13:      }
〰14:  
〰15:      public static Size Scale(this Size size, double factor)
〰16:      {
‼17:          var newSize = new Size(
‼18:              (int)Math.Max(1, Math.Ceiling(size.Width * factor)),
‼19:              (int)Math.Max(1, Math.Ceiling(size.Height * factor))
‼20:              );
‼21:          return newSize;
〰22:      }
〰23:      public static Point OffSetBy(this Point point, Size size)
〰24:      {
‼25:          var offsetX = (int)(point.X * size.Width);
‼26:          var offsetY = (int)(point.Y * size.Height);
‼27:          var offsetPoint = new Point(offsetX, offsetY);
‼28:          return offsetPoint;
〰29:      }
〰30:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

