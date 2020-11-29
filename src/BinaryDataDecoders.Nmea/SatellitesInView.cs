namespace BinaryDataDecoders.Nmea
{
    public class SatellitesInView : INema0183Message
    {
        /*
        GSV - Satellites in view
        This is one of the sentences commonly emitted by GPS units.

        These sentences describe the sky position of a UPS satellite in view. Typically they’re shipped in a group of 2 or 3.

	        1 2 3 4 5 6 7     n
	        | | | | | | |     |
         $--GSV,x,x,x,x,x,x,x,...*hh<CR><LF>
        Field Number:

        total number of GSV sentences to be transmitted in this group
        Sentence number, 1-9 of this GSV message within current group
        total number of satellites in view (leading zeros sent)
        satellite ID number (leading zeros sent)
        elevation in degrees (-90 to 90) (leading zeros sent)
        azimuth in degrees to true north (000 to 359) (leading zeros sent)
        SNR in dB (00-99) (leading zeros sent) more satellite info quadruples like 4-7 n) checksum
        Example: 
            $GPGSV,3,1,11,03,03,111,00,04,15,270,00,06,01,010,00,13,06,292,00*74 
            $GPGSV,3,2,11,14,25,170,00,16,57,208,39,18,67,296,40,19,40,246,00*74 
            $GPGSV,3,3,11,22,42,067,42,24,14,311,43,27,05,244,00,,,,*4D

        Some GPS receivers may emit more than 12 quadruples (more than three GPGSV sentences), 
            even though NMEA-0813 doesn’t allow this. (The extras might be WAAS satellites, for example.) 
            Receivers may also report quads for satellites they aren’t tracking, in which case the SNR field 
            will be null; we don’t know whether this is formally allowed or not.

        Example: $GLGSV,3,3,09,88,07,028,*51

        GTD - Geographic Location in Time Differences
 	         1   2   3   4   5  6
	         |   |   |   |   |  |
         $--GTD,x.x,x.x,x.x,x.x,x.x*hh<CR><LF>

        GSV - Satellites in View shows data about the satellites that the unit might be able to find based on its viewing mask and almanac
        data. It also shows current ability to track this data. Note that one GSV sentence only can provide data for up to 4 satellites and 
        thus there may need to be 3 sentences for the full information. It is reasonable for the GSV sentence to contain more satellites than
        GGA might indicate since GSV may include satellites that are not used as part of the solution. It is not a requirment that the GSV
        sentences all appear in sequence. To avoid overloading the data bandwidth some receivers may place the various sentences in totally 
        different samples since each sentence identifies which one it is.

        The field called SNR (Signal to Noise Ratio) in the NMEA standard is often referred to as signal strength. SNR is an indirect but
        more useful value that raw signal strength. It can range from 0 to 99 and has units of dB according to the NMEA standard, but the 
        various manufacturers send different ranges of numbers with different starting numbers so the values themselves cannot necessarily 
        be used to evaluate different units. The range of working values in a given gps will usually show a difference of about 25 to 35 
        between the lowest and highest values, however 0 is a special case and may be shown on satellites that are in view but not being tracked.

          $GPGSV,2,1,08,01,40,083,46,02,17,308,41,12,07,344,39,14,22,228,45*75

        Where:
              GSV          Satellites in view
              2            Number of sentences for full data
              1            sentence 1 of 2
              08           Number of satellites in view

              01           Satellite PRN number
              40           Elevation, degrees
              083          Azimuth, degrees
              46           SNR - higher is better
                   for up to 4 satellites per sentence
              *75          the checksum data, always begins with *

        */
        public SatellitesInView(string[] data)
        {
        }
    }
}