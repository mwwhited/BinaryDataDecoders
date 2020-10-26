using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public sealed class ExtensibleNavigator : XPathNavigator
    {
        private INode _current;
        private readonly IDictionary<string, string> _namespacePrefixes;
        public ExtensibleNavigator(INode current, string? baseUri = null)
            : this(current, baseUri, null, null)
        {
        }
        private ExtensibleNavigator(
            INode current,
            string? baseUri,
            XmlNameTable? nameTable,
            IDictionary<string, string>? namespacePrefixes)
        {
            BaseURI = baseUri ?? "";
            _current = current;
            NameTable = nameTable ?? new ExtensibleNameTable();
            _namespacePrefixes = namespacePrefixes ?? new Dictionary<string, string>();
        }

        public override string Name => LocalName;
        public override string LocalName => _current.Name.LocalName;
        public override string NamespaceURI => _current switch
        {
            IRootNode _ => "",
            _ => _current.Name.NamespaceName
        };

        public override XPathNodeType NodeType =>
            _current.NodeType;

        public override string Prefix => LookupPrefix(NamespaceURI);

        public override string LookupPrefix(string namespaceURI)
        {
            if (_namespacePrefixes == null) return "";

            if (string.IsNullOrWhiteSpace(namespaceURI)) return "";

            var uri = namespaceURI.Trim();
            if (!_namespacePrefixes.ContainsKey(uri))
            {
                _namespacePrefixes.Add(uri, $"n{_namespacePrefixes.Count + 1}");
            }
            return _namespacePrefixes[uri];
        }

        public override string LookupNamespace(string prefix) =>
            _namespacePrefixes.FirstOrDefault(v => v.Value == prefix).Key ?? base.LookupNamespace(prefix);

        public override string Value => _current.Value ?? "";
        public override bool IsEmptyElement => string.IsNullOrEmpty(Value) && !HasChildren;

        public override bool HasAttributes => _current is IElementNode node && node.FirstAttribute != null;
        public override bool HasChildren => _current is IElementNode node && node.FirstChild != null;

        public override string BaseURI { get; }
        public override XmlNameTable NameTable { get; }
        public override XPathNavigator Clone() => new ExtensibleNavigator(_current, BaseURI, NameTable, _namespacePrefixes);

        public override bool MoveToId(string id) => false;

        public override bool IsSamePosition(XPathNavigator other) =>
            other switch
            {
                ExtensibleNavigator openXPath => openXPath._current.Equals(this._current),
                _ => false
            };

        public override bool MoveTo(XPathNavigator other)
        {
            if (other is ExtensibleNavigator openXPath && openXPath._current != null)
            {
                _current = openXPath._current;
                return true;
            }
            return false;
        }

        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
        {
            if (_current is IElementNode current && current.FirstNamespace != null)
            {
                _current = current.FirstNamespace;
                return true;
            }
            return false;
        }

        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
        {
            if (_current is INamespaceNode current && current.Next != null)
            {
                _current = current.Next;
                return true;
            }
            return false;
        }

        public override bool MoveToFirstAttribute()
        {
            if (_current is IElementNode current && current.FirstAttribute != null)
            {
                _current = current.FirstAttribute;
                return true;
            }
            return false;
        }

        public override bool MoveToNextAttribute()
        {
            if (_current is IAttributeNode current && current.Next != null)
            {
                _current = current.Next;
                return true;
            }
            return false;
        }

        public override bool MoveToParent()
        {
            if (_current.Parent != null)//&& !(_current.Parent is IRootNode)
            {
                _current = _current.Parent;
                return true;
            }
            return false;
        }

        public override bool MoveToFirstChild()
        {
            if (_current is IElementNode current && current.FirstChild != null)
            {
                _current = current.FirstChild;
                return true;
            }
            return false;
        }
        public override bool MoveToNext()
        {
            if (_current.Next != null)
            {
                _current = _current.Next;
                return true;
            }
            return false;
        }
        public override bool MoveToPrevious()
        {
            if (_current.Previous != null)
            {
                _current = _current.Previous;
                return true;
            }
            return false;
        }
    }
}
