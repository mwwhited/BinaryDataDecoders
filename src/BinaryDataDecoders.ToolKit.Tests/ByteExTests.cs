using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.ToolKit.Tests;

[TestClass()]
public class ByteExTests
{
    [TestMethod, TestCategory(TestCategories.Unit)]
    public void DecompressTest()
    {
        var input = Convert.FromBase64String("c3QcBaNgFIxUAAA=");
        var decompressed = input.Decompress();
        var checkto = Encoding.UTF8.GetString(decompressed);
        Assert.AreEqual(new string('A', 1024), checkto);
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    public void CompressTest()
    {
        var input = Encoding.UTF8.GetBytes(new string('A', 1024));
        var compressed = input.Compress();
        var checkto = Convert.ToBase64String(compressed);
        Assert.AreEqual("c3QcBaNgFIxUAAA=", checkto);
    }
}
