using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using System.IO;
using System.Linq;
using System.Xml.XPath;
using YamlDotNet.RepresentationModel;

namespace BinaryDataDecoders.Yaml
{
    [FileExtension(".yaml")]
    [FileExtension(".yml")]
    [MediaType("text/yaml")]
    [MediaType("text/vnd.yaml")]
    [MediaType("text/x-yaml")]
    [MediaType("application/yaml")]
    [MediaType("application/vnd.yaml")]
    [MediaType("application/x-yaml")]
    public class YamlNavigator : IToXPathNavigable
    {
        public IXPathNavigable? ToNavigable(string filePath)
        {
            using var input = new StreamReader(filePath);
            return ToNavigable(input);
        }

        public IXPathNavigable? ToNavigable(Stream stream)
        {
            using var input = new StreamReader(stream);
            return ToNavigable(input);
        }

        private IXPathNavigable? ToNavigable(StreamReader reader)
        {
            var yaml = new YamlStream();
            yaml.Load(reader);
            return yaml.Documents.SingleOrDefault().ToNavigable();
        }
    }
}
