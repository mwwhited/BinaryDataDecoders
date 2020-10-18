using System;

namespace BinaryDataDecoders.ToolKit.MetaData
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class MediaTypeAttribute : Attribute
    {
        public string MediaType { get; }

        public MediaTypeAttribute(string fileExtension) => MediaType = fileExtension;
    }
}
