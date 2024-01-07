using BinaryDataDecoders.IO.Functions;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.IO.Tests.Functions;

[TestClass]
public class ChecksumCalculatorTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(ChecksumCalculator), Member = nameof(ChecksumCalculator.Simple16))]
    public void Simple16Test()
    {
        //Stage
        Span<byte> bytes = new byte[] {
            0x7B, 0xFF, //prefix
            0x20, 0x00, // request
            0x06, 0x00, // extended length
            0x4e, 0x01, 0x00, 0x00, //packet number                
            0x00, 0x00, //checksum 0

            0x03, 0x08, // request type
            0x00, 0x00, // request type 2
            0x00, 0x00, // checksum1
        };
        var shorts = MemoryMarshal.Cast<byte, ushort>(bytes);

        //Mock

        //Test
        var provider = new ChecksumCalculator();
        var results = new[]{
            provider.Simple16(shorts[..6]),
            provider.Simple16(shorts.Slice(6, 3)),
        };

        //Assert
        Assert.AreEqual((ushort)0xff0f, results[0]);
        Assert.AreEqual((ushort)0xf7fc, results[1]);

        //Verify
    }
}
