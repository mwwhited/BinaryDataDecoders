using System.Collections.Generic;

namespace BinaryDataDecoders.Cryptography.Enigma
{
    public class EnigmaRotor
    {
        public static IEnumerable<EnigmaRotor> Rotors { get; } = new[]
        {
            new EnigmaRotor {Number="IC", Series="Commercial Enigma A, B",Wiring="DMTWSILRUYQNKFEJCAZBPGXOHV",Introduced="1924",RotateOn=new char[]{'Q'}},
            new EnigmaRotor {Number="IIC", Series="Commercial Enigma A, B",Wiring="HQZGPJTMOBLNCIFDYAWVEUSRKX",Introduced="1924",RotateOn=new char[]{'E'}},
            new EnigmaRotor {Number="IIIC", Series="Commercial Enigma A, B",Wiring="UQNTLSZFMREHDPXKIBVYGJCWOA",Introduced="1924",RotateOn=new char[]{'V'}},
            new EnigmaRotor {Number="I", Series="German Railway (Rocket)",Wiring="JGDQOXUSCAMIFRVTPNEWKBLZYH",Introduced="15014",RotateOn=new char[]{'Q'}},
            new EnigmaRotor {Number="II", Series="German Railway (Rocket)",Wiring="NTZPSFBOKMWRCJDIVLAEYUXHGQ",Introduced="15014",RotateOn=new char[]{'E'}},
            new EnigmaRotor {Number="III", Series="German Railway (Rocket)",Wiring="JVIUBHTCDYAKEQZPOSGXNRMWFL",Introduced="15014",RotateOn=new char[]{'V'}},
            // new EnigmaRotor {Number="UKW", Series="German Railway (Rocket)",Wiring="QYHOGNECVPUZTFDJAXWMKISRBL",Introduced="15014",RotateOn=new char[]{}},
            // new EnigmaRotor {Number="ETW", Series="German Railway (Rocket)",Wiring="QWERTZUIOASDFGHJKPYXCVBNML",Introduced="15014",RotateOn=new char[]{}},
            new EnigmaRotor {Number="I-K", Series="Swiss K",Wiring="PEZUOHXSCVFMTBGLRINQJWAYDK",Introduced="14277",RotateOn=new char[]{'Q'}},
            new EnigmaRotor {Number="II-K", Series="Swiss K",Wiring="ZOUESYDKFWPCIQXHMVBLGNJRAT",Introduced="14277",RotateOn=new char[]{'E'}},
            new EnigmaRotor {Number="III-K", Series="Swiss K",Wiring="EHRVXGAOBQUSIMZFLYNWKTPDJC",Introduced="14277",RotateOn=new char[]{'V'}},
            // new EnigmaRotor {Number="UKW-K", Series="Swiss K",Wiring="IMETCGFRAYSQBZXWLHKDVUPOJN",Introduced="14277",RotateOn=new char[]{}},
            // new EnigmaRotor {Number="ETW-K", Series="Swiss K",Wiring="QWERTZUIOASDFGHJKPYXCVBNML",Introduced="14277",RotateOn=new char[]{}},
            new EnigmaRotor {Number="I", Series="Enigma I",Wiring="EKMFLGDQVZNTOWYHXUSPAIBRCJ",Introduced="1930",RotateOn=new char[]{'Q'}},
            new EnigmaRotor {Number="II", Series="Enigma I",Wiring="AJDKSIRUXBLHWTMCQGZNPYFVOE",Introduced="1930",RotateOn=new char[]{'E'}},
            new EnigmaRotor {Number="III", Series="Enigma I",Wiring="BDFHJLCPRTXVZNYEIWGAKMUSQO",Introduced="1930",RotateOn=new char[]{'V'}},
            new EnigmaRotor {Number="IV", Series="M3 Army",Wiring="ESOVPZJAYQUIRHXLNFTGKDCMWB",Introduced="14215",RotateOn=new char[]{'J'}},
            new EnigmaRotor {Number="V", Series="M3 Army",Wiring="VZBRGITYUPSDNHLXAWMJQOFECK",Introduced="14215",RotateOn=new char[]{'Z'}},
            new EnigmaRotor {Number="VI", Series="M3 & M4 Naval (FEB 1942)",Wiring="JPGVOUMFYQBENHZRDKASXLICTW",Introduced="1939",RotateOn=new char[]{'Z','M'}},
            new EnigmaRotor {Number="VII", Series="M3 & M4 Naval (FEB 1942)",Wiring="NZJHGRCXMYSWBOUFAIVLPEKQDT",Introduced="1939",RotateOn=new char[]{'Z','M'}},
            new EnigmaRotor {Number="VIII", Series="M3 & M4 Naval (FEB 1942)",Wiring="FKQHTLXOCBJSPDZRAMEWNIUYGV",Introduced="1939",RotateOn=new char[]{'Z','M'}},
            // new EnigmaRotor {Number="Beta", Series="M4 R2",Wiring="LEYJVCNIXWPBQMDRTAKZGFUHOS",Introduced="Spring 1941",RotateOn=new char[]{}},
            // new EnigmaRotor {Number="Gamma", Series="M4 R2",Wiring="FSOKANUERHMBTIYCWLQPZXVGJD",Introduced="Spring 1942",RotateOn=new char[]{}},
            // new EnigmaRotor {Number="ETW", Series="Enigma I",Wiring="ABCDEFGHIJKLMNOPQRSTUVWXYZ",Introduced="",RotateOn=new char[]{}},
        };

        public string Introduced { get; private set; }
        public string Number { get; private set; }
        public char[] RotateOn { get; private set; }
        public string Series { get; private set; }
        public string Wiring { get; private set; }
    }
}
