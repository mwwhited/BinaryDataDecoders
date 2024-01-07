using System;

namespace BinaryDataDecoders.ToolKit.MetaData;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class MediaTypeAttribute(string mediaType) : Attribute
{
    public string MediaType { get; } = mediaType;
}
