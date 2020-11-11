using BinaryDataDecoders.ToolKit.IO;
using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.SqlServer.Dac.Model;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.DacFx
{
    [FileExtension(".dacpac")]
    public class DacPacNavigator : IToXPathNavigable
    {
        public IXPathNavigable ToNavigable(string filePath) => new TSqlModel(filePath).ToNavigable();

        public IXPathNavigable ToNavigable(Stream stream)
        {
            using var temp = stream.AsTempFile();
            return ToNavigable(temp.FilePath);
        }
    }
}