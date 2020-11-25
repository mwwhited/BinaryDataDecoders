using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Velleman.K8055.Tests
{
    [TestClass]
    public class K8055ControllerTests
    {
        [TestMethod]
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
