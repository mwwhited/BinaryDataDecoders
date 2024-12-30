using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ToolKit.Tests.Numerics;

[TestClass]
public class ByteNumberTests
{
    public required TestContext TestContext { get; set; }

    [DataTestMethod, TestCategory(TestCategories.Unit)]
    [DataRow(1d, "1b")]
    [DataRow(1000d, "1000b")]
    [DataRow(1001d, "1001b")]
    [DataRow(1024d, "1kb")]
    [DataRow(1026d, "1.002kb")]
    [DataRow(1001000d, "977.539kb")]
    [DataRow(0.110, "112.64mb")]
    [DataRow(0.110123, "112.766mb")]
    public void ConvertTest(double input, string expected)
    {
        ByteNumber number = input;
        var result = number.ToString();
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod, TestCategory(TestCategories.Unit)]
    [DataRow("1b", 1d)]
    [DataRow("1000b", 1000d)]
    [DataRow("1001b", 1001d)]
    [DataRow("1kb", 1024d)]
    [DataRow("1.002kb", 1026.048d)]
    [DataRow("977.539kb", 1000999.936d)]
    [DataRow("112.64mb", 0.110d)]
    [DataRow("112.766mb", 0.110123046875d)]
    public void TryParseTest(string? input, double? expected)
    {
        var result = ByteNumber.TryParse(input, out var value);
        Assert.IsTrue(result);
        Assert.AreEqual((double)expected, (double)value);
    }
}


