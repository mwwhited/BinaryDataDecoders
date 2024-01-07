namespace BinaryDataDecoders.Drawing.Mending;

public record JpegSegment
{
    public int Index { get; init; }
    public byte Prefix { get; init; }
    public byte Type { get; init; }
    public ushort Length { get; init; }
    public required byte[] Data { get; init; }
}
