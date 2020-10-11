using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{

    public class SyntaxTreeXPathNavigator : XPathNavigator
    {
        private CSharpSyntaxNodePointer _current;

        public SyntaxTreeXPathNavigator(SyntaxNodeOrToken syntaxNode) => _current = new CSharpSyntaxNodePointer(syntaxNode, null, -1, 0);

        //Note: this is read only... don't try to tweak the code here
        public override bool CanEdit => false;

        //Note: for a first pass I'm going to ignore all the namespace crazy.
        public override XmlNameTable NameTable => null;
        public override string Prefix => "";
        public override string BaseURI => "";
        public override string NamespaceURI => ""; //this.GetXmlNamespaceForOutput();
        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => false;
        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => false;

        public override string LocalName => Name;
        public override string Name => _current.Name;
        public override string Value => _current.Value;

        public override XPathNodeType NodeType => _current.NodeType;
        public override bool IsEmptyElement => !_current.HasChildren;
        public override bool HasChildren => _current.HasChildren;

        public override XPathNavigator Clone() => new SyntaxTreeXPathNavigator(default) { _current = _current.Clone() };

        public override bool IsSamePosition(XPathNavigator other) =>
           other switch
           {
               SyntaxTreeXPathNavigator syntaxTree => syntaxTree._current.Equals(_current),
               _ => false
           };

        public override bool MoveTo(XPathNavigator other)
        {
            if (other is SyntaxTreeXPathNavigator syntaxTree)
            {
                _current = syntaxTree._current;
                return true;
            }
            return false;
        }

        public override bool MoveToId(string id) => false;
        public override bool MoveToFirstAttribute() => false;
        public override bool MoveToNextAttribute() => false;

        public override bool MoveToFirstChild()
        {
            if (_current.HasChildren)
            {
                var child = _current.Current.ChildNodesAndTokens().First();
                _current = new CSharpSyntaxNodePointer(child, _current, 0, _current.Depth + 1);
                // Debug.WriteLine(_current);
                return true;
            }
            else if (_current.Current.IsToken && !_current.IsText)
            {
                _current = new CSharpSyntaxNodePointer(_current.Current, _current, 0, _current.Depth + 1, true);
                // Debug.WriteLine(_current);
                return true;
            }

            return false;
        }

        private bool MoveToSibling(int targetIndex)
        {
            if (0 <= targetIndex && targetIndex < _current.Owner?.NumberOfChildren)
            {
                var child = _current.Owner.Current.ChildNodesAndTokens()[targetIndex];
                _current = new CSharpSyntaxNodePointer(child, _current.Owner, targetIndex, _current.Depth);
                // Debug.WriteLine(_current);
                return true;
            }

            return false;
        }
        public override bool MoveToNext() => MoveToSibling(_current.Index + 1);
        public override bool MoveToPrevious() => MoveToSibling(_current.Index - 1);

        public override bool MoveToParent()
        {
            if (_current.Owner == null)
            {
                return false;
            }
            else
            {
                _current = _current.Owner;
                return true;
            }
        }


        public override void MoveToRoot()
        {
            var target = _current.Current;
            var targetDepth = _current.Depth;
            while (target.Parent != null)
            {
                target = target.Parent;
                targetDepth--;
            }
            _current = new CSharpSyntaxNodePointer(target, _current, -1, targetDepth);
        }
    }
}
