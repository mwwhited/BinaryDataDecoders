using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.Cryptography.Enigma;

// https://en.wikipedia.org/wiki/Enigma_rotor_details
// http://enigmaco.de/enigma/enigma.html
public class EnigmaMachine
{
    private string[] plugboard;
    private int[] postions;
    private int[] ringSettings;
    private readonly EnigmaRotor[] rotors;
    private readonly EnigmaReflector reflector;
    public EnigmaMachine(EnigmaRotor[] rotors,
                         EnigmaReflector reflector,
                         //string start = null, 
                         string ringSettings = null,
                         string plugBoard = null)
    {
        if (rotors == null || rotors.Length < 3 || rotors.Length > 5)
            throw new InvalidOperationException("Invalid Rotor Set");
        if (reflector == null)
            throw new InvalidOperationException("Invalid Reflector");

        this.rotors = rotors.Reverse().ToArray();
        this.reflector = reflector;
        this.Position = null;  //(start ?? new string('A', rotors.Length));
        this.RingSettings = ringSettings;
        this.PlugBoard = plugBoard;
    }

    public string Position
    {
        get
        {
            return (this.postions
                        .Reverse()
                        .Select(p => (char)(p + 'A'))
                        .AsString()
                        + new string('A', this.rotors.Length)
                        )[..this.rotors.Length];
        }
        set
        {
            this.postions = (value ?? new string('A', this.rotors.Length)).Select(i => i - 'A')
                                 .Concat(new int[this.rotors.Length])
                                 .Take(this.rotors.Length)
                                 .Reverse()
                                 .ToArray();
        }
    }

    public string RingSettings
    {
        get
        {
            return (this.ringSettings
                        .Reverse()
                        .Select(p => (char)(p + 'A'))
                        .AsString()
                        + new string('A', this.rotors.Length)
                        )[..this.rotors.Length];
        }
        private set
        {
            this.ringSettings = (value?? new string('A', this.rotors.Length)).Select(i => i - 'A')
                                     .Concat(new int[this.rotors.Length])
                                     .Take(this.rotors.Length)
                                     .Reverse()
                                     .ToArray();
        }
    }

    public string PlugBoard
    {
        get
        {
            return string.Join(" ", this.plugboard ?? new string[0]);
        }
        set
        {
            var cleaned = value.Clean().AsString();
            if (cleaned.Length % 2 == 0 && cleaned.GroupBy(c => c).Any(c => c.Count() != 1))
                throw new InvalidOperationException("Invalid Plug Board");

            this.plugboard = cleaned.SplitAt(2).ToArray();
        }
    }

    public string Rotors
    {
        get { return string.Join(";", this.rotors.Select(r => r.Number));  }
    } 
    public string Reflector
    {
        get { return this.reflector.Number; }
    }

    public string Process(string input)
    {
        input = input.Clean().AsString().SwapSet(this.plugboard);
        var start = this.Position;
        var set = this.rotors;
        var rs = this.ringSettings;
        var l = 26; // set[0].Length;

        var cOut = new List<char>();

        foreach (var c in input.Select(x => x - 'A'))
        {
            this.postions[0] = (this.postions[0] + 1) % l;
            if (this.rotors[0].RotateOn.Contains((char)(this.postions[0] + 'A')))
            {
                this.postions[1] = (this.postions[1] + 1) % l;

                if (this.rotors[1].RotateOn.Contains((char)(this.postions[1] + 'A')))
                {
                    this.postions[2] = (this.postions[2] + 1) % l;

                    if (this.rotors.Length > 3 &&
                        this.rotors[2].RotateOn.Contains((char)(this.postions[2] + 'A')))
                    {
                        this.postions[3] = (this.postions[3] + 1) % l;
                    }
                }
            }

            var indexes = this.postions;

            var m = c;
            for (var i = 0; i < set.Length; i++)
                m = (set[i].Wiring[(m + indexes[i] + rs[i]) % l] - indexes[i] - 'A' + l) % l;
            m = (reflector.Wiring[m] - 'A' + l) % l;
            for (var i = set.Length - 1; i > -1; i--)
                m = (set[i].Wiring.IndexOf((char)(((m + indexes[i]) % l) + 'A')) - indexes[i] - rs[i] + l) % l;
            cOut.Add((char)(m + 'A'));
        }
        return cOut.AsString().SwapSet(this.plugboard);
    }
}
