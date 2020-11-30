using System;
using System.Runtime.Serialization;

namespace BinaryDataDecoders.IO.Segmenters
{
    [Serializable]
    public class InvalidSegmentationException : Exception
    {
        public InvalidSegmentationException()
        {
        }
    }
}