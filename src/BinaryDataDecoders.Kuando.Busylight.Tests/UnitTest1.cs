using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Kuando.Busylight.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            await new Class1().Start(new System.Threading.CancellationTokenSource());
        }
    }
}
