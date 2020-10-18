using BinaryDataDecoders.CodeAnalysis.Xml.XPath;
using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.CSharp
{
    [FileExtension(".cs")]
    public class CSharpNavigator : ICreateNavigator
    {
        public IXPathNavigable CreateNavigator(string csharpSourceFile, bool excludeNamespace)
        {
            var root = Pointer(csharpSourceFile);
            return new SyntaxTreeXPathNavigator(root, excludeNamespace);
        }

        public IXPathNavigable CreateNavigator(string inputFile) => CreateNavigator(inputFile, false);

        public ISyntaxPointer Pointer(string csharpSourceFile)
        {
            var content = File.ReadAllText(csharpSourceFile);
            var syntax = CSharpSyntaxTree.ParseText(content);
            return syntax.ToSyntaxPointer();
        }
    }
}
