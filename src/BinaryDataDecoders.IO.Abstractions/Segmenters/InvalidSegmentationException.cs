using System;

namespace BinaryDataDecoders.IO.Segmenters;

[Serializable]
public class InvalidSegmentationException : Exception
{
    public InvalidSegmentationException()
    {
    }
}