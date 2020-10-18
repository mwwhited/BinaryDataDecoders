using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.IO;
using System.Text.Json;
using System.Xml.XPath;

namespace BinaryDataDecoders.Text.Json
{
    [FileExtension(".json")]
    [MediaType("application/json")]
    public class JsonNavigator : ICreateNavigator
    {
        public IXPathNavigable CreateNavigator(string inputFile)
        {
            using var file = File.OpenRead(inputFile);
            return CreateNavigator(file);
        }

        public IXPathNavigable CreateNavigator(Stream inputFile) =>
            JsonDocument.Parse(inputFile).CreateNavigator();
    }
}
