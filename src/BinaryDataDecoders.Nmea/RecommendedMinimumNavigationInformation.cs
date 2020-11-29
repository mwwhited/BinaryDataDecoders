namespace BinaryDataDecoders.Nmea
{
    public class RecommendedMinimumNavigationInformation : INema0183Message
    {
        /*
        RMC - Recommended Minimum Navigation Information
        This is one of the sentences commonly emitted by GPS units.

                                                                  12
                1         2 3       4 5        6  7   8   9    10 11|  13
                |         | |       | |        |  |   |   |    |  | |   |
         $--RMC,hhmmss.ss,A,llll.ll,a,yyyyy.yy,a,x.x,x.x,xxxx,x.x,a,m,*hh<CR><LF>
        Field Number:

        UTC Time of position

        Status, A = Valid, V = Warning
        Latitude        N or S
        Longitude        E or W
        Speed over ground, knots
        Track made good, degrees true
        Date, ddmmyy
        Magnetic Variation, degrees        E or W
        FAA mode indicator (NMEA 2.3 and later)
        Checksum

        A status of V means the GPS has a valid fix that is below an internal quality threshold, e.g. because the dilution of precision is too high or an elevation mask test failed.

        Example: $GNRMC,001031.00,A,4404.13993,N,12118.86023,W,0.146,,100117,,,A*7B
        */
        public RecommendedMinimumNavigationInformation(string[] data)
        {
        }
    }
}