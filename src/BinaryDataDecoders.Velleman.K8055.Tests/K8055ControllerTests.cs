using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.Velleman.K8055.Tests
{
    [TestClass]
    public class K8055ControllerTests
    {
        [TestMethod, TestCategory(TestCategories.DevLocal)]
        public void TestMethod1()
        {
             new K8055Controller().Start(new System.Threading.CancellationTokenSource(), 3);
            // 00 - 00 - 04 - 04 - fc - 00 - 00 - 00 - 00
            // ??   Inputs
            // ??
            // 1 | 2 |4 |5 | 3

        }
    }
}
