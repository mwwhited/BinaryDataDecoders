using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BinaryDataDecoders.Net;

public partial class ConvertEx
{
    public static bool IsHexString(string hexString) =>
        HexStringRegex().IsMatch(hexString);

    public static byte[] FromHexString(string hexString)
    {
        InvalidHexadecimalStringException.Check(hexString);

        var len = hexString.Length;

        var buffer = new byte[len / 2];

        for (var i = 0; i < len; i += 2)
        {
            var part = hexString.Substring(i, 2);
            var parsed = byte.Parse(part, NumberStyles.HexNumber);
            buffer[i / 2] = parsed;
        }

        return buffer;
    }

    public static string ToHexString(byte[] buffer)
    {
        return buffer.Aggregate(new StringBuilder(), (sb, v) => sb.Append(v), sb => sb.ToString());
    }

    [GeneratedRegex("([0-9a-fA-F]{2}){1,}", RegexOptions.Compiled)]
    private static partial Regex HexStringRegex();
}
