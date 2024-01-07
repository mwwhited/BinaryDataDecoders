using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Cryptography;

public class Vigenere : Caesar
{

    /// <summary>
    /// https://en.wikipedia.org/wiki/Vigen%C3%A8re_cipher
    /// </summary>
    /// <param name="input"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public string Encode(string input, string code) =>
        (input, BuildKey(input.Length, code)) switch
        {
            (null, _) => "",
            (string, string key) => new string(input.Zip(key).Select(item => Encode(item.First, item.Second)).ToArray())
        };
    public string Decode(string input, string code) =>
        (input, BuildKey(input.Length, code)) switch
        {
            (null, _) => "",
            (string, string key) => new string(input.Zip(key).Select(item => Decode(item.First, item.Second)).ToArray())
        };

    public string BuildKey(int length, string? code)
    {
        code = new string((code ?? string.Empty).Where(c => char.IsLetter(c)).ToArray());
        if (string.IsNullOrWhiteSpace(code))
            return new string(Enumerable.Range(0, length).Select(i => (char)('A' + (i % 26))).ToArray());
        return string.Join("", Enumerable.Range(0, length / code.Length + 1).Select(_ => code))[..length];
    }
}
