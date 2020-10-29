using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.VisualBasic;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.VisualBasic
{
    [FileExtension(".vb")]
    public class VisualBasicNavigator : IToXPathNavigable
    {
        public IXPathNavigable ToNavigable(string filePath)
        {
            var content = File.ReadAllText(filePath);
            var syntax = VisualBasicSyntaxTree.ParseText(content);
            var root = syntax.ToNavigable(filePath);
            return root;
        }

        public IXPathNavigable ToNavigable(Stream stream)
        {
            var content = SourceText.From(stream);
            var syntax = VisualBasicSyntaxTree.ParseText(content);
            var root = syntax.ToNavigable();
            return root;
        }
    }
}
