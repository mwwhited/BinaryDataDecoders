# BinaryDataDecoders.Nmea.Nema0183Decoder

## Summary

| Key             | Value                                     |
| :-------------- | :---------------------------------------- |
| Class           | `BinaryDataDecoders.Nmea.Nema0183Decoder` |
| Assembly        | `BinaryDataDecoders.Nmea`                 |
| Coveredlines    | `0`                                       |
| Uncoveredlines  | `19`                                      |
| Coverablelines  | `19`                                      |
| Totallines      | `36`                                      |
| Linecoverage    | `0`                                       |
| Coveredbranches | `0`                                       |
| Totalbranches   | `6`                                       |
| Branchcoverage  | `0`                                       |
| Coveredmethods  | `0`                                       |
| Totalmethods    | `1`                                       |
| Methodcoverage  | `0`                                       |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 6          | 0     | 0        | `Decode` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/Nema0183Decoder.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System;
〰3:   using System.Buffers;
〰4:   using System.Linq;
〰5:   using System.Text;
〰6:   
〰7:   namespace BinaryDataDecoders.Nmea;
〰8:   
〰9:   public class Nema0183Decoder : IMessageDecoder<INema0183Message>
〰10:  {
〰11:      public INema0183Message Decode(ReadOnlySequence<byte> response)
〰12:      {
‼13:          Span<byte> buffer = new byte[response.Length];
‼14:          response.CopyTo(buffer);
‼15:          var ascii = Encoding.ASCII.GetString(buffer.ToArray().Where(b => b >= 0x20).ToArray());
〰16:  
‼17:          var checkSplit = ascii.LastIndexOf('*');
‼18:          var sentence = ascii[1..checkSplit];
‼19:          var checksum = Convert.ToInt32(ascii[(checkSplit + 1)..], 16);
‼20:          var calculatedChecksum = sentence.Aggregate((char)0, (v, c) => (char)(v ^ c), c => (int)c);
〰21:  
‼22:          if (checksum != calculatedChecksum)
‼23:              throw new InvalidOperationException("checksum mismatch");
〰24:  
‼25:          var split = sentence.Split(',');
‼26:          return split[0][2..5] switch
‼27:          {
‼28:              "GGA" => new GlobalPositioningFixData(data: split),
‼29:              "GSA" => new GpsDopAndActiveSatellites(data: split),
‼30:              // "GPGSV" => new SatellitesInView(data: split),
‼31:              // "GPRMC" => new RecommendedMinimumNavigationInformation(data: split),
‼32:  
‼33:              _ => new StringNemaMessage(ascii)
‼34:          };
〰35:      }
〰36:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

