# BinaryDataDecoders.Nmea.SatellitesInView

## Summary

| Key             | Value                                      |
| :-------------- | :----------------------------------------- |
| Class           | `BinaryDataDecoders.Nmea.SatellitesInView` |
| Assembly        | `BinaryDataDecoders.Nmea`                  |
| Coveredlines    | `0`                                        |
| Uncoveredlines  | `2`                                        |
| Coverablelines  | `2`                                        |
| Totallines      | `73`                                       |
| Linecoverage    | `0`                                        |
| Coveredbranches | `0`                                        |
| Totalbranches   | `0`                                        |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/SatellitesInView.cs

```CSharp
〰1:   namespace BinaryDataDecoders.Nmea
〰2:   {
〰3:       public class SatellitesInView : INema0183Message
〰4:       {
〰5:           /*
〰6:           GSV - Satellites in view
〰7:           This is one of the sentences commonly emitted by GPS units.
〰8:   
〰9:           These sentences describe the sky position of a UPS satellite in view. Typically they’re shipped in a group of 2 or 3.
〰10:  
〰11:  	        1 2 3 4 5 6 7     n
〰12:  	        | | | | | | |     |
〰13:           $--GSV,x,x,x,x,x,x,x,...*hh<CR><LF>
〰14:          Field Number:
〰15:  
〰16:          total number of GSV sentences to be transmitted in this group
〰17:          Sentence number, 1-9 of this GSV message within current group
〰18:          total number of satellites in view (leading zeros sent)
〰19:          satellite ID number (leading zeros sent)
〰20:          elevation in degrees (-90 to 90) (leading zeros sent)
〰21:          azimuth in degrees to true north (000 to 359) (leading zeros sent)
〰22:          SNR in dB (00-99) (leading zeros sent) more satellite info quadruples like 4-7 n) checksum
〰23:          Example:
〰24:              $GPGSV,3,1,11,03,03,111,00,04,15,270,00,06,01,010,00,13,06,292,00*74
〰25:              $GPGSV,3,2,11,14,25,170,00,16,57,208,39,18,67,296,40,19,40,246,00*74
〰26:              $GPGSV,3,3,11,22,42,067,42,24,14,311,43,27,05,244,00,,,,*4D
〰27:  
〰28:          Some GPS receivers may emit more than 12 quadruples (more than three GPGSV sentences),
〰29:              even though NMEA-0813 doesn’t allow this. (The extras might be WAAS satellites, for example.)
〰30:              Receivers may also report quads for satellites they aren’t tracking, in which case the SNR field
〰31:              will be null; we don’t know whether this is formally allowed or not.
〰32:  
〰33:          Example: $GLGSV,3,3,09,88,07,028,*51
〰34:  
〰35:          GTD - Geographic Location in Time Differences
〰36:   	         1   2   3   4   5  6
〰37:  	         |   |   |   |   |  |
〰38:           $--GTD,x.x,x.x,x.x,x.x,x.x*hh<CR><LF>
〰39:  
〰40:          GSV - Satellites in View shows data about the satellites that the unit might be able to find based on its viewing mask and almanac
〰41:          data. It also shows current ability to track this data. Note that one GSV sentence only can provide data for up to 4 satellites and
〰42:          thus there may need to be 3 sentences for the full information. It is reasonable for the GSV sentence to contain more satellites than
〰43:          GGA might indicate since GSV may include satellites that are not used as part of the solution. It is not a requirment that the GSV
〰44:          sentences all appear in sequence. To avoid overloading the data bandwidth some receivers may place the various sentences in totally
〰45:          different samples since each sentence identifies which one it is.
〰46:  
〰47:          The field called SNR (Signal to Noise Ratio) in the NMEA standard is often referred to as signal strength. SNR is an indirect but
〰48:          more useful value that raw signal strength. It can range from 0 to 99 and has units of dB according to the NMEA standard, but the
〰49:          various manufacturers send different ranges of numbers with different starting numbers so the values themselves cannot necessarily
〰50:          be used to evaluate different units. The range of working values in a given gps will usually show a difference of about 25 to 35
〰51:          between the lowest and highest values, however 0 is a special case and may be shown on satellites that are in view but not being tracked.
〰52:  
〰53:            $GPGSV,2,1,08,01,40,083,46,02,17,308,41,12,07,344,39,14,22,228,45*75
〰54:  
〰55:          Where:
〰56:                GSV          Satellites in view
〰57:                2            Number of sentences for full data
〰58:                1            sentence 1 of 2
〰59:                08           Number of satellites in view
〰60:  
〰61:                01           Satellite PRN number
〰62:                40           Elevation, degrees
〰63:                083          Azimuth, degrees
〰64:                46           SNR - higher is better
〰65:                     for up to 4 satellites per sentence
〰66:                *75          the checksum data, always begins with *
〰67:  
〰68:          */
‼69:          public SatellitesInView(string[] data)
〰70:          {
‼71:          }
〰72:      }
〰73:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

