using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Pipelines.Definitions;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.Quarta.RadexOne;
using BinaryDataDecoders.ToolKit;
using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    [SerialPort(9600)]
    public class RadexOneDefinition : IDeviceTransmitter<IRadexObject>
    {
        //public RadexOneDefinition(
        //    OnMessageReceived<IRadexObject> received,
        //    OnException? onMessageReceivedError = null,
        //    OnException? onMessageTransmittedError = null
        //    )
        //{
        //    OnReceived = received;
        //    OnMessageReceivedError = onMessageReceivedError;
        //    OnMessageTransmittedError = onMessageTransmittedError;
        //}

        #region Receiver 

       // public OnException? OnMessageReceivedError { get; }

        //public OnMessageReceived<IRadexObject> OnReceived { get; }

        public IMessageDecoder<IRadexObject> Decoder { get; } = new RadexOneDecoder();
        public ISegmentBuildDefinition SegmentDefinition { get; } =
              Segment.StartsWith(0x7a)
                     .AndIsLength(12)
                     .ExtendedWithLengthAt<ushort>(4, Endianness.Little)
                     .WithOptions(SegmentionOptions.SkipInvalidSegment);

        //public ISegmenter BuildSegmenter() => SegmentDefinition.ThenAs(Decoder, OnReceived);

        #endregion Receiver

        #region Transmitter

        //public OnException? OnMessageTransmittedError { get; }
        public IMessageEncoder Encoder { get; } = new MessageEncoder();
        public IProducerConsumerCollection<IRadexObject> TrasmissionQueue { get; } = new ConcurrentQueue<IRadexObject>();
        public Task<bool> Transmit(IRadexObject message) => Task.FromResult(TrasmissionQueue.TryAdd(message));
        Task<bool> IDeviceTransmitter.Transmit(object message) => message switch
        {
            IRadexObject radex => Transmit(radex),
            _ => throw new NotSupportedException()
        };

        #endregion Transmitter
    }
}
