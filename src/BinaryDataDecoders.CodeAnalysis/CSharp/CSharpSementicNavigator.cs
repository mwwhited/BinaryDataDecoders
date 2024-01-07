using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.CSharp;

[FileExtension(".cs")]
public class CSharpSementicNavigator : IToXPathNavigable
{
    public IXPathNavigable ToNavigable(string filePath)
    {
        var content = File.ReadAllText(filePath);
        var syntax = CSharpSyntaxTree.ParseText(content);
        var compiler = CSharpCompilation.Create("temp");
        var semantic = compiler.GetSemanticModel(syntax);
        var root = semantic.ToNavigable();
        return root;
    }

    public IXPathNavigable ToNavigable(Stream stream)
    {
        var content = SourceText.From(stream);
        var syntax = CSharpSyntaxTree.ParseText(content);
        var compiler = CSharpCompilation.Create("temp").AddSyntaxTrees(syntax);
        var semantic = compiler.GetSemanticModel(syntax);
        var root = semantic.ToNavigable();
        return root;
    }
}
