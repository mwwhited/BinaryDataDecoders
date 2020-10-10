using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{
    public class SyntaxTreeXPathNavigator : XPathNavigator
    {
        private SyntaxNodeOrToken _entry;
        private SyntaxNodeOrToken _current;
        private int _index;

        //private bool IsNullToken(SyntaxNodeOrToken child) =>
        //    child == null || (child.IsToken && child.RawKind == 0);
        //private bool NodeHasChilden(SyntaxNodeOrToken child) =>
        //   child.IsNode && (child.AsNode()?.ChildNodesAndTokens().Any() ?? false);

        //private void Reset()
        //{
        //    _current = _entry;
        //    _index = -1;
        //}

        private SyntaxNodeOrToken Current => _current;
        //    _index switch
        //{
        //    -1 => _current,
        //    _ => _current.ChildNodesAndTokens().ElementAt(_index)
        //};

        public SyntaxTreeXPathNavigator(SyntaxNodeOrToken syntaxNode)
        {
            _entry = _current = syntaxNode;
            _index = -1;
        }

        public override XmlNameTable NameTable => null;

        public override string Prefix => "";
        public override string BaseURI => "";
        public override string NamespaceURI => ""; //this.GetXmlNamespaceForOutput();
        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => false;
        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => false;

        public override string LocalName => _current.Kind().ToString();
        public override string Name => LocalName;

        public override string Value => _current.ToString();


        //public override XPathNodeType NodeType
        //{
        //    get
        //    {
        //        if (Current.Parent == null)
        //            return XPathNodeType.Root;

        //        if (NodeHasChilden(Current))
        //            return XPathNodeType.Element;
        //        return XPathNodeType.Text;
        //    }
        //}
        //public override bool IsEmptyElement => !NodeHasChilden(Current);
        //public override bool HasChildren => NodeHasChilden(Current);

        //public override XPathNavigator Clone() =>
        //    new SyntaxTreeXPathNavigator(_current)
        //    {
        //        _index = _index,
        //        _entry = _entry,
        //    };

        //public override bool IsSamePosition(XPathNavigator other)
        //{
        //    if (other is SyntaxTreeXPathNavigator syntaxTree)
        //    {
        //        var comparedCurrent = syntaxTree.Current.IsEquivalentTo(Current);
        //        return comparedCurrent;
        //    }
        //    return false;
        //}

        //public override bool MoveTo(XPathNavigator other)
        //{
        //    if (other is SyntaxTreeXPathNavigator syntaxTree)
        //    {
        //        _current = syntaxTree._current;
        //        _index = syntaxTree._index;
        //        _entry = syntaxTree._entry;
        //        return true;
        //    }
        //    return false;
        //}

        //public override bool MoveToId(string id) => false;
        //public override bool MoveToFirstAttribute() => false;
        //public override bool MoveToNextAttribute() => false;

        //public override bool MoveToFirstChild()
        //{
        //    if (this.IsEmptyElement)
        //    {
        //        _index = -1;
        //        return false;
        //    }
        //    else
        //    {
        //        _index = 0;
        //        _current = _current.ChildNodesAndTokens().FirstOrDefault();
        //        return true;
        //    }
        //}


        //public override bool MoveToNext()
        //{
        //    if (this.IsEmptyElement)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        if ((_index + 1) >= _current.ChildNodesAndTokens().Count)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            _index++;
        //            return true;
        //        }
        //    }
        //}

        //public override bool MoveToPrevious()
        //{
        //    if (this.IsEmptyElement)
        //    {
        //        _index = -1;
        //        return false;
        //    }
        //    else if (_index > 0)
        //    {
        //        _index--;
        //        return true;
        //    }
        //    else
        //    {
        //        _index = 0;
        //        return false;
        //    }
        //}

        //public override bool MoveToParent()
        //{
        //    if (_current.Parent == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        _index = -1;
        //        _current = _current.Parent;
        //        return true;
        //    }
        //}


        //public override void MoveToRoot()
        //{
        //    while (MoveToParent()) ;
        //}
    }
}
