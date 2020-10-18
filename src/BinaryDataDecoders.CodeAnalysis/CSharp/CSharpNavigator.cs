﻿using BinaryDataDecoders.CodeAnalysis.Xml.XPath;
using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.CSharp
{
    [FileExtension(".cs")]
    public class CSharpNavigator : IToXPathNavigable
    {
        public IXPathNavigable ToNavigable(string filePath)
        {
            var content = File.ReadAllText(filePath);
            var syntax = CSharpSyntaxTree.ParseText(content);
            var root = syntax.ToSyntaxPointer();
            return new SyntaxTreeXPathNavigator(root);
            //var nav = syntax.ToNavigable();
            //return nav;
        }

        public IXPathNavigable ToNavigable(Stream stream)
        {
            var content = SourceText.From(stream);
            var syntax = CSharpSyntaxTree.ParseText(content);
            var root = syntax.ToSyntaxPointer();
            return new SyntaxTreeXPathNavigator(root);
        }
    }
}
