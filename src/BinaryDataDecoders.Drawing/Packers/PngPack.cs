using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Drawing.Packers
{
    public class PngPack
    {
        public byte[] Pack(byte[] input)
        {
            var length = input.Length;
            var requiredPixels = Math.Ceiling(length / 4d) + 1;
            var width = Math.Ceiling(Math.Sqrt(requiredPixels));
            var height = Math.Ceiling(requiredPixels / width);

            var pixelFormat = PixelFormat.Format32bppArgb;
            using (var bitmap = new Bitmap((int)width, (int)height, pixelFormat))
            using (var outStream = new MemoryStream())
            {
                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, pixelFormat);
                var ptr = bitmapData.Scan0;
                Marshal.Copy(BitConverter.GetBytes(length), 0, ptr, 4);
                Marshal.Copy(input, 0, ptr + 4, length);

                bitmap.UnlockBits(bitmapData);
                bitmap.Save(outStream, ImageFormat.Png);
                return outStream.ToArray();
            }
        }

        public byte[] Unpack(byte[] input)
        {
            var pixelFormat = PixelFormat.Format32bppArgb;
            using (var inputStream = new MemoryStream(input))
            using (var bitmap = new Bitmap(inputStream))
            {
                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, pixelFormat);

                var ptr = bitmapData.Scan0;
                var lengthBuffer = new byte[4];
                Marshal.Copy(ptr, lengthBuffer, 0, 4);
                var length = BitConverter.ToInt32(lengthBuffer, 0);
                var outBuffer = new byte[length];
                Marshal.Copy(ptr + 4, outBuffer, 0, length);

                bitmap.UnlockBits(bitmapData);

                return outBuffer;
            }
        }
    }
}
