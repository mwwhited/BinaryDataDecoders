using System;

namespace BinaryDataDecoders.ToolKit.MetaData;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class FileExtensionAttribute(string fileExtension) : Attribute
{
    public string FileExtension { get; } = fileExtension;
}
