# BinaryDataDecoders.Drawing.MultiScaleImages.MultiScaleTileEx

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.MultiScaleImages.MultiScaleTileEx` |
| Assembly        | `BinaryDataDecoders.Drawing`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `128`                                                          |
| Coverablelines  | `128`                                                          |
| Totallines      | `235`                                                          |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `6`                                                            |
| Branchcoverage  | `0`                                                            |
| Coveredmethods  | `0`                                                            |
| Totalmethods    | `15`                                                           |
| Methodcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `GetMaxLevel`     |
| 1          | 0     | 100      | `GetTileCount`    |
| 1          | 0     | 100      | `GetTileAsBytes`  |
| 1          | 0     | 100      | `GetTileAsStream` |
| 1          | 0     | 100      | `GetTile`         |
| 1          | 0     | 100      | `GetMaxLevel`     |
| 1          | 0     | 100      | `GetTileCount`    |
| 1          | 0     | 100      | `GetTileAsBytes`  |
| 1          | 0     | 100      | `GetTileAsStream` |
| 1          | 0     | 100      | `GetTile`         |
| 1          | 0     | 100      | `GetMaxLevel`     |
| 1          | 0     | 100      | `GetTileCount`    |
| 1          | 0     | 100      | `GetTileAsBytes`  |
| 1          | 0     | 100      | `GetTileAsStream` |
| 6          | 0     | 0        | `GetTile`         |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing/MultiScaleImages/MultiScaleTileEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Drawing;
〰3:   using System.Drawing.Imaging;
〰4:   using System.IO;
〰5:   
〰6:   namespace BinaryDataDecoders.Drawing.MultiScaleImages;
〰7:   
〰8:   public static class MultiScaleTileEx
〰9:   {
〰10:      public const int DefaultTileSize = 256;
〰11:  
〰12:      public static double GetMaxLevel(this string imagePath)
〰13:      {
‼14:          using var bitmap = new Bitmap(imagePath);
‼15:          return bitmap.Size.MaxLevel();
‼16:      }
〰17:      public static Size GetTileCount(this string imagePath,
〰18:                                        int level,
〰19:                                        int tileSize = MultiScaleTileEx.DefaultTileSize)
〰20:      {
‼21:          using var bitmap = new Bitmap(imagePath);
‼22:          var maxLevel = bitmap.Size.MaxLevel();
‼23:          var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);
〰24:  
‼25:          var scaled = new
‼26:          {
‼27:              Width = (double)bitmap.Size.Width * scalingFactor,
‼28:              Height = (double)bitmap.Size.Height * scalingFactor,
‼29:          };
‼30:          var tiles = new
‼31:          {
‼32:              Width = scaled.Width / (double)tileSize,
‼33:              Height = scaled.Height / (double)tileSize,
‼34:          };
‼35:          var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
‼36:          return tileCounts;
‼37:      }
〰38:  
〰39:      public static byte[] GetTileAsBytes(this string imagePath,
〰40:                                  int level, int x, int y,
〰41:                                  int tileSize = MultiScaleTileEx.DefaultTileSize)
〰42:      {
‼43:          using var outStream = new MemoryStream();
‼44:          using var tile = MultiScaleTileEx.GetTile(imagePath, level, x, y, tileSize);
‼45:          tile.Save(outStream, ImageFormat.Jpeg);
‼46:          return outStream.ToArray();
‼47:      }
〰48:  
〰49:      public static Stream GetTileAsStream(this string imagePath,
〰50:                                  int level, int x, int y,
〰51:                                  int tileSize = MultiScaleTileEx.DefaultTileSize)
〰52:      {
‼53:          var outStream = new MemoryStream();
‼54:          using (var tile = MultiScaleTileEx.GetTile(imagePath, level, x, y, tileSize))
〰55:          {
‼56:              tile.Save(outStream, ImageFormat.Jpeg);
‼57:          }
‼58:          outStream.Position = 0;
‼59:          return outStream;
〰60:      }
〰61:      public static Image GetTile(this string imagePath,
〰62:                                  int level, int x, int y,
〰63:                                  int tileSize = MultiScaleTileEx.DefaultTileSize)
〰64:      {
‼65:          using var bitmap = new Bitmap(imagePath);
‼66:          var outStream = new MemoryStream();
〰67:  
‼68:          var tile = bitmap.GetTile(level, x, y, tileSize);
‼69:          return tile;
‼70:      }
〰71:  
〰72:      public static double GetMaxLevel(this Stream imageStream)
〰73:      {
‼74:          using var bitmap = new Bitmap(imageStream);
‼75:          return bitmap.Size.MaxLevel();
‼76:      }
〰77:  
〰78:      public static Size GetTileCount(this Stream imageStream,
〰79:                                        int level,
〰80:                                        int tileSize = MultiScaleTileEx.DefaultTileSize)
〰81:      {
‼82:          using var bitmap = new Bitmap(imageStream);
‼83:          var maxLevel = bitmap.Size.MaxLevel();
‼84:          var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);
〰85:  
‼86:          var scaled = new
‼87:          {
‼88:              Width = (double)bitmap.Size.Width * scalingFactor,
‼89:              Height = (double)bitmap.Size.Height * scalingFactor,
‼90:          };
‼91:          var tiles = new
‼92:          {
‼93:              Width = scaled.Width / (double)tileSize,
‼94:              Height = scaled.Height / (double)tileSize,
‼95:          };
‼96:          var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
‼97:          return tileCounts;
‼98:      }
〰99:      public static byte[] GetTileAsBytes(this Stream imageStream,
〰100:                                 int level, int x, int y,
〰101:                                 int tileSize = MultiScaleTileEx.DefaultTileSize)
〰102:     {
‼103:         using var outStream = new MemoryStream();
‼104:         using var tile = MultiScaleTileEx.GetTile(imageStream, level, x, y, tileSize);
‼105:         tile.Save(outStream, ImageFormat.Jpeg);
‼106:         return outStream.ToArray();
‼107:     }
〰108: 
〰109:     public static Stream GetTileAsStream(this Stream imageStream,
〰110:                                 int level, int x, int y,
〰111:                                 int tileSize = MultiScaleTileEx.DefaultTileSize)
〰112:     {
‼113:         var outStream = new MemoryStream();
‼114:         using (var tile = MultiScaleTileEx.GetTile(imageStream, level, x, y, tileSize))
〰115:         {
‼116:             tile.Save(outStream, ImageFormat.Jpeg);
‼117:         }
‼118:         outStream.Position = 0;
‼119:         return outStream;
〰120:     }
〰121:     public static Image GetTile(this Stream imageStream,
〰122:                                 int level, int x, int y,
〰123:                                 int tileSize = MultiScaleTileEx.DefaultTileSize)
〰124:     {
‼125:         using var bitmap = new Bitmap(imageStream);
‼126:         var outStream = new MemoryStream();
〰127: 
‼128:         var tile = bitmap.GetTile(level, x, y, tileSize);
‼129:         return tile;
‼130:     }
〰131: 
〰132:     public static double GetMaxLevel(this Image image)
〰133:     {
‼134:         return image.Size.MaxLevel();
〰135:     }
〰136: 
〰137: 
〰138:     public static Size GetTileCount(this Image image,
〰139:                                       int level,
〰140:                                       int tileSize = MultiScaleTileEx.DefaultTileSize)
〰141:     {
‼142:         using var bitmap = new Bitmap(image);
‼143:         var maxLevel = bitmap.Size.MaxLevel();
‼144:         var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);
〰145: 
‼146:         var scaled = new
‼147:         {
‼148:             Width = (double)bitmap.Size.Width * scalingFactor,
‼149:             Height = (double)bitmap.Size.Height * scalingFactor,
‼150:         };
‼151:         var tiles = new
‼152:         {
‼153:             Width = scaled.Width / (double)tileSize,
‼154:             Height = scaled.Height / (double)tileSize,
‼155:         };
‼156:         var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
‼157:         return tileCounts;
‼158:     }
〰159:     public static byte[] GetTileAsBytes(this Image image,
〰160:                                 int level, int x, int y,
〰161:                                 int tileSize = MultiScaleTileEx.DefaultTileSize)
〰162:     {
‼163:         using var outStream = new MemoryStream();
‼164:         using var tile = MultiScaleTileEx.GetTile(image, level, x, y, tileSize);
‼165:         tile.Save(outStream, ImageFormat.Jpeg);
‼166:         return outStream.ToArray();
‼167:     }
〰168: 
〰169:     public static Stream GetTileAsStream(this Image image,
〰170:                                 int level, int x, int y,
〰171:                                 int tileSize = MultiScaleTileEx.DefaultTileSize)
〰172:     {
‼173:         var outStream = new MemoryStream();
‼174:         using (var tile = MultiScaleTileEx.GetTile(image, level, x, y, tileSize))
〰175:         {
‼176:             tile.Save(outStream, ImageFormat.Jpeg);
‼177:         }
‼178:         outStream.Position = 0;
‼179:         return outStream;
〰180:     }
〰181: 
〰182:     public static Image GetTile(this Image image,
〰183:                                 int level, int x, int y,
〰184:                                 int tileSize = MultiScaleTileEx.DefaultTileSize)
〰185:     {
‼186:         var point = new Point(x, y);
〰187: 
‼188:         var maxLevel = image.Size.MaxLevel();
‼189:         var maxLevelLength = Math.Pow(2, maxLevel);
‼190:         var maxLevelSize = new Size((int)maxLevelLength, (int)maxLevelLength);
〰191: 
‼192:         var levelLength = Math.Pow(2, level);
‼193:         var levelScale = (double)tileSize / levelLength;
〰194: 
‼195:         var imageScale = levelLength / maxLevelLength;
‼196:         var imageScaledSize = image.Size.Scale(imageScale);
‼197:         var imageOffset = point.OffSetBy(imageScaledSize);
〰198: 
‼199:         if (levelScale < 1)
〰200:         {
‼201:             var subTileSize = new Size(tileSize, tileSize);
‼202:             var extractSize = maxLevelSize.Scale(levelScale);
‼203:             var extractPoint = point.OffSetBy(extractSize);
‼204:             var extractBlock = new Rectangle(extractPoint, extractSize);
〰205: 
‼206:             Bitmap? subTileImage = null;
〰207:             try
〰208:             {
‼209:                 subTileImage = new Bitmap(subTileSize.Width, subTileSize.Height);
〰210: 
‼211:                 if ((subTileImage.PixelFormat & PixelFormat.Indexed) != 0)
‼212:                     throw new NotSupportedException("sorry this file format is not supported at this time");
〰213: 
‼214:                 using var graphic = Graphics.FromImage(subTileImage);
‼215:                 graphic.DrawImage(
‼216:                         image,
‼217:                         new Rectangle(0, 0, subTileImage.Width, subTileImage.Height),
‼218:                         extractBlock,
‼219:                         GraphicsUnit.Pixel);
‼220:             }
‼221:             catch
〰222:             {
〰223:                 // Don't want to leave any extra windows GDI handles laying around.
‼224:                 subTileImage?.Dispose();
‼225:                 throw;
〰226:             }
〰227: 
‼228:             return subTileImage;
〰229:         }
〰230:         else
〰231:         {
‼232:             return new Bitmap(image, imageScaledSize);
〰233:         }
〰234:     }
〰235: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

