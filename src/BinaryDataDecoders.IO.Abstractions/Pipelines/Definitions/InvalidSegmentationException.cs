using System;
using System.Runtime.Serialization;

namespace BinaryDataDecoders.IO.Pipelines.Definitions
{
    [Serializable]
    public class InvalidSegmentationException : Exception
    {
        public InvalidSegmentationException()
        {
        }

        public InvalidSegmentationException(string message) : base(message)
        {
        }

        public InvalidSegmentationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSegmentationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}