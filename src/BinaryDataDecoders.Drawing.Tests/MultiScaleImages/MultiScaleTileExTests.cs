using BinaryDataDecoders.Drawing.MultiScaleImages;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace BinaryDataDecoders.Drawing.Tests.MultiScaleImages
{
    [TestClass]
    public class MultiScaleTileExTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.DevLocal)]
        public void TestTileCreate()
        {
            var sourceFileName = "TestData.DSC_4668.JPG";
            using var sourceFile = this.GetResourceStream(sourceFileName);
            using var bitmap = new Bitmap(sourceFile);
            var maxLevel = bitmap.GetMaxLevel();

            for (var level = 0; level <= maxLevel; level++)
            {
                var dir = level.ToString();

                var tileCounts = bitmap.GetTileCount(level);

                for (var x = 0; x < tileCounts.Width; x++)
                    for (var y = 0; y < tileCounts.Height; y++)
                    {
                        var file = $"{dir}-{x:0000}_{y:0000}.jpg";
                        TestContext.WriteLine($"{file} Created");

                        var buffer = bitmap.GetTileAsBytes(level, x, y);
                        this.TestContext.AddResult(buffer, file);
                    }
            }
        }
    }
}
