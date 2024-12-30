using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ToolKit.Tests.Numerics;

[TestClass]
public class ByteNotationFormatterTests
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
    public void FormatTest(double input, string expected)
    {
        var result = string.Format(new ByteNotationFormatter(), "{0}", input);
        Assert.AreEqual(expected, result);
    }
}
