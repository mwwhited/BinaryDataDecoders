using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ToolKit.Tests.Numerics;

[TestClass]
public  class EngineeringNotationFormatterTests
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
    public void FormatTest(double input, string expected)
    {
        var result = string.Format(new EngineeringNotationFormatter(), "{0}", input); 
        Assert.AreEqual(expected, result);
    }
}
