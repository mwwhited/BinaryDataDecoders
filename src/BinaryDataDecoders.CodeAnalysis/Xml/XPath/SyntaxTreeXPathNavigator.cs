using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics;
using System.Net;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.Xml.XPath
{
    public partial class SyntaxTreeXPathNavigator : XPathNavigator
    {
        private ISyntaxPointer _pointer;

        public SyntaxTreeXPathNavigator(ISyntaxPointer pointer) => _pointer = pointer;

        //Note: this is read only... don't try to tweak the code here
        public override bool CanEdit => false;

        //Note: for a first pass I'm going to ignore all the namespace crazy.
        public override XmlNameTable NameTable => null;
        public override string Prefix => "";
        public override string BaseURI => "";
        public override string NamespaceURI => ""; // _pointer.NamespaceUri;
        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => false;
        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => false;

        //public override string LookupPrefix(string namespaceURI)
        //{
        //    return base.LookupPrefix(namespaceURI);
        //}

        public override string LocalName => Name;
        public override string Name => _pointer.Name;
        public override string Value => _pointer.Value;

        public override XPathNodeType NodeType => _pointer.ToNodeType();
        public override bool IsEmptyElement => !_pointer.HasChildren;
        public override bool HasChildren => _pointer.HasChildren;
        public override bool HasAttributes => _pointer.HasAttributes;

        public override XPathNavigator Clone() => new SyntaxTreeXPathNavigator(_pointer);//.Clone());
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
                _pointer = syntaxTree._pointer ?? throw new NullReferenceException();
                return true;
            }
            return false;
        }

        public override bool MoveToId(string id) => false;

        [Conditional("DEBUG_WITH_WRITELINE")]
        private void TracePointer() => Debug.WriteLine(_pointer);

        public override bool MoveToFirstAttribute()
        {
            _pointer.AttributesEnumerator.Reset();
            if (_pointer.AttributesEnumerator.MoveNext())
            {
                _pointer = _pointer.AttributesEnumerator.Current ?? throw new NullReferenceException();
                TracePointer();
                return true;
            }
            return false;
        }
        public override bool MoveToNextAttribute()
        {
            var owner = _pointer.Owner;
            if (owner != null)
            {
                if (owner.AttributesEnumerator.MoveNext())
                {
                    _pointer = owner.AttributesEnumerator.Current ?? throw new NullReferenceException();
                    TracePointer();
                    return true;
                }
            }
            return false;
        }

        public override bool MoveToFirstChild()
        {
            _pointer.ChildrenEnumerator.Reset();
            if (_pointer.ChildrenEnumerator.MoveNext())
            {
                _pointer = _pointer.ChildrenEnumerator.Current ?? throw new NullReferenceException();
                TracePointer();
                return true;
            }
            return false;
        }

        public override bool MoveToFirst()
        {
            var owner = _pointer.Owner;
            if (owner != null)
            {
                owner.ChildrenEnumerator.Reset();
                if (owner.ChildrenEnumerator.MoveNext())
                {
                    _pointer = owner.ChildrenEnumerator.Current ?? throw new NullReferenceException();
                    TracePointer();
                    return true;
                }
            }
            return false;
        }
        public override bool MoveToNext()
        {
            var owner = _pointer.Owner;
            if (owner != null)
            {
                if (owner.ChildrenEnumerator.MoveNext())
                {
                    _pointer = owner.ChildrenEnumerator.Current ?? throw new NullReferenceException();
                    TracePointer();
                    return true;
                }
            }
            return false;
        }
        public override bool MoveToPrevious()
        {
            var owner = _pointer.Owner;
            if (owner != null)
            {
                if (owner.ChildrenEnumerator.MovePrevious())
                {
                    _pointer = owner.ChildrenEnumerator.Current ?? throw new NullReferenceException();
                    TracePointer();
                    return true;
                }
            }
            return false;
        }

        public override bool MoveToParent()
        {
            if (_pointer.Owner == null || _pointer.Owner.ToNodeType() == XPathNodeType.Root)
            {
                return false;
            }
            else
            {
                _pointer = _pointer.Owner ?? throw new NullReferenceException();
                return true;
            }
        }

        public override void MoveToRoot()
        {
            var entry = _pointer;
            while (_pointer.Owner != null) _pointer = _pointer.Owner ?? throw new NullReferenceException();
            _pointer = entry ?? throw new NullReferenceException();
        }
    }
}
