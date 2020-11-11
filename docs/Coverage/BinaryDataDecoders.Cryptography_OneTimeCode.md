# BinaryDataDecoders.Cryptography.OneTimeCode

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.OneTimeCode` |
| Assembly        | `BinaryDataDecoders.Cryptography`             |
| Coveredlines    | `0`                                           |
| Uncoveredlines  | `46`                                          |
| Coverablelines  | `46`                                          |
| Totallines      | `102`                                         |
| Linecoverage    | `0`                                           |
| Coveredbranches | `0`                                           |
| Totalbranches   | `14`                                          |
| Branchcoverage  | `0`                                           |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `cctor`             |
| 1          | 0     | 100      | `GetCurrentCounter` |
| 2          | 0     | 0        | `GenerateToken`     |
| 2          | 0     | 0        | `GetToken`          |
| 8          | 0     | 0        | `IsValid`           |
| 1          | 0     | 100      | `GenerateSecret`    |
| 1          | 0     | 100      | `GetKey`            |
| 2          | 0     | 0        | `GetUri`            |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Cryptography\OneTimeCode.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Codecs;
〰2:   using System;
〰3:   using System.Security.Cryptography;
〰4:   using System.Text;
〰5:   
〰6:   namespace BinaryDataDecoders.Cryptography
〰7:   {
〰8:       public class OneTimeCode
〰9:       {
‼10:          public static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
〰11:          public long GetCurrentCounter()
〰12:          {
‼13:              var counter = (long)(DateTime.UtcNow - OneTimeCode.UNIX_EPOCH).TotalSeconds / 30;
‼14:              return counter;
〰15:          }
〰16:  
〰17:          public string GenerateToken(string secret, long iterationNumber, int digits = 6)
〰18:          {
‼19:              var counter = BitConverter.GetBytes(iterationNumber);
〰20:  
‼21:              if (BitConverter.IsLittleEndian)
‼22:                  Array.Reverse(counter);
〰23:  
‼24:              var key = this.GetKey(secret);
〰25:  
‼26:              var hmac = new HMACSHA1(key, true);
〰27:  
‼28:              var hash = hmac.ComputeHash(counter);
〰29:  
‼30:              var offset = hash[hash.Length - 1] & 0xf;
〰31:  
‼32:              var binary =
‼33:                  ((hash[offset] & 0x7f) << 24)
‼34:                  | ((hash[offset + 1] & 0xff) << 16)
‼35:                  | ((hash[offset + 2] & 0xff) << 8)
‼36:                  | (hash[offset + 3] & 0xff);
〰37:  
‼38:              var password = binary % (int)Math.Pow(10, digits); // 6 digits
〰39:  
‼40:              var result = password.ToString(new string('0', digits));
〰41:  
‼42:              return result;
〰43:          }
〰44:  
‼45:          public string GetToken(string secret, long? counter = null) => GenerateToken(secret, counter ?? this.GetCurrentCounter());
〰46:  
〰47:          public bool IsValid(string secret, string token, int checkAdjacentIntervals = 1)
〰48:          {
‼49:              if (token == this.GetToken(secret))
‼50:                  return true;
〰51:  
‼52:              for (int i = 1; i <= checkAdjacentIntervals; i++)
〰53:              {
‼54:                  Console.Write("{0}", i);
‼55:                  Console.WriteLine("{0}", token);
‼56:                  if (token == this.GetToken(secret, this.GetCurrentCounter() + i))
〰57:                  {
‼58:                      Console.WriteLine("+{0}", i);
‼59:                      return true;
〰60:                  }
‼61:                  if (token == this.GetToken(secret, this.GetCurrentCounter() - i))
〰62:                  {
‼63:                      Console.WriteLine("-{0}", i);
‼64:                      return true;
〰65:                  }
〰66:              }
‼67:              Console.WriteLine();
‼68:              return false;
〰69:          }
〰70:  
〰71:          public string GenerateSecret()
〰72:          {
‼73:              var buffer = new byte[9];
〰74:  
‼75:              using var rng = RNGCryptoServiceProvider.Create();
‼76:              rng.GetBytes(buffer);
〰77:  
‼78:              var secret = Convert.ToBase64String(buffer).Substring(0, 10).Replace('/', '0').Replace('+', '1');
‼79:              var encoded = new Base32Codec().Encode(Encoding.ASCII.GetBytes(secret));
‼80:              return encoded;
‼81:          }
〰82:  
〰83:          public byte[] GetKey(string secret)
〰84:          {
‼85:              var decoded = new Base32Codec().Decode(secret);
‼86:              return decoded;
〰87:          }
〰88:  
〰89:          public string GetUri(string secret, string issuer, string account = null, Types type = Types.TOTP) =>
‼90:              string.Format("otpauth://{0}/{1}{2}?secret={3}&issuer={1}",
‼91:                  type.ToString().ToLower(),
‼92:                  issuer,
‼93:                  !string.IsNullOrWhiteSpace(account) ? ":" + account : null,
‼94:                  secret);
〰95:  
〰96:          public enum Types
〰97:          {
〰98:              HOTP,
〰99:              TOTP,
〰100:         }
〰101:     }
〰102: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

