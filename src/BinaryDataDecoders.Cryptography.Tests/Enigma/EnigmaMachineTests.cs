using BinaryDataDecoders.Cryptography.Enigma;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BinaryDataDecoders.Cryptography.Tests.Enigma;

[TestClass]
public class EnigmaMachineTests
{
    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(EnigmaMachine), Member = nameof(EnigmaMachine.Process))]
    public void ProcessTest_EnigmaI_I_II_III_RefB_ABDEYZ_AAA()
    {
        var rotors = EnigmaRotor.Rotors
                                .Where(r => r.Series == "Enigma I" &&
                                            new[] { "I", "II", "III" }.Contains(r.Number))
                                .ToArray();
        var reflector = EnigmaReflector.Reflectors
                                       .First(r => r.Number == "Reflector B");

        var em = new EnigmaMachine(rotors, reflector)
        {
            PlugBoard = "AB DE YZ"
        };
        var start = em.Positions = "AAA";

        var ret = em.Process("AAAAA");
        Assert.AreEqual("BJLCS", ret);
    }
}
