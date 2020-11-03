using BinaryDataDecoders.ToolKit.Codecs;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BinaryDataDecoders.Cryptography
{
    public class OneTimeCode 
    {
        public static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
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

            var key = this.GetKey(secret);

            var hmac = new HMACSHA1(key, true);

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

        public string GetToken(string secret, long? counter = null) => GenerateToken(secret, counter ?? this.GetCurrentCounter());

        public bool IsValid(string secret, string token, int checkAdjacentIntervals = 1)
        {
            if (token == this.GetToken(secret))
                return true;

            for (int i = 1; i <= checkAdjacentIntervals; i++)
            {
                Console.Write("{0}", i);
                Console.WriteLine("{0}", token);
                if (token == this.GetToken(secret, this.GetCurrentCounter() + i))
                {
                    Console.WriteLine("+{0}", i);
                    return true;
                }
                if (token == this.GetToken(secret, this.GetCurrentCounter() - i))
                {
                    Console.WriteLine("-{0}", i);
                    return true;
                }
            }
            Console.WriteLine();
            return false;
        }

        public string GenerateSecret()
        {
            var buffer = new byte[9];

            using var rng = RNGCryptoServiceProvider.Create();
            rng.GetBytes(buffer);

            var secret = Convert.ToBase64String(buffer).Substring(0, 10).Replace('/', '0').Replace('+', '1');
            var encoded = new Base32Codec().Encode(Encoding.ASCII.GetBytes(secret));
            return encoded;
        }

        public byte[] GetKey(string secret)
        {
            var decoded = new Base32Codec().Decode(secret);
            return decoded;
        }

        public string GetUri(string secret, string issuer, string account = null, Types type = Types.TOTP) =>
            string.Format("otpauth://{0}/{1}{2}?secret={3}&issuer={1}",
                type.ToString().ToLower(),
                issuer,
                !string.IsNullOrWhiteSpace(account) ? ":" + account : null,
                secret);

        public enum Types
        {
            HOTP,
            TOTP,
        }
    }
}
