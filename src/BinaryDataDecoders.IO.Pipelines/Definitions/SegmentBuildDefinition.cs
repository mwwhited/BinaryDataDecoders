namespace BinaryDataDecoders.IO.Pipelines.Definitions
{
    internal class SegmentBuildDefinition : ISegmentBuildDefinition
    {
        internal SegmentBuildDefinition(byte[] startsWith) => StartsWith = startsWith;
        internal SegmentExtensionDefinition? ExtensionDefinition { get; set; }
        internal SegmentionOptions Options { get; set; }
        internal byte[] StartsWith { get; }
        internal byte? EndsWith { get; set; }
        internal long? Length { get; set; }
        internal long? MaxLength { get; set; }
    }
}