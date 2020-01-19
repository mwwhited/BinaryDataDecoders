using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Tests.Favero
{
    [TestClass]
    public class FaveroStateParserTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory("Unit")]
        public void DecodeTest()
        {
            /*
             	 FFh, 06h, 12h, 56h, 02h, 14h, 0Ah, 00h, 38h, 56h
	             which will display:
	             Right score = 6
	             Left score = 12
	             Time = 2:56
	             The Lamps ON are: Red, Yellow right, Left priorite.
	             Number of Matchs = 2
	             Left yellow penalty lamp = ON. 
            */
            var frame = new byte[]
            {
                0xff, 0x06, 0x12, 0x56, 0x02, 0x14, 0x0a, 0x00, 0x38, 0x56,
            };

            var parser = new FaveroStateParser();
            var state = parser.Parse(frame);

            this.TestContext.WriteLine(state.ToString());
            // R:S>012 L>Yellow C>None P>False G:S>006 L>Touch C>None P>True T:00:02:56 M:0

            Assert.AreEqual(12, state.Left.Score, "Check Left Score");
            Assert.AreEqual(Lights.Touch, state.Left.Lights, "Check Left Lights");
            Assert.AreEqual(Cards.Yellow, state.Left.Cards, "Check Left Cards");
            Assert.AreEqual(true, state.Left.Priority, "Check Left Priority");

            Assert.AreEqual(6, state.Right.Score, "Check Right Score");
            Assert.AreEqual(Lights.Yellow, state.Right.Lights, "Check Right Lights");
            Assert.AreEqual(Cards.None, state.Right.Cards, "Check Right Cards");
            Assert.AreEqual(false, state.Right.Priority, "Check Right Priority");

            Assert.AreEqual(new TimeSpan(0, 2, 56), state.Clock, "Check Clock");
            Assert.AreEqual(0, state.Match, "Check Match");
        }

    }
}
