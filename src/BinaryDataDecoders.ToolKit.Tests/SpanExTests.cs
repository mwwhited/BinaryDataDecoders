using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BinaryDataDecoders.ToolKit.Tests
{
    [TestClass]
    public class SpanExTests
    {
        [TestMethod, TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(SpanEx), Member = nameof(SpanEx.CopyWithTransform))]
        public void CopyWithTransformTest_byte2byte_7bit()
        {
            byte[] input = Enumerable.Range(0, 255).Select(b => (byte)b).ToArray();
            ReadOnlySpan<byte> span = input;
            var result = span.CopyWithTransform(i => (byte)(i & 0x7f));
            foreach (var b in result)
                Assert.IsTrue(b < 0x80);
        }
    }
}
