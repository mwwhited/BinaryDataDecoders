namespace BinaryDataDecoders.Nmea
{
    public class GpsDopAndActiveSatellites : INema0183Message
    {
        /*
        GSA - GPS DOP and active satellites
        This is one of the sentences commonly emitted by GPS units.

	        1 2 3                        14 15  16  17  18
	        | | |                         |  |   |   |   |
         $--GSA,a,a,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x.x,x.x,x.x*hh<CR><LF>
        Field Number:

        Selection mode: M=Manual, forced to operate in 2D or 3D, A=Automatic, 2D/3D
        Mode (1 = no fix, 2 = 2D fix, 3 = 3D fix)
        ID of 1st satellite used for fix
        ID of 2nd satellite used for fix
        ID of 3rd satellite used for fix
        ID of 4th satellite used for fix
        ID of 5th satellite used for fix
        ID of 6th satellite used for fix
        ID of 7th satellite used for fix
        ID of 8th satellite used for fix
        ID of 9th satellite used for fix
        ID of 10th satellite used for fix
        ID of 11th satellite used for fix
        ID of 12th satellite used for fix
        PDOP
        HDOP
        VDOP
        Checksum
        Example: $GNGSA,A,3,80,71,73,79,69,,,,,,,,1.83,1.09,1.47*17
        Note: NMEA 4.1+ systems (in particular u-blox 9) emit an extra field just before the checksum.

        1 = GPS L1C/A, L2CL, L2CM
        2 = GLONASS L1 OF, L2 OF
        3 = Galileo E1C, E1B, E5 bl, E5 bQ
        4 = BeiDou B1I D1, B1I D2, B2I D1, B2I D12
       
        */

        public GpsDopAndActiveSatellites(string[] data)
        {
        }
    }
}