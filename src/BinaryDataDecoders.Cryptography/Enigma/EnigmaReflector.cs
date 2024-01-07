using System.Collections.Generic;

namespace BinaryDataDecoders.Cryptography.Enigma;

public class EnigmaReflector
{
    public static IEnumerable<EnigmaReflector> Reflectors { get; } = new[]
    {
        new EnigmaReflector {Number="Reflector A", Series="",Wiring="EJMZALYXVBWFCRQUONTSPIKHGD",Introduced=""},
        new EnigmaReflector {Number="Reflector B", Series="",Wiring="YRUHQSLDPXNGOKMIEBFZCWVJAT",Introduced=""},
        new EnigmaReflector {Number="Reflector C", Series="",Wiring="FVPJIAOYEDRZXWGCTKUQSBNMHL",Introduced=""},
        new EnigmaReflector {Number="Reflector B Thin", Series="M4 R1 (M3 + Thin)",Wiring="ENKQAUYWJICOPBLMDXZVFTHRGS",Introduced="1940"},
        new EnigmaReflector {Number="Reflector C Thin", Series="M4 R1 (M3 + Thin)",Wiring="RDOBJNTKVEHMLFCWZAXGYIPSUQ",Introduced="1940"},
    };
    public string Introduced { get; private set; }
    public string Number { get; private set; }
    public string Series { get; private set; }
    public string Wiring { get; private set; }
}
