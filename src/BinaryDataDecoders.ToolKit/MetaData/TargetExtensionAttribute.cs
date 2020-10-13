using System;

namespace BinaryDataDecoders.ToolKit.MetaData
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TargetExtensionAttribute : Attribute
    {
        public string FileExtension { get; }

        public TargetExtensionAttribute(string fileExtension) => FileExtension = fileExtension;
    }
}
