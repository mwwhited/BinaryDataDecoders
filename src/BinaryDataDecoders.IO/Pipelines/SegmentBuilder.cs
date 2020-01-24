namespace BinaryDataDecoders.IO.Pipelines
{
    internal class SegmentBuilder : ISegmentBuilder
    {
        internal SegmentBuilder(byte startsWith)
        {
            this.StartsWith = startsWith;
        }
        internal byte StartsWith { get; }
        internal byte? EndsWith { get; set; }
        internal long? Length { get; set; }
    }
}