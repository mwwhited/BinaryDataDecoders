using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Segmenters;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceDefinitionReceiver<TMessage> : IDeviceDefinition<TMessage>
    {
        ISegmentBuildDefinition SegmentDefintion { get; }
        IMessageDecoder<TMessage> Decoder { get; }
    }
}
