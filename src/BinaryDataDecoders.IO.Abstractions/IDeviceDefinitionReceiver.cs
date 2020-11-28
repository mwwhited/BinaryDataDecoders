using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Pipelines.Definitions;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceDefinitionReceiver<TMessage> : IDeviceDefinition // IDeviceReceiver
    {
        ISegmentBuildDefinition SegmentDefintion { get; }
        IMessageDecoder<TMessage> Decoder { get; }
    }
}
