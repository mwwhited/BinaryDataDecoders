using BinaryDataDecoders.Drawing.Packers;
using BinaryDataDecoders.ToolKit;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;

namespace BinaryDataDecoders.Drawing.Tests.Packers;

[TestClass]
public class PngPackTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void PngPackTest()
    {
        var sourceFileName = "TestData.DSC_4668.JPG";
        using var sourceFile = this.GetResourceStream(sourceFileName);
        var testBuffer = sourceFile.AsBytes();

        var pngPack = new PngPack();

        var outBuffer = pngPack.Pack(testBuffer);
        this.TestContext.AddResult(outBuffer, Path.ChangeExtension(sourceFileName, ".png"));

        var outBuffer2 = pngPack.Unpack(outBuffer);
        this.TestContext.AddResult(testBuffer, Path.ChangeExtension(sourceFileName, ".jpeg"));
    }
}
