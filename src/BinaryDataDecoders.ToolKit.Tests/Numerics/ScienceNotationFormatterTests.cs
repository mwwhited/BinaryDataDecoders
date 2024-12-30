using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ToolKit.Tests.Numerics;

[TestClass]
public class ScienceNotationFormatterTests
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
    public void FormatTest(double input, string expected)
    {
        var result = string.Format(new ScienceNotationFormatter(), "{0}", input);
        Assert.AreEqual(expected, result);
    }
}

