using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ToolKit.Tests.IO
{
    [TestClass]
    public class PathExTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.DevLocal)]
        public void EnumerateFilesTest()
        {
           var wildcardPath = @"C:\Repos\**\src\**\*.Tests\*\*.cs";
           // var wildcardPath = @"C:\Repos\mwwhited\BinaryDataDecoders\src\**\*.Tests\*\*.cs";

            foreach (var file in PathEx.EnumerateFiles(wildcardPath))
            {
                this.TestContext.WriteLine(file);
            }
        }
    }
}
