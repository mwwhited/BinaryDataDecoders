using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.CodeAnalysis.DacFx.Tests
{
    [TestClass]
    public class DacPacNavigatorTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory("DACPAC")]
        public void Test()
        {
            var testFile = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.SqlServer.Samples\bin\Debug\netstandard2.0\BinaryDataDecoders.SqlServer.Samples.dacpac";
            var builder = new DacPacNavigator();
            var nav = builder.ToNavigable(testFile);
            this.TestContext.AddResult(nav);
        }
    }
}
