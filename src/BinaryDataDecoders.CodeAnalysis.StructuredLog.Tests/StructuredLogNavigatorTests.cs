using BinaryDataDecoders.CodeAnalysis.StructuredLog;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.CodeAnalysis.StructuredLog.Tests;

[TestClass]
public class StructuredLogNavigatorTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    //[TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(StructuredLogNavigator), Member = nameof(StructuredLogNavigator.ToNavigable))]
    public void TestXPath()
    {
        var filePath = @"C:\Repos\mwwhited\BinaryDataDecoders\Publish\dotnet_build.binlog";
        var lognav = new StructuredLogNavigator().ToNavigable(filePath);
        var nav = lognav.CreateNavigator();
        TestContext.AddResult(nav);
    }
}
