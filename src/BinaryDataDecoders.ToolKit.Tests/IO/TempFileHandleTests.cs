using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BinaryDataDecoders.ToolKit.Tests.IO;

[TestClass]
public class TempFileHandleTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.Unit)]
    public void CreateTempFileHandleTest()
    {
        string? tempFileName = null;
        using (var temp = new TempFileHandle())
        {
            tempFileName = temp.FilePath;
            this.TestContext.WriteLine(temp.FilePath);
            Assert.IsTrue(File.Exists(tempFileName));
        }
        Assert.IsFalse(File.Exists(tempFileName));
    }
}
