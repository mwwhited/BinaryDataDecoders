namespace BinaryDataDecoders.Drawing.Mending
{
    public class JpegSegment
    {
        public int Index { get; init; }
        public byte Prefix { get; init; }
        public byte Type { get; init; }
        public ushort Length { get; init; }
        public byte[] Data { get; init; }
    }
}
