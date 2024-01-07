using System;
using System.Linq;

namespace BinaryDataDecoders.Cryptography;

public class Caesar
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Caesar_cipher
    /// </summary>
    /// <param name="input"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public string Encode(string input, char code) =>
        (GetOffset(code), input) switch
        {
            (_, null) => "",
            (int offset, _) => new string(input.Select(c => Encode(c, offset)).ToArray())
        };
    public string Decode(string input, char code) =>
        (GetOffset(code), input) switch
        {
            (_, null) => "",
            (int offset, _) => new string(input.Select(c => Decode(c, offset)).ToArray())
        };

    public char Encode(char input, char code) => Encode(input, GetOffset(code));
    public char Decode(char input, char code) => Decode(input, GetOffset(code));

    public char Encode(char input, int offset) =>
        input switch
        {
            >= 'A' and <= 'Z' => (char)('A' + ((input - 'A' + offset) % 26)),
            >= 'a' and <= 'z' => (char)('a' + ((input - 'a' + offset) % 26)),
            _ => input
        };
    public char Decode(char input, int offset) =>
        input switch
        {
            >= 'A' and <= 'Z' => (char)('A' + ((input + 26 - 'A' - offset) % 26)),
            >= 'a' and <= 'z' => (char)('a' + ((input + 26 - 'a' - offset) % 26)),
            _ => input
        };

    public int GetOffset(char code) => code switch
    {
        >= 'A' and <= 'Z' => code - 'A',
        >= 'a' and <= 'z' => code - 'a',
        _ => throw new ArgumentOutOfRangeException(nameof(code), "\"code\" must be between 'A' and 'Z'")
    };
}
