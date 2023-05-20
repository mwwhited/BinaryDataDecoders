# BinaryDataDecoders.Drawing.MultiScaleImages.MultiScaleTileEx

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.MultiScaleImages.MultiScaleTileEx` |
| Assembly        | `BinaryDataDecoders.Drawing`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `130`                                                          |
| Coverablelines  | `130`                                                          |
| Totallines      | `261`                                                          |
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
〰6:   namespace BinaryDataDecoders.Drawing.MultiScaleImages
〰7:   {
〰8:       public static class MultiScaleTileEx
〰9:       {
〰10:          public const int DefaultTileSize = 256;
〰11:  
〰12:          public static double GetMaxLevel(this string imagePath)
〰13:          {
‼14:              using (var bitmap = new Bitmap(imagePath))
〰15:              {
‼16:                  return bitmap.Size.MaxLevel();
〰17:              }
‼18:          }
〰19:          public static Size GetTileCount(this string imagePath,
〰20:                                            int level,
〰21:                                            int tileSize = MultiScaleTileEx.DefaultTileSize)
〰22:          {
‼23:              using (var bitmap = new Bitmap(imagePath))
〰24:              {
‼25:                  var maxLevel = bitmap.Size.MaxLevel();
‼26:                  var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);
〰27:  
‼28:                  var scaled = new
‼29:                  {
‼30:                      Width = (double)bitmap.Size.Width * scalingFactor,
‼31:                      Height = (double)bitmap.Size.Height * scalingFactor,
‼32:                  };
‼33:                  var tiles = new
‼34:                  {
‼35:                      Width = scaled.Width / (double)tileSize,
‼36:                      Height = scaled.Height / (double)tileSize,
‼37:                  };
‼38:                  var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
‼39:                  return tileCounts;
〰40:              }
‼41:          }
〰42:  
〰43:          public static byte[] GetTileAsBytes(this string imagePath,
〰44:                                      int level, int x, int y,
〰45:                                      int tileSize = MultiScaleTileEx.DefaultTileSize)
〰46:          {
‼47:              using (var outStream = new MemoryStream())
‼48:              using (var tile = MultiScaleTileEx.GetTile(imagePath, level, x, y, tileSize))
〰49:              {
‼50:                  tile.Save(outStream, ImageFormat.Jpeg);
‼51:                  return outStream.ToArray();
〰52:              }
‼53:          }
〰54:  
〰55:          public static Stream GetTileAsStream(this string imagePath,
〰56:                                      int level, int x, int y,
〰57:                                      int tileSize = MultiScaleTileEx.DefaultTileSize)
〰58:          {
‼59:              var outStream = new MemoryStream();
‼60:              using (var tile = MultiScaleTileEx.GetTile(imagePath, level, x, y, tileSize))
〰61:              {
‼62:                  tile.Save(outStream, ImageFormat.Jpeg);
‼63:              }
‼64:              outStream.Position = 0;
‼65:              return outStream;
〰66:          }
〰67:          public static Image GetTile(this string imagePath,
〰68:                                      int level, int x, int y,
〰69:                                      int tileSize = MultiScaleTileEx.DefaultTileSize)
〰70:          {
‼71:              using (var bitmap = new Bitmap(imagePath))
〰72:              {
‼73:                  var outStream = new MemoryStream();
〰74:  
‼75:                  var tile = bitmap.GetTile(level, x, y, tileSize);
‼76:                  return tile;
〰77:              }
‼78:          }
〰79:  
〰80:          public static double GetMaxLevel(this Stream imageStream)
〰81:          {
‼82:              using (var bitmap = new Bitmap(imageStream))
〰83:              {
‼84:                  return bitmap.Size.MaxLevel();
〰85:              }
‼86:          }
〰87:  
〰88:          public static Size GetTileCount(this Stream imageStream,
〰89:                                            int level,
〰90:                                            int tileSize = MultiScaleTileEx.DefaultTileSize)
〰91:          {
‼92:              using (var bitmap = new Bitmap(imageStream))
〰93:              {
‼94:                  var maxLevel = bitmap.Size.MaxLevel();
‼95:                  var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);
〰96:  
‼97:                  var scaled = new
‼98:                  {
‼99:                      Width = (double)bitmap.Size.Width * scalingFactor,
‼100:                     Height = (double)bitmap.Size.Height * scalingFactor,
‼101:                 };
‼102:                 var tiles = new
‼103:                 {
‼104:                     Width = scaled.Width / (double)tileSize,
‼105:                     Height = scaled.Height / (double)tileSize,
‼106:                 };
‼107:                 var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
‼108:                 return tileCounts;
〰109:             }
‼110:         }
〰111:         public static byte[] GetTileAsBytes(this Stream imageStream,
〰112:                                     int level, int x, int y,
〰113:                                     int tileSize = MultiScaleTileEx.DefaultTileSize)
〰114:         {
‼115:             using (var outStream = new MemoryStream())
‼116:             using (var tile = MultiScaleTileEx.GetTile(imageStream, level, x, y, tileSize))
〰117:             {
‼118:                 tile.Save(outStream, ImageFormat.Jpeg);
‼119:                 return outStream.ToArray();
〰120:             }
‼121:         }
〰122: 
〰123:         public static Stream GetTileAsStream(this Stream imageStream,
〰124:                                     int level, int x, int y,
〰125:                                     int tileSize = MultiScaleTileEx.DefaultTileSize)
〰126:         {
‼127:             var outStream = new MemoryStream();
‼128:             using (var tile = MultiScaleTileEx.GetTile(imageStream, level, x, y, tileSize))
〰129:             {
‼130:                 tile.Save(outStream, ImageFormat.Jpeg);
‼131:             }
‼132:             outStream.Position = 0;
‼133:             return outStream;
〰134:         }
〰135:         public static Image GetTile(this Stream imageStream,
〰136:                                     int level, int x, int y,
〰137:                                     int tileSize = MultiScaleTileEx.DefaultTileSize)
〰138:         {
‼139:             using (var bitmap = new Bitmap(imageStream))
〰140:             {
‼141:                 var outStream = new MemoryStream();
〰142: 
‼143:                 var tile = bitmap.GetTile(level, x, y, tileSize);
‼144:                 return tile;
〰145:             }
‼146:         }
〰147: 
〰148:         public static double GetMaxLevel(this Image image)
〰149:         {
‼150:             return image.Size.MaxLevel();
〰151:         }
〰152: 
〰153: 
〰154:         public static Size GetTileCount(this Image image,
〰155:                                           int level,
〰156:                                           int tileSize = MultiScaleTileEx.DefaultTileSize)
〰157:         {
‼158:             using (var bitmap = new Bitmap(image))
〰159:             {
‼160:                 var maxLevel = bitmap.Size.MaxLevel();
‼161:                 var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);
〰162: 
‼163:                 var scaled = new
‼164:                 {
‼165:                     Width = (double)bitmap.Size.Width * scalingFactor,
‼166:                     Height = (double)bitmap.Size.Height * scalingFactor,
‼167:                 };
‼168:                 var tiles = new
‼169:                 {
‼170:                     Width = scaled.Width / (double)tileSize,
‼171:                     Height = scaled.Height / (double)tileSize,
‼172:                 };
‼173:                 var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
‼174:                 return tileCounts;
〰175:             }
‼176:         }
〰177:         public static byte[] GetTileAsBytes(this Image image,
〰178:                                     int level, int x, int y,
〰179:                                     int tileSize = MultiScaleTileEx.DefaultTileSize)
〰180:         {
‼181:             using (var outStream = new MemoryStream())
‼182:             using (var tile = MultiScaleTileEx.GetTile(image, level, x, y, tileSize))
〰183:             {
‼184:                 tile.Save(outStream, ImageFormat.Jpeg);
‼185:                 return outStream.ToArray();
〰186:             }
‼187:         }
〰188: 
〰189:         public static Stream GetTileAsStream(this Image image,
〰190:                                     int level, int x, int y,
〰191:                                     int tileSize = MultiScaleTileEx.DefaultTileSize)
〰192:         {
‼193:             var outStream = new MemoryStream();
‼194:             using (var tile = MultiScaleTileEx.GetTile(image, level, x, y, tileSize))
〰195:             {
‼196:                 tile.Save(outStream, ImageFormat.Jpeg);
‼197:             }
‼198:             outStream.Position = 0;
‼199:             return outStream;
〰200:         }
〰201: 
〰202:         public static Image GetTile(this Image image,
〰203:                                     int level, int x, int y,
〰204:                                     int tileSize = MultiScaleTileEx.DefaultTileSize)
〰205:         {
‼206:             var point = new Point(x, y);
〰207: 
‼208:             var maxLevel = image.Size.MaxLevel();
‼209:             var maxLevelLength = Math.Pow(2, maxLevel);
‼210:             var maxLevelSize = new Size((int)maxLevelLength, (int)maxLevelLength);
〰211: 
‼212:             var levelLength = Math.Pow(2, level);
‼213:             var levelScale = (double)tileSize / levelLength;
〰214: 
‼215:             var imageScale = levelLength / maxLevelLength;
‼216:             var imageScaledSize = image.Size.Scale(imageScale);
‼217:             var imageOffset = point.OffSetBy(imageScaledSize);
〰218: 
‼219:             if (levelScale < 1)
〰220:             {
‼221:                 var subTileSize = new Size(tileSize, tileSize);
‼222:                 var extractSize = maxLevelSize.Scale(levelScale);
‼223:                 var extractPoint = point.OffSetBy(extractSize);
‼224:                 var extractBlock = new Rectangle(extractPoint, extractSize);
〰225: 
‼226:                 Bitmap? subTileImage = null;
〰227:                 try
〰228:                 {
‼229:                     subTileImage = new Bitmap(subTileSize.Width, subTileSize.Height);
〰230: 
‼231:                     if ((subTileImage.PixelFormat & PixelFormat.Indexed) != 0)
‼232:                         throw new NotSupportedException("sorry this file format is not supported at this time");
〰233: 
‼234:                     using (var graphic = Graphics.FromImage(subTileImage))
〰235:                     {
‼236:                         graphic.DrawImage(
‼237:                                 image,
‼238:                                 new Rectangle(0, 0, subTileImage.Width, subTileImage.Height),
‼239:                                 extractBlock,
‼240:                                 GraphicsUnit.Pixel);
‼241:                     }
‼242:                 }
‼243:                 catch
〰244:                 {
‼245:                     if (subTileImage != null)
〰246:                     {
〰247:                         // Don't want to leave any extra windows GDI handles laying around.
‼248:                         subTileImage.Dispose();
〰249:                     }
‼250:                     throw;
〰251:                 }
〰252: 
‼253:                 return subTileImage;
〰254:             }
〰255:             else
〰256:             {
‼257:                 return new Bitmap(image, imageScaledSize);
〰258:             }
〰259:         }
〰260:     }
〰261: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

