using BinaryDataDecoders.CodeAnalysis.Xml.XPath;
using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.CSharp
{
    [TargetExtension(".cs")]
    public class CSharpAnalyzer : ICreateXPathNavigator
    {
        public IXPathNavigable CreateNavigator(string csharpSourceFile)
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
