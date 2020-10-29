using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.IO
{
    public class PathNavigator : IToXPathNavigable
    {
        public IXPathNavigable ToNavigable(string filePath) => new DirectoryInfo(filePath).ToNavigable();
        public IXPathNavigable ToNavigable(Stream stream) => throw new NotSupportedException();
    }
}
