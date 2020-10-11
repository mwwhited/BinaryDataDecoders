using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{

    public class SyntaxTreeXPathNavigator : XPathNavigator
    {
        private CSharpSyntaxNodePointer _pointer;

        public SyntaxTreeXPathNavigator(SyntaxNodeOrToken syntaxNode) : this(new CSharpSyntaxNodePointer(syntaxNode, null, -1, 0)) { }
        private SyntaxTreeXPathNavigator(CSharpSyntaxNodePointer pointer) => _pointer = pointer;

        //Note: this is read only... don't try to tweak the code here
        public override bool CanEdit => false;
        #region This is readonly so addthese so they stop showing in local override
        public override XmlWriter AppendChild() => throw new NotSupportedException();
        public override void AppendChild(string newChild) => throw new NotSupportedException();
        public override void AppendChild(XmlReader newChild) => throw new NotSupportedException();
        public override void AppendChild(XPathNavigator newChild) => throw new NotSupportedException();
        public override void AppendChildElement(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override void CreateAttribute(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override XmlWriter CreateAttributes() => throw new NotSupportedException();
        public override void DeleteRange(XPathNavigator lastSiblingToDelete) => throw new NotSupportedException();
        public override void DeleteSelf() => throw new NotSupportedException();
        public override XmlWriter InsertAfter() => throw new NotSupportedException();
        public override void InsertAfter(string newSibling) => throw new NotSupportedException();
        public override void InsertAfter(XmlReader newSibling) => throw new NotSupportedException();
        public override void InsertAfter(XPathNavigator newSibling) => throw new NotSupportedException();
        public override XmlWriter InsertBefore() => throw new NotSupportedException();
        public override void InsertBefore(string newSibling) => throw new NotSupportedException();
        public override void InsertBefore(XmlReader newSibling) => throw new NotSupportedException();
        public override void InsertBefore(XPathNavigator newSibling) => throw new NotSupportedException();
        public override void InsertElementAfter(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override void InsertElementBefore(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override XmlWriter PrependChild() => throw new NotSupportedException();
        public override void PrependChild(string newChild) => throw new NotSupportedException();
        public override void PrependChild(XmlReader newChild) => throw new NotSupportedException();
        public override void PrependChild(XPathNavigator newChild) => throw new NotSupportedException();
        public override void PrependChildElement(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override void ReplaceSelf(string newNode) => throw new NotSupportedException();
        public override void ReplaceSelf(XmlReader newNode) => throw new NotSupportedException();
        public override XmlWriter ReplaceRange(XPathNavigator lastSiblingToReplace) => throw new NotSupportedException();
        public override void ReplaceSelf(XPathNavigator newNode) => throw new NotSupportedException();
        public override void SetTypedValue(object typedValue) => throw new NotSupportedException();
        public override void SetValue(string value) => throw new NotSupportedException();
        public override void WriteSubtree(XmlWriter writer) => throw new NotSupportedException();
        #endregion This is readonly so addthese so they stop showing in local override

        //Note: for a first pass I'm going to ignore all the namespace crazy.
        public override XmlNameTable NameTable => null;
        public override string Prefix => "";
        public override string BaseURI => "";
        public override string NamespaceURI => ""; //this.GetXmlNamespaceForOutput();
        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => false;
        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => false;

        public override string LocalName => Name;
        public override string Name => _pointer.Name;
        public override string Value => _pointer.Value;

        public override XPathNodeType NodeType => _pointer.NodeType;
        public override bool IsEmptyElement => !_pointer.HasChildren;
        public override bool HasChildren => _pointer.HasChildren;
        public override bool HasAttributes => _pointer.HasAttributes;

        public override XPathNavigator Clone() => new SyntaxTreeXPathNavigator(_pointer);
        public override XPathNavigator CreateNavigator() => Clone();

        public override bool IsSamePosition(XPathNavigator other) =>
           other switch
           {
               SyntaxTreeXPathNavigator syntaxTree => syntaxTree._pointer.Equals(_pointer),
               _ => false
           };

        public override bool MoveTo(XPathNavigator other)
        {
            if (other is SyntaxTreeXPathNavigator syntaxTree)
            {
                _pointer = syntaxTree._pointer;
                return true;
            }
            return false;
        }

        public override bool MoveToId(string id) => false;

        [Conditional("DEBUG_WITH_WRITELINE")]
        private void TracePointer() => Debug.WriteLine(_pointer);

        private bool MoveToAttribute(int attributeIndex)
        {
            var basis = _pointer.AttributeIndex >= 0 ? _pointer.Owner : _pointer;
            if (basis?.HasAttributeIndex(attributeIndex) ?? false)
            {
                _pointer = new CSharpSyntaxNodePointer(basis.Current, basis, 0, basis.Depth + 1, isText: false, attributeIndex: attributeIndex);
                TracePointer();
                return true;
            }
            return false;
        }
        public override bool MoveToFirstAttribute() => MoveToAttribute(0);
        public override bool MoveToNextAttribute() => MoveToAttribute(_pointer.AttributeIndex + 1);

        public override bool MoveToFirstChild()
        {
            var basis = _pointer.AttributeIndex >= 0 ? _pointer.Owner : _pointer;
            if (basis == null) return false;
            if (basis.HasChildren)
            {
                var child = basis.Current.ChildNodesAndTokens().First();
                _pointer = new CSharpSyntaxNodePointer(child, basis, 0, basis.Depth + 1);
                TracePointer();
                return true;
            }
            else if (basis.Current.IsToken && !basis.IsText)
            {
                _pointer = new CSharpSyntaxNodePointer(basis.Current, basis, 0, basis.Depth + 1, true);
                TracePointer();
                return true;
            }

            return false;
        }
        private bool MoveToSibling(int targetIndex)
        {
            var basis = _pointer.AttributeIndex >= 0 ? _pointer.Owner : _pointer;
            if (basis == null) return false;
            if (0 <= targetIndex && targetIndex < basis.Owner?.NumberOfChildren)
            {
                var child = basis.Owner.Current.ChildNodesAndTokens()[targetIndex];
                _pointer = new CSharpSyntaxNodePointer(child, basis.Owner, targetIndex, basis.Depth);
                TracePointer();
                return true;
            }

            return false;
        }
        public override bool MoveToFirst() => MoveToSibling(0);
        public override bool MoveToNext() => MoveToSibling(_pointer.Index + 1);
        public override bool MoveToPrevious() => MoveToSibling(_pointer.Index - 1);

        public override bool MoveToParent()
        {
            if (_pointer.NodeType == XPathNodeType.Root || _pointer.Owner == null)
            {
                return false;
            }
            else
            {
                _pointer = _pointer.Owner;
                return true;
            }
        }

        public override void MoveToRoot()
        {
            var target = _pointer.Current;
            var targetDepth = _pointer.Depth;
            while (target.Parent != null)
            {
                target = target.Parent;
                targetDepth--;
            }
            _pointer = new CSharpSyntaxNodePointer(target, null, -1, targetDepth); //TODO: should the owner be null?
        }
    }
}
