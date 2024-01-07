using BinaryDataDecoders.Drawing.Barcodes;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.Drawing.Tests.BarCodes;

[TestClass]
public class Code39Tests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void Test()
    {

        var code39 = new Code39();
        using (var ms = new MemoryStream())
        using (var bmp = code39.EncodeStandard("HELLO"))
        {
            bmp.Save(ms, ImageFormat.Png);
            this.TestContext.AddResult(ms, "code39.EncodeStandard.png");
        }
        using (var ms = new MemoryStream())
        using (var bmp = code39.EncodeFullAscii("Hello World!"))
        {
            bmp.Save(ms, ImageFormat.Png);
            this.TestContext.AddResult(ms, "code39.EncodeFullAscii.png");
        }

        {
            var codes = new[] {
            "ABCDEFGHIJ",
            "KLMNOPQRST",
            "UVWXYZ0123",
            "456789 -$%",
            "./+",
        };
            using var ms = new MemoryStream();
            using var set = new Bitmap((codes[0].Length + 2) * 16, codes.Length * 16);
            using var graph = Graphics.FromImage(set);
            foreach (var item in codes.Select((v, i) => new { v, i }))
                using (var bmp = code39.EncodeStandard(item.v))
                {
                    graph.DrawImage(bmp, new Point(0, item.i * 16));
                }
            set.Save(ms, ImageFormat.Png);
            this.TestContext.AddResult(ms, "code39.Test.png");
        }
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -$%./+";
            var codes = alphabet.Select(c => "" + c).ToArray();

            using var ms = new MemoryStream();
            using var set = new Bitmap(((codes[0].Length + 2) * 16) + 32, codes.Length * 16);
            using var graph = Graphics.FromImage(set);
            graph.FillRectangle(Brushes.White, 0, 0, set.Width, set.Height);
            foreach (var item in codes.Select((v, i) => new { v, i }))
                using (var bmp = code39.EncodeStandard(item.v))
                {
                    graph.DrawString(item.v, SystemFonts.DefaultFont, Brushes.Black, new Point(0, item.i * 16));
                    graph.DrawImage(bmp, new Point(32, item.i * 16));
                }

            set.Save(ms, ImageFormat.Png);
            this.TestContext.AddResult(ms, "code39.Test2.png");
        }
    }
}
