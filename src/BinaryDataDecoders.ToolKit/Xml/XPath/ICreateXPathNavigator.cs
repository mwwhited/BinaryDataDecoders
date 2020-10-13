using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface ICreateXPathNavigator
    {
        IXPathNavigable CreateNavigator(string inputFile);
    }
}
