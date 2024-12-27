using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        var testValue = new string('A', 1024);

        var input = Encoding.UTF8.GetBytes(testValue);
        var compressed = input.Compress();
        var checkto = Convert.ToBase64String(compressed);

        var backFrom = Convert.FromBase64String(checkto);
        var decompressed = backFrom.Decompress();
        var checkFrom = Encoding.UTF8.GetString(decompressed);
        Assert.AreEqual(testValue, checkFrom);
    }
}
