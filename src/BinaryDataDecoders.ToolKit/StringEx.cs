using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BinaryDataDecoders.ToolKit;

public static class StringEx
{
    public static string? AsSha256(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null;

        using var hashstring = SHA256.Create();
        return text.AsHash(hashstring);
    }
    public static string? AsMd5(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null;

        using var hashstring = MD5.Create();
        return text.AsHash(hashstring);
    }
    public static string? AsHash(this string text, HashAlgorithm hashAlgorithm)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null;

        var buffer = Encoding.UTF8.GetBytes(text);
        var hash = hashAlgorithm.ComputeHash(buffer);
        var result = hash.Aggregate(new StringBuilder(), (sb, v) => sb.AppendFormat("{0:x2}", v));
        return result.ToString();
    }
}
