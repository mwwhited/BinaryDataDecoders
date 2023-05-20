# BinaryDataDecoders.ToolKit.Security.Cryptography.OneTimeCode

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Security.Cryptography.OneTimeCode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `38`                                                           |
| Coverablelines  | `38`                                                           |
| Totallines      | `99`                                                           |
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
‼28:              using var hmac = new HMACSHA1(key);
‼29:              var hash = hmac.ComputeHash(counter);
〰30:  
‼31:              var offset = hash[hash.Length - 1] & 0xf;
〰32:  
‼33:              var binary =
‼34:                  ((hash[offset] & 0x7f) << 24)
‼35:                  | ((hash[offset + 1] & 0xff) << 16)
‼36:                  | ((hash[offset + 2] & 0xff) << 8)
‼37:                  | (hash[offset + 3] & 0xff);
〰38:  
‼39:              var password = binary % (int)Math.Pow(10, digits); // 6 digits
〰40:  
‼41:              var result = password.ToString(new string('0', digits));
〰42:  
‼43:              return result;
‼44:          }
〰45:  
〰46:          public string GetToken(string secret, long? counter = null)
〰47:          {
‼48:              return GenerateToken(secret, counter ?? GetCurrentCounter());
〰49:          }
〰50:  
〰51:          public bool IsValid(string secret, string token, int checkAdjacentIntervals = 1)
〰52:          {
‼53:              if (token == GetToken(secret))
‼54:                  return true;
〰55:  
‼56:              if (checkAdjacentIntervals < 1)
‼57:                  checkAdjacentIntervals = 1;
〰58:  
‼59:              for (int i = 1; i <= checkAdjacentIntervals; i++)
〰60:              {
〰61:                  string check;
‼62:                  if (token == (check = GetToken(secret, GetCurrentCounter() + i)))
〰63:                  {
‼64:                      return true;
〰65:                  }
‼66:                  if (token == (check = GetToken(secret, GetCurrentCounter() - i)))
〰67:                  {
‼68:                      return true;
〰69:                  }
〰70:              }
‼71:              return false;
〰72:          }
〰73:  
〰74:          public string GenerateSecret()
〰75:          {
‼76:              var buffer = RandomNumberGenerator.GetBytes(9);
‼77:              var secret = Convert.ToBase64String(buffer).Substring(0, 10).Replace('/', '0').Replace('+', '1');
‼78:              var encoded = Base32Encoding.Encode(Encoding.ASCII.GetBytes(secret));
‼79:              return encoded;
〰80:          }
〰81:  
〰82:          public byte[] GetKey(string secret)
〰83:          {
‼84:              var decoded = Base32Encoding.Decode(secret);
‼85:              return decoded;
〰86:          }
〰87:  
〰88:          public string GetUri(string secret, string issuer, string account = null, Types type = Types.TOTP)
〰89:          {
‼90:              return $"otpauth://{type.ToString().ToLower()}/{issuer}{(!string.IsNullOrWhiteSpace(account) ? ":" + account : null)}?secret={secret}&issuer={issuer}";
〰91:          }
〰92:  
〰93:          public enum Types
〰94:          {
〰95:              HOTP,
〰96:              TOTP,
〰97:          }
〰98:      }
〰99:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

