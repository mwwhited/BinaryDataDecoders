﻿using Microsoft.CodeAnalysis.CSharp;
using System.Collections;
using System.IO;
using BinaryDataDecoders.ToolKit;

namespace BinaryDataDecoders.CodeAnalysis
{
    public class CSharpAnalyzer
    {
        public SyntaxTreeXPathNavigator Analyze(string csharpSourceFile)
        {
            var content = File.ReadAllText(csharpSourceFile);
            var syntax = CSharpSyntaxTree.ParseText(content);
            var root = syntax.GetRoot();
            return new SyntaxTreeXPathNavigator(root);
        }
    }
}
