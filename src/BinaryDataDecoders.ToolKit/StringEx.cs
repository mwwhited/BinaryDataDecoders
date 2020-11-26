using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BinaryDataDecoders.ToolKit
{
    public static class StringEx
    {
        public static string? AsSha256(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            var buffer = Encoding.UTF8.GetBytes(text);
            using (var hashstring = new SHA256Managed())
            {
                var hash = hashstring.ComputeHash(buffer);
                var result = hash.Aggregate(new StringBuilder(), (sb, v) => sb.AppendFormat("{0:x2}", v));
                return result.ToString();
            }
        }
    }
}
