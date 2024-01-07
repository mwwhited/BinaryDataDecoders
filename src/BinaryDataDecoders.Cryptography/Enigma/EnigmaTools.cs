using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.Cryptography.Enigma;

public static class EnigmaTools
{
    public static IEnumerable<char> Clean(this IEnumerable<char> input) =>
        input.Select(c => (char)(c > 'Z' ? c - 32 : c))
                    .Where(c => c >= 'A' && c <= 'Z');
    public static string AsString(this IEnumerable<char> input) =>
        new string(input.ToArray());

    public static IEnumerable<string> SplitAt(this string input, int at = 2) =>
        Enumerable.Range(0, input.Length / at)
                  .Select(i => input.Substring(i * at, at));

    internal static string SwapSet(this string input, string[]? swaps)
    {
        if (swaps == null)
            return input;
        return swaps.Aggregate(new StringBuilder(input ?? ""),
                               (sb, s) => sb.Replace(s[0], '_')
                                            .Replace(s[1], s[0])
                                            .Replace('_', s[1]),
                               sb => sb.ToString());
    }
}
