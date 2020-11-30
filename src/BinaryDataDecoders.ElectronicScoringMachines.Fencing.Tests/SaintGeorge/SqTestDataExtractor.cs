using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Text;

using static BinaryDataDecoders.IO.Bytes;
using static BinaryDataDecoders.ToolKit.DelimiterOptions;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.SaintGeorge
{
    [TestClass]
    public class SqTestDataExtractor
    {
        public TestContext TestContext { get; set; }
        
        [TestMethod, TestCategory(TestCategories.DevLocal)]
        [Ignore]
        public void TestDataExtractor()
        {
            var path = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\SaintGeorge\outfile.bin";
            var data = File.ReadAllBytes(path);
            var memory = data.AsMemory();

            var chunks = memory.Split(delimiter: Soh, option: Carry);

            var segments = (from c in chunks
                            select c.ToArray().ToHexString(",0x"))
                           .Distinct()
                           .OrderBy(i => i)
                           .Aggregate(new StringBuilder(), (sb, v) => sb.Append("0x").Append(v).AppendLine())
                           .ToString();
            this.TestContext.WriteLine(segments);

        }
    }
}
