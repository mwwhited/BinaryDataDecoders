using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public sealed class OpenXPathNavigator : XPathNavigator
    {
        private IXPathNode _current;
        private readonly IDictionary<string, string> _namespacePrefixes;
        public OpenXPathNavigator(IXPathNode current, string? baseUri = null)
            : this(current, baseUri, null, null)
        {
        }
        private OpenXPathNavigator(
            IXPathNode current,
            string? baseUri,
            XmlNameTable? nameTable,
            IDictionary<string, string>? namespacePrefixes)
        {
            BaseURI = baseUri ?? "";
            _current = current;
            NameTable = nameTable ?? new OpenXNameTable();
            _namespacePrefixes = namespacePrefixes ?? new Dictionary<string, string>();
        }

        public override string Name => _current.Name.ToString();
        public override string LocalName => _current.Name.LocalName;
        public override string NamespaceURI => _current.Name.NamespaceName;

        public override XPathNodeType NodeType => _current.NodeType;

        public override string Prefix =>  LookupPrefix(NamespaceURI);

        public override string LookupPrefix(string namespaceURI)
        {
            if (string.IsNullOrWhiteSpace(namespaceURI))
                return "";

            var uri = namespaceURI.Trim();
            if (!_namespacePrefixes.ContainsKey(uri))
            {
                _namespacePrefixes.Add(uri, $"n{_namespacePrefixes.Count + 1}");
            }
            return _namespacePrefixes[uri];
        }

        public override string LookupNamespace(string prefix) =>
            _namespacePrefixes.FirstOrDefault(v => v.Value == prefix).Key ?? base.LookupNamespace(prefix);

        public override string Value => _current.Value;
        public override bool IsEmptyElement => string.IsNullOrWhiteSpace(Value);

        public override string BaseURI { get; }
        public override XmlNameTable NameTable { get; }
        public override XPathNavigator Clone() =>
            new OpenXPathNavigator(_current, BaseURI, NameTable, _namespacePrefixes);

        public override bool MoveToId(string id) => false;

        public override bool IsSamePosition(XPathNavigator other) =>
            other switch
            {
                OpenXPathNavigator openXPath => openXPath._current.Equals(this._current),
                _ => false
            };

        public override bool MoveTo(XPathNavigator other)
        {
            if (other is OpenXPathNavigator openXPath && openXPath._current != null)
            {
                _current = openXPath._current;
                return true;
            }
            return false;
        }

        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
        {
            if (_current is IXPathItemNode current && current.FirstNamespace != null)
            {
                _current = current.FirstNamespace;
                return true;
            }
            return false;
        }
        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
        {
            if (_current is IXPathNamespaceNode current && current.Next != null)
            {
                _current = current.Next;
                return true;
            }
            return false;
        }


        public override bool MoveToFirstAttribute()
        {
            if (_current is IXPathItemNode current && current.FirstAttribute != null)
            {
                _current = current.FirstAttribute;
                return true;
            }
            return false;
        }

        public override bool MoveToNextAttribute()
        {
            if (_current is IXPathAttributeNode current && current.Next != null)
            {
                _current = current.Next;
                return true;
            }
            return false;
        }

        public override bool MoveToParent()
        {
            if (_current.Parent != null)
            {
                _current = _current.Parent;
                return true;
            }
            return false;
        }

        public override bool MoveToFirstChild()
        {
            if (_current is IXPathItemNode current && current.FirstChild != null)
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
