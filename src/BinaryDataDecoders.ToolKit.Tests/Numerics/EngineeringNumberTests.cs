using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ToolKit.Tests.Numerics;

[TestClass]
public class EngineeringNumberTests
{
    public required TestContext TestContext { get; set; }

    [DataTestMethod, TestCategory(TestCategories.Unit)]
    [DataRow(1d, "1")]
    [DataRow(1000d, "1k")]
    [DataRow(1001d, "1.001k")]
    [DataRow(1024d, "1.024k")]
    [DataRow(1026d, "1.026k")]
    [DataRow(1001000d, "1.001M")]
    [DataRow(0.110, "110m")]
    [DataRow(0.110123, "110.123m")]
    public void ConvertTest(double input, string expected)
    {
        EngineeringNumber number = input;
        var result = number.ToString();
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod, TestCategory(TestCategories.Unit)]
    [DataRow("1", 1d)]
    [DataRow("1k", 1000d)]
    [DataRow("1.001k", 1001d)]
    [DataRow("1.024k", 1024d)]
    [DataRow("1.026k", 1026d)]
    [DataRow("1.001M", 1001000d)]
    [DataRow("110m", 0.110)]
    [DataRow("110.123m", 0.110123)]
    public void TryParseTest(string? input, double? expected)
    {
        var result = EngineeringNumber.TryParse(input, out var value);
        Assert.IsTrue(result);
        Assert.AreEqual(expected, (double)value);
    }
}
