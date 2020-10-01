using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
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

    public class SyntaxTreeXPathNavigator : XPathNavigator
    {
        private SyntaxNode _syntaxNode;
        private int _tokenIndex = -1;

        public SyntaxTreeXPathNavigator(SyntaxNode syntaxNode)
        {
            _syntaxNode = syntaxNode;
        }

        public override bool IsEmptyElement =>
            throw new NotImplementedException();


        public override XmlNameTable NameTable => null;

        public override XPathNodeType NodeType
        {
            get
            {
                if (_syntaxNode.Parent == null)
                    return XPathNodeType.Root;
                if (_syntaxNode.ChildNodes().Any())
                    return XPathNodeType.Element;
                return XPathNodeType.Text;
            }
        }

        public override string Prefix => "";
        public override string BaseURI => "";
        public override string NamespaceURI => ""; //this.GetXmlNamespaceForOutput();
        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => false;
        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => false;

        public override string LocalName => _syntaxNode.Kind().ToString();
        public override string Name => LocalName;

        public override string Value
        {
            get
            {
                if (_tokenIndex > -1)
                {
                    return _syntaxNode.ToString();
                }
                return _syntaxNode.ToString();
            }
        }

        public override XPathNavigator Clone() => new SyntaxTreeXPathNavigator(_syntaxNode);

        public override bool IsSamePosition(XPathNavigator other)
        {
            if (other is SyntaxTreeXPathNavigator syntaxTree)
            {
                var comparedCurrent = syntaxTree._syntaxNode.IsEquivalentTo(_syntaxNode);
                return comparedCurrent;
            }
            return false;
        }

        public override bool MoveTo(XPathNavigator other)
        {
            if (other is SyntaxTreeXPathNavigator syntaxTree)
            {
                _syntaxNode = syntaxTree._syntaxNode;
                return true;
            }
            return false;
        }

        public override bool MoveToId(string id) => false;

        public override bool MoveToFirstAttribute()
        {
            if (!_syntaxNode.ChildTokens().Any())
                return false;

            _tokenIndex = 0;
            return true;
        }
        public override bool MoveToNextAttribute()
        {
            if (!_syntaxNode.ChildTokens().Any())
                return false;

            if (_tokenIndex + 1 >= _syntaxNode.ChildTokens().Count())
                return false;
            _tokenIndex++;
            return true;
        }

        public override bool MoveToFirstChild()
        {
            var child = _syntaxNode.ChildNodes()
                                   .FirstOrDefault();
            if (child == null)
                return false;
            _syntaxNode = child;
            return true;
        }

        public override bool MoveToNext()
        {
            var child = _syntaxNode.Parent
                                     .ChildNodes()
                                     .SkipWhile(n => !n.IsEquivalentTo(_syntaxNode))
                                     .Skip(1)
                                     .FirstOrDefault();
            if (child == null)
                return false;
            _tokenIndex = -1;
            _syntaxNode = child;
            return true;
        }

        public override bool MoveToParent() => false;
        //{
        //    if (_syntaxNode.Parent == null)
        //        return false;
        //    _tokenIndex = -1;
        //    _syntaxNode = _syntaxNode.Parent;
        //    return true;
        //}

        public override bool MoveToPrevious()
        {
            throw new NotImplementedException();
        }
    }
}
