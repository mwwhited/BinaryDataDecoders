using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BinaryDataDecoders.Drawing.MultiScaleImages
{
    public static class MultiScaleTileEx
    {
        public const int DefaultTileSize = 256;

        public static double GetMaxLevel(this string imagePath)
        {
            using (var bitmap = new Bitmap(imagePath))
            {
                return bitmap.Size.MaxLevel();
            }
        }
        public static Size GetTileCount(this string imagePath,
                                          int level,
                                          int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            using (var bitmap = new Bitmap(imagePath))
            {
                var maxLevel = bitmap.Size.MaxLevel();
                var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);

                var scaled = new
                {
                    Width = (double)bitmap.Size.Width * scalingFactor,
                    Height = (double)bitmap.Size.Height * scalingFactor,
                };
                var tiles = new
                {
                    Width = scaled.Width / (double)tileSize,
                    Height = scaled.Height / (double)tileSize,
                };
                var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
                return tileCounts;
            }
        }

        public static byte[] GetTileAsBytes(this string imagePath,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            using (var outStream = new MemoryStream())
            using (var tile = MultiScaleTileEx.GetTile(imagePath, level, x, y, tileSize))
            {
                tile.Save(outStream, ImageFormat.Jpeg);
                return outStream.ToArray();
            }
        }

        public static Stream GetTileAsStream(this string imagePath,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            var outStream = new MemoryStream();
            using (var tile = MultiScaleTileEx.GetTile(imagePath, level, x, y, tileSize))
            {
                tile.Save(outStream, ImageFormat.Jpeg);
            }
            outStream.Position = 0;
            return outStream;
        }
        public static Image GetTile(this string imagePath,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            using (var bitmap = new Bitmap(imagePath))
            {
                var outStream = new MemoryStream();

                var tile = bitmap.GetTile(level, x, y, tileSize);
                return tile;
            }
        }

        public static double GetMaxLevel(this Stream imageStream)
        {
            using (var bitmap = new Bitmap(imageStream))
            {
                return bitmap.Size.MaxLevel();
            }
        }

        public static Size GetTileCount(this Stream imageStream,
                                          int level,
                                          int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            using (var bitmap = new Bitmap(imageStream))
            {
                var maxLevel = bitmap.Size.MaxLevel();
                var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);

                var scaled = new
                {
                    Width = (double)bitmap.Size.Width * scalingFactor,
                    Height = (double)bitmap.Size.Height * scalingFactor,
                };
                var tiles = new
                {
                    Width = scaled.Width / (double)tileSize,
                    Height = scaled.Height / (double)tileSize,
                };
                var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
                return tileCounts;
            }
        }
        public static byte[] GetTileAsBytes(this Stream imageStream,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            using (var outStream = new MemoryStream())
            using (var tile = MultiScaleTileEx.GetTile(imageStream, level, x, y, tileSize))
            {
                tile.Save(outStream, ImageFormat.Jpeg);
                return outStream.ToArray();
            }
        }

        public static Stream GetTileAsStream(this Stream imageStream,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            var outStream = new MemoryStream();
            using (var tile = MultiScaleTileEx.GetTile(imageStream, level, x, y, tileSize))
            {
                tile.Save(outStream, ImageFormat.Jpeg);
            }
            outStream.Position = 0;
            return outStream;
        }
        public static Image GetTile(this Stream imageStream,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            using (var bitmap = new Bitmap(imageStream))
            {
                var outStream = new MemoryStream();

                var tile = bitmap.GetTile(level, x, y, tileSize);
                return tile;
            }
        }

        public static double GetMaxLevel(this Image image)
        {
            return image.Size.MaxLevel();
        }


        public static Size GetTileCount(this Image image,
                                          int level,
                                          int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            using (var bitmap = new Bitmap(image))
            {
                var maxLevel = bitmap.Size.MaxLevel();
                var scalingFactor = Math.Pow(2, level) / Math.Pow(2, maxLevel);

                var scaled = new
                {
                    Width = (double)bitmap.Size.Width * scalingFactor,
                    Height = (double)bitmap.Size.Height * scalingFactor,
                };
                var tiles = new
                {
                    Width = scaled.Width / (double)tileSize,
                    Height = scaled.Height / (double)tileSize,
                };
                var tileCounts = new Size((int)Math.Ceiling(tiles.Width), (int)Math.Ceiling(tiles.Height));
                return tileCounts;
            }
        }
        public static byte[] GetTileAsBytes(this Image image,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            using (var outStream = new MemoryStream())
            using (var tile = MultiScaleTileEx.GetTile(image, level, x, y, tileSize))
            {
                tile.Save(outStream, ImageFormat.Jpeg);
                return outStream.ToArray();
            }
        }

        public static Stream GetTileAsStream(this Image image,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            var outStream = new MemoryStream();
            using (var tile = MultiScaleTileEx.GetTile(image, level, x, y, tileSize))
            {
                tile.Save(outStream, ImageFormat.Jpeg);
            }
            outStream.Position = 0;
            return outStream;
        }

        public static Image GetTile(this Image image,
                                    int level, int x, int y,
                                    int tileSize = MultiScaleTileEx.DefaultTileSize)
        {
            var point = new Point(x, y);

            var maxLevel = image.Size.MaxLevel();
            var maxLevelLength = Math.Pow(2, maxLevel);
            var maxLevelSize = new Size((int)maxLevelLength, (int)maxLevelLength);

            var levelLength = Math.Pow(2, level);
            var levelScale = (double)tileSize / levelLength;

            var imageScale = levelLength / maxLevelLength;
            var imageScaledSize = image.Size.Scale(imageScale);
            var imageOffset = point.OffSetBy(imageScaledSize);

            if (levelScale < 1)
            {
                var subTileSize = new Size(tileSize, tileSize);
                var extractSize = maxLevelSize.Scale(levelScale);
                var extractPoint = point.OffSetBy(extractSize);
                var extractBlock = new Rectangle(extractPoint, extractSize);

                Bitmap subTileImage = null;
                try
                {
                    subTileImage = new Bitmap(subTileSize.Width, subTileSize.Height);

                    if ((subTileImage.PixelFormat & PixelFormat.Indexed) != 0)
                        throw new NotSupportedException("sorry this file format is not supported at this time");

                    using (var graphic = Graphics.FromImage(subTileImage))
                    {
                        graphic.DrawImage(
                                image,
                                new Rectangle(0, 0, subTileImage.Width, subTileImage.Height),
                                extractBlock,
                                GraphicsUnit.Pixel);
                    }
                }
                catch
                {
                    if (subTileImage != null)
                    {
                        // Don't want to leave any extra windows GDI handles laying around.
                        subTileImage.Dispose();
                    }
                    throw;
                }

                return subTileImage;
            }
            else
            {
                return new Bitmap(image, imageScaledSize);
            }
        }
    }
}
