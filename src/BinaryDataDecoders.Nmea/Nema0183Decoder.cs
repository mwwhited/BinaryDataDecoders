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

            var checkSplit = ascii.LastIndexOf('*');
            var sentence = ascii[1..checkSplit];
            var checksum = Convert.ToInt32(ascii[(checkSplit + 1)..], 16);
            var calculatedChecksum = sentence.Aggregate((char)0, (v, c) => (char)(v ^ c), c => (int)c);

            if (checksum != calculatedChecksum)
                throw new InvalidOperationException("checksum mismatch");

            var split = sentence.Split(',');
            return split[0][2..5] switch
            {
                "GGA" => new GlobalPositioningFixData(data: split),
                "GSA" => new GpsDopAndActiveSatellites(data: split),
                // "GPGSV" => new SatellitesInView(data: split),
                // "GPRMC" => new RecommendedMinimumNavigationInformation(data: split),

                _ => new StringNemaMessage(ascii)
            };
        }
    }
}
