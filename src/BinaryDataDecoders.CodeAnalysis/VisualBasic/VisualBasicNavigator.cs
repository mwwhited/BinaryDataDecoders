using BinaryDataDecoders.CodeAnalysis.Xml.XPath;
using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis.VisualBasic;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.VisualBasic
{
    [TargetExtension(".vb")]
    public class VisualBasicNavigator : ICreateXPathNavigator
    {
        public IXPathNavigable CreateNavigator(string vbSourceFile)
        {
            var content = File.ReadAllText(vbSourceFile);
            var syntax = VisualBasicSyntaxTree.ParseText(content);
            var root = syntax.ToSyntaxPointer();
            return new SyntaxTreeXPathNavigator(root);
        }
    }
}
