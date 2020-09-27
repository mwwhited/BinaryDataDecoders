using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static BinaryDataDecoders.ToolKit.DelimiterOptions;

namespace BinaryDataDecoders.ToolKit.Tests
{
    [TestClass]
    public class MemoryExTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(MemoryExtensions), Member = nameof(MemoryExtensions.Split))]
        public void SplitTest_Exclude()
        {
            var data = GetTestData();
            var segments = data.Split(0x08, Exclude);

            CheckResults(segments,
                new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, },
                new byte[] { 9, 10, 11, 12, 13, 14, 15, }
                );
        }
        [TestMethod, TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(MemoryExtensions), Member = nameof(MemoryExtensions.Split))]
        public void SplitTest_Carry()
        {
            var data = GetTestData();
            var segments = data.Split(0x08, Carry);

            CheckResults(segments,
                new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, },
                new byte[] { 8, 9, 10, 11, 12, 13, 14, 15, }
                );
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(MemoryExtensions), Member = nameof(MemoryExtensions.Split))]
        public void SplitTest_Return()
        {
            var data = GetTestData();
            var segments = data.Split(0x08, Return);

            CheckResults(segments,
                new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, },
                new byte[] { 9, 10, 11, 12, 13, 14, 15, }
                );
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(MemoryExtensions), Member = nameof(MemoryExtensions.Split))]
        public void SplitTest_Exclude3()
        {
            var data = GetBigTestData();
            var segments = data.Split(0x08, Exclude);

            CheckResults(segments,
                new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, },
                new byte[] { 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, },
                new byte[] { 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, },
                new byte[] { 9, 10, 11, 12, 13, 14, 15, }
                );
        }

        private void CheckResults(IEnumerable<Memory<byte>> results, params byte[][] expected)
        {
            var checks = expected.Select((exp, index) => (exp, index));
            foreach (var check in checks)
            {
                Assert.AreEqual(check.exp.Length, results.ElementAt(check.index).Length);
                if (check.exp.Length != 0)
                {
                    Assert.AreEqual(0, results.ElementAt(check.index).Span.IndexOf(new ReadOnlySpan<byte>(check.exp)));
                }
            }
        }

        private Memory<byte> GetTestData()
        {
            return new Memory<byte>(new byte[]
            {
                0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
            });
        }
        private Memory<byte> GetBigTestData()
        {
            return new Memory<byte>(new byte[]
            {
                0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
                0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
                0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
            });
        }
    }
}
