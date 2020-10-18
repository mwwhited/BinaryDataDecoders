using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface ICreateNavigator
    {
        IXPathNavigable CreateNavigator(string inputFile);
        IXPathNavigable CreateNavigator(Stream inputFile);
    }
}
