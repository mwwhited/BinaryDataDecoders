using BinaryDataDecoders.IO.Messages;
using System;
using System.Buffers;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.Nmea
{
    public class Nema0183Decoder : IMessageDecoder<INema0183Message>
    {
        public INema0183Message Decode(ReadOnlySequence<byte> response)
        {
            Span<byte> buffer = new byte[response.Length];
            response.CopyTo(buffer);
            var ascii = Encoding.ASCII.GetString(buffer.ToArray().Where(b => b >= 0x20).ToArray());
            var split = ascii.Split(',');

            return split[0] switch
            {
                "$GPGGA" => new GlobalPositioningFixData(data: split),
                // "$GPGSA" => new GpsDopAndActiveSatellites(data: split),
                // "$GPGSV" => new SatellitesInView(data: split),
                //"$GPRMC" => new RecommendedMinimumNavigationInformation(data: split),

                _ => new StringNemaMessage(ascii)
            };
        }
    }
}
