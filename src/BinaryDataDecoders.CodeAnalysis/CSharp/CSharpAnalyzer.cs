using BinaryDataDecoders.CodeAnalysis.Xml.XPath;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.CSharp
{
    public class CSharpAnalyzer
    {
        public XPathNavigator Analyze(string csharpSourceFile)
        {
            var root = Pointer(csharpSourceFile);
            return new SyntaxTreeXPathNavigator(root);
        }
        public ISyntaxPointer Pointer(string csharpSourceFile)
        {
            var content = File.ReadAllText(csharpSourceFile);
            var syntax = CSharpSyntaxTree.ParseText(content);
            return syntax.ToSyntaxPointer();
        }
    }
}
