using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static BinaryDataDecoders.ToolKit.DelimiterOptions;

namespace BinaryDataDecoders.ToolKit.Tests
{
    [TestClass]
    public class MemoryExTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void SplitTest_Exclude()
        {
            var data = GetTestData();
            var segments = data.Split(0x08, Exclude);

            byte[] left = { 0, 1, 2, 3, 4, 5, 6, 7, };
            byte[] right = { 9, 10, 11, 12, 13, 14, 15, };

            Assert.AreEqual(0, segments.ElementAt(0).Span.IndexOf(new ReadOnlySpan<byte>(left)));
            Assert.AreEqual(left.Length, segments.ElementAt(0).Length);

            Assert.AreEqual(0, segments.ElementAt(1).Span.IndexOf(new ReadOnlySpan<byte>(right)));
            Assert.AreEqual(right.Length, segments.ElementAt(1).Length);
        }
        [TestMethod]
        public void SplitTest_Carry()
        {
            var data = GetTestData();
            var segments = data.Split(0x08, Carry);

            byte[] left = { 0, 1, 2, 3, 4, 5, 6, 7, };
            byte[] right = { 8, 9, 10, 11, 12, 13, 14, 15, };

            Assert.AreEqual(0, segments.ElementAt(0).Span.IndexOf(new ReadOnlySpan<byte>(left)));
            Assert.AreEqual(left.Length, segments.ElementAt(0).Length);

            Assert.AreEqual(0, segments.ElementAt(1).Span.IndexOf(new ReadOnlySpan<byte>(right)));
            Assert.AreEqual(right.Length, segments.ElementAt(1).Length);
        }

        [TestMethod]
        public void SplitTest_Return()
        {
            var data = GetTestData();
            var segments = data.Split(0x08, Return);

            byte[] left = { 0, 1, 2, 3, 4, 5, 6, 7, 8, };
            byte[] right = { 9, 10, 11, 12, 13, 14, 15, };

            Assert.AreEqual(0, segments.ElementAt(0).Span.IndexOf(new ReadOnlySpan<byte>(left)));
            Assert.AreEqual(left.Length, segments.ElementAt(0).Length);

            Assert.AreEqual(0, segments.ElementAt(1).Span.IndexOf(new ReadOnlySpan<byte>(right)));
            Assert.AreEqual(right.Length, segments.ElementAt(1).Length);
        }


        private Memory<byte> GetTestData()
        {
            return new Memory<byte>(new byte[]
            {
                0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
            });
        }
    }
}
