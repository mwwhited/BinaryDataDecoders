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
            var testFile = @"C:\Repos\GCA\RSMBilling\src\GCAInvoicing\Lightwell.Nucleus.Persistence.NucleusDb\bin\Debug\Lightwell.Nucleus.Persistence.NucleusDb.dacpac";
            var builder = new DacPacNavigator();
            var nav = builder.ToNavigable(testFile);
            this.TestContext.AddResult(nav);
        }
    }
}
