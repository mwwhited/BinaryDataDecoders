using BinaryDataDecoders.Cryptography.Lorenz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.Cryptography.Tests.Lorenz
{
    [TestClass]
    public class LorenzMachineTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Test()
        {
            var lm = new LorenzMachine(LorenzMachine.ZMUG.key, LorenzMachine.ZMUG.start);

            var mesg = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";

            var result = lm.Encode(mesg);

            Assert.AreEqual("EATAS1DSSQ421X4B5ZHPRXE5XNV4CESS", result);

            var check = lm.Encode(result);

            Assert.AreEqual(mesg, check);
        }
    }
}
