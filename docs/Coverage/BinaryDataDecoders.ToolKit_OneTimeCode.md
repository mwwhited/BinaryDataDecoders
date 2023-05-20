# BinaryDataDecoders.ToolKit.Security.Cryptography.OneTimeCode

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Security.Cryptography.OneTimeCode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `41`                                                           |
| Coverablelines  | `41`                                                           |
| Totallines      | `108`                                                          |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `16`                                                           |
| Branchcoverage  | `0`                                                            |
| Coveredmethods  | `0`                                                            |
| Totalmethods    | `8`                                                            |
| Methodcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `cctor`             |
| 1          | 0     | 100      | `GetCurrentCounter` |
| 2          | 0     | 0        | `GenerateToken`     |
| 2          | 0     | 0        | `GetToken`          |
| 10         | 0     | 0        | `IsValid`           |
| 1          | 0     | 100      | `GenerateSecret`    |
| 1          | 0     | 100      | `GetKey`            |
| 2          | 0     | 0        | `GetUri`            |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Security/Cryptography/OneTimeCode.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Codecs;
〰2:   using System;
〰3:   using System.Security.Cryptography;
〰4:   using System.Text;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Security.Cryptography
〰7:   {
〰8:       public class OneTimeCode
〰9:       {
‼10:          public static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
‼11:          public static readonly Base32Codec Base32Encoding = new Base32Codec();
〰12:  
〰13:          public long GetCurrentCounter()
〰14:          {
‼15:              var counter = (long)(DateTime.UtcNow - OneTimeCode.UNIX_EPOCH).TotalSeconds / 30;
‼16:              return counter;
〰17:          }
〰18:  
〰19:          public string GenerateToken(string secret, long iterationNumber, int digits = 6)
〰20:          {
‼21:              var counter = BitConverter.GetBytes(iterationNumber);
〰22:  
‼23:              if (BitConverter.IsLittleEndian)
‼24:                  Array.Reverse(counter);
〰25:  
‼26:              var key = GetKey(secret);
〰27:  
‼28:              using (var hmac = new HMACSHA1(key, true))
〰29:              {
‼30:                  var hash = hmac.ComputeHash(counter);
〰31:  
‼32:                  var offset = hash[hash.Length - 1] & 0xf;
〰33:  
‼34:                  var binary =
‼35:                      ((hash[offset] & 0x7f) << 24)
‼36:                      | ((hash[offset + 1] & 0xff) << 16)
‼37:                      | ((hash[offset + 2] & 0xff) << 8)
‼38:                      | (hash[offset + 3] & 0xff);
〰39:  
‼40:                  var password = binary % (int)Math.Pow(10, digits); // 6 digits
〰41:  
‼42:                  var result = password.ToString(new string('0', digits));
〰43:  
‼44:                  return result;
〰45:              }
‼46:          }
〰47:  
〰48:          public  string GetToken(string secret, long? counter = null)
〰49:          {
‼50:              return GenerateToken(secret, counter ?? GetCurrentCounter());
〰51:          }
〰52:  
〰53:          public  bool IsValid(string secret, string token, int checkAdjacentIntervals = 1)
〰54:          {
‼55:              if (token == GetToken(secret))
‼56:                  return true;
〰57:  
‼58:              if (checkAdjacentIntervals < 1)
‼59:                  checkAdjacentIntervals = 1;
〰60:  
‼61:              for (int i = 1; i <= checkAdjacentIntervals; i++)
〰62:              {
〰63:                  string check;
‼64:                  if (token == (check = GetToken(secret, GetCurrentCounter() + i)))
〰65:                  {
‼66:                      return true;
〰67:                  }
‼68:                  if (token == (check = GetToken(secret, GetCurrentCounter() - i)))
〰69:                  {
‼70:                      return true;
〰71:                  }
〰72:              }
‼73:              return false;
〰74:          }
〰75:  
〰76:          public  string GenerateSecret()
〰77:          {
‼78:              var buffer = new byte[9];
〰79:  
‼80:              using (var rng = RNGCryptoServiceProvider.Create())
〰81:              {
‼82:                  rng.GetBytes(buffer);
‼83:              }
〰84:  
‼85:              var secret = Convert.ToBase64String(buffer).Substring(0, 10).Replace('/', '0').Replace('+', '1');
〰86:  
‼87:              var encoded = Base32Encoding.Encode(Encoding.ASCII.GetBytes(secret));
‼88:              return encoded;
〰89:          }
〰90:  
〰91:          public  byte[] GetKey(string secret)
〰92:          {
‼93:              var decoded = Base32Encoding.Decode(secret);
‼94:              return decoded;
〰95:          }
〰96:  
〰97:          public  string GetUri(string secret, string issuer, string account = null, Types type = Types.TOTP)
〰98:          {
‼99:              return $"otpauth://{type.ToString().ToLower()}/{issuer}{(!string.IsNullOrWhiteSpace(account) ? ":" + account : null)}?secret={secret}&issuer={issuer}";
〰100:         }
〰101: 
〰102:         public enum Types
〰103:         {
〰104:             HOTP,
〰105:             TOTP,
〰106:         }
〰107:     }
〰108: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

