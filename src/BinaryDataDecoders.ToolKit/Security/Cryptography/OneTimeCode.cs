using BinaryDataDecoders.ToolKit.Codecs;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BinaryDataDecoders.ToolKit.Security.Cryptography
{
    public class OneTimeCode
    {
        public static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static readonly Base32Codec Base32Encoding = new Base32Codec();

        public long GetCurrentCounter()
        {
            var counter = (long)(DateTime.UtcNow - OneTimeCode.UNIX_EPOCH).TotalSeconds / 30;
            return counter;
        }

        public string GenerateToken(string secret, long iterationNumber, int digits = 6)
        {
            var counter = BitConverter.GetBytes(iterationNumber);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(counter);

            var key = GetKey(secret);

            using (var hmac = new HMACSHA1(key, true))
            {
                var hash = hmac.ComputeHash(counter);

                var offset = hash[hash.Length - 1] & 0xf;

                var binary =
                    ((hash[offset] & 0x7f) << 24)
                    | ((hash[offset + 1] & 0xff) << 16)
                    | ((hash[offset + 2] & 0xff) << 8)
                    | (hash[offset + 3] & 0xff);

                var password = binary % (int)Math.Pow(10, digits); // 6 digits

                var result = password.ToString(new string('0', digits));

                return result;
            }
        }

        public  string GetToken(string secret, long? counter = null)
        {
            return GenerateToken(secret, counter ?? GetCurrentCounter());
        }

        public  bool IsValid(string secret, string token, int checkAdjacentIntervals = 1)
        {
            if (token == GetToken(secret))
                return true;

            if (checkAdjacentIntervals < 1)
                checkAdjacentIntervals = 1;

            for (int i = 1; i <= checkAdjacentIntervals; i++)
            {
                string check;
                if (token == (check = GetToken(secret, GetCurrentCounter() + i)))
                {
                    return true;
                }
                if (token == (check = GetToken(secret, GetCurrentCounter() - i)))
                {
                    return true;
                }
            }
            return false;
        }

        public  string GenerateSecret()
        {
            var buffer = new byte[9];

            using (var rng = RNGCryptoServiceProvider.Create())
            {
                rng.GetBytes(buffer);
            }

            var secret = Convert.ToBase64String(buffer).Substring(0, 10).Replace('/', '0').Replace('+', '1');

            var encoded = Base32Encoding.Encode(Encoding.ASCII.GetBytes(secret));
            return encoded;
        }

        public  byte[] GetKey(string secret)
        {
            var decoded = Base32Encoding.Decode(secret);
            return decoded;
        }

        public  string GetUri(string secret, string issuer, string account = null, Types type = Types.TOTP)
        {
            return $"otpauth://{type.ToString().ToLower()}/{issuer}{(!string.IsNullOrWhiteSpace(account) ? ":" + account : null)}?secret={secret}&issuer={issuer}";
        }

        public enum Types
        {
            HOTP,
            TOTP,
        }
    }
}
