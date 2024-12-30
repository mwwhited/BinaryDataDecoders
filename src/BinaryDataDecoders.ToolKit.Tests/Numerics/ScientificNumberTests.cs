using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ToolKit.Tests.Numerics;

[TestClass]
public class ScientificNumberTests
{
    public required TestContext TestContext { get; set; }

    [DataTestMethod, TestCategory(TestCategories.Unit)]
    [DataRow(1d, "1")]
    [DataRow(1000d, "1e3")]
    [DataRow(1001d, "1.001e3")]
    [DataRow(1024d, "1.024e3")]
    [DataRow(1026d, "1.026e3")]
    [DataRow(1001000d, "1.001e6")]
    [DataRow(0.110, "1.1e-1")]
    [DataRow(0.110123, "1.101e-1")]
    public void ConvertTest(double input, string expected)
    {
        ScientificNumber number = input;
        var result = number.ToString();
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod, TestCategory(TestCategories.Unit)]
    [DataRow("1", 1d)]
    [DataRow("1e3", 1000d)]
    [DataRow("1.001e3", 1001d)]
    [DataRow("1.024e3", 1024d)]
    [DataRow("1.026e3", 1026d)]
    [DataRow("1.001e6", 1001000d)]
    [DataRow("1.1e-1", 0.110)]
    [DataRow("1.101e-1", 0.1101)]
    public void TryParseTest(string? input, double? expected)
    {
        var result = ScientificNumber.TryParse(input, out var value);
        Assert.IsTrue(result);
        Assert.AreEqual(expected, (double)value);
    }
}

[TestClass]
public class FormattableNumberTests
{
    [DataTestMethod, TestCategory(TestCategories.Unit)]
    [DataRow("1", 1d)]
    [DataRow("1e3", 1000d)]
    [DataRow("1.001e3", 1001d)]
    [DataRow("1.024e3", 1024d)]
    [DataRow("1.026e3", 1026d)]
    [DataRow("1.001e6", 1001000d)]
    [DataRow("1.1e-1", 0.110)]
    [DataRow("1.101e-1", 0.1101)]

    [DataRow("1k", 1000d)]
    [DataRow("1.001k", 1001d)]
    [DataRow("1.024k", 1024d)]
    [DataRow("1.026k", 1026d)]
    [DataRow("1.001M", 1001000d)]
    [DataRow("110m", 0.110)]
    [DataRow("110.123m", 0.110123)]

    [DataRow("1b", 1d)]
    [DataRow("1000b", 1000d)]
    [DataRow("1001b", 1001d)]
    [DataRow("1kb", 1024d)]
    [DataRow("1.002kb", 1026.048d)]
    [DataRow("977.539kb", 1000999.936d)]
    [DataRow("112.64mb", 0.110d)]
    [DataRow("112.766mb", 0.110123046875d)]
    public void TryParse(string? input, double? expected)
    {
        var result = FormattableNumber.Parse(input);
        Assert.AreEqual(expected, result.AsDouble());
    }
}

