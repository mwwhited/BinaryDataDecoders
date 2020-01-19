using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
using BinaryDataDecoders.ToolKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using static BinaryDataDecoders.ToolKit.DelimiterOptions;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.Favero
{
    [TestClass]
    public class FaveroTestDataExtractor
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestDataExtractor()
        {
            var path = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\Favero\RawData.txt";

            var chunks = File.ReadAllText(path)
                           .ToUpper()
                           .Where(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F'))
                           .ToArray()
                           .AsMemory()
                           .MemoryFromHexString()
                           .Split(0xff, Carry);

            //var segments = (from c in chunks
            //                select c.ToArray().ToHexString(",0x"))
            //               .Distinct()
            //               .OrderBy(i => i)
            //               .Aggregate(new StringBuilder(), (sb, v) => sb.Append("0x").Append(v).AppendLine())
            //               .ToString();
            // this.TestContext.WriteLine(segments);

            var parser = new FaveroStateParser();
            foreach (var c in chunks.Distinct()) 
            {
                try
                {
                    var state = parser.Parse(c.Span);
                    this.TestContext.WriteLine(state.ToString());
                }
                catch
                {
                    this.TestContext.WriteLine($"ERROR Decoding {c.ToArray().ToHexString()}");
                }
            }

        }
    }
}
