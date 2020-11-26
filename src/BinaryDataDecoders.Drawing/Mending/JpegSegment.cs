namespace BinaryDataDecoders.Drawing.Mending
{
    public class JpegSegment
    {
        public int Index { get; internal set; }
        public byte Prefix { get; internal set; }
        public byte Type { get; internal set; }
        public ushort Length { get; internal set; }
        public byte[] Data { get; internal set; }
    }
}
