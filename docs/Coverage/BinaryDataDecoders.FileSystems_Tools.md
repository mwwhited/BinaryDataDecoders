
# BinaryDataDecoders.FileSystems.Iso9660.Tools
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.FileSystems_Tools.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.FileSystems.Iso9660.Tools                 | 
| Assembly             | BinaryDataDecoders.FileSystems                               | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 24                                                           | 
| Coverablelines       | 24                                                           | 
| Totallines           | 64                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 4                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.FileSystems\Iso9660\Tools.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 2          | 0     | 0        | ToHexString | 
| 1          | 0     | 100      | GetString | 
| 1          | 0     | 100      | GetUInt32 | 
| 1          | 0     | 100      | GetUInt16 | 
| 2          | 0     | 0        | GetDateTime | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.FileSystems\Iso9660\Tools.cs

```CSharp
〰1:   using System;
〰2:   using System.Globalization;
〰3:   using System.Text;
〰4:   using System.Threading;
〰5:   
〰6:   namespace BinaryDataDecoders.FileSystems.Iso9660
〰7:   {
〰8:       public static class Tools
〰9:       {
〰10:          public static string ToHexString(this byte[] buffer)
〰11:          {
‼12:              var sb = new StringBuilder(buffer.Length * 3);
‼13:              foreach (var item in buffer)
‼14:                  sb.AppendFormat("{0:X2} ", item);
‼15:              return sb.ToString();
〰16:          }
〰17:  
〰18:          public static string GetString(this byte[] buffer,
〰19:                                          ref int offset,
〰20:                                              int length,
〰21:                                              Encoding encoding)
〰22:          {
‼23:              var ret = encoding.GetString(buffer, offset, length)
‼24:                                .Trim(' ', '\0', '\t'); //, '\x01'
‼25:              offset += length;
‼26:              return ret;
〰27:          }
〰28:  
〰29:          public static uint GetUInt32(this byte[] buffer,
〰30:                                        ref int offset,
〰31:                                            int length)
〰32:          {
‼33:              var ret = BitConverter.ToUInt32(buffer, offset);
‼34:              offset += length;
‼35:              return ret;
〰36:          }
〰37:  
〰38:          public static ushort GetUInt16(this byte[] buffer,
〰39:                                          ref int offset,
〰40:                                              int length)
〰41:          {
‼42:              var ret = BitConverter.ToUInt16(buffer, offset);
‼43:              offset += length;
‼44:              return ret;
〰45:          }
〰46:  
〰47:          public static DateTime GetDateTime(this byte[] buffer,
〰48:                                              ref int offset,
〰49:                                                  int length)
〰50:          {
‼51:              var temp = Encoding.ASCII.GetString(buffer, offset, 16).Trim();
‼52:              var timeOffset = (sbyte)buffer[offset + 16] * 15;
〰53:              DateTime ret;
‼54:              if (DateTime.TryParseExact(temp,
‼55:                                         "yyyyMMddHHmmssff",
‼56:                                         Thread.CurrentThread.CurrentCulture,
‼57:                                         DateTimeStyles.AdjustToUniversal,
‼58:                                         out ret))
‼59:                  ret = ret.AddMinutes(timeOffset);
‼60:              offset += length;
‼61:              return ret;
〰62:          }
〰63:      }
〰64:  }

```
## Footer 
[Return to Summary](Summary.md)

