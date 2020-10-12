using BinaryDataDecoders.CodeAnalysis.Xml.XPath;
using Microsoft.CodeAnalysis.VisualBasic;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.VisualBasic
{
    public class VisualBasicAnalyzer
    {
        public XPathNavigator Analyze(string vbSourceFile)
        {
            var content = File.ReadAllText(vbSourceFile);
            var syntax = VisualBasicSyntaxTree.ParseText(content);
            var root = syntax.ToSyntaxPointer();
            return new SyntaxTreeXPathNavigator(root);
        }
    }
}
