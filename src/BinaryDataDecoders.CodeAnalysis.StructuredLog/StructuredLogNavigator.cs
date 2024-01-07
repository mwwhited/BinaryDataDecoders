using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.Build.Logging.StructuredLogger;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.StructuredLog;

[FileExtension(".binlog")]
public class StructuredLogNavigator : IToXPathNavigable
{
    public IXPathNavigable ToNavigable(string filePath) => Serialization.Read(filePath).ToNavigable();

    public IXPathNavigable ToNavigable(Stream stream) => Serialization.ReadBinLog(stream).ToNavigable();
}
