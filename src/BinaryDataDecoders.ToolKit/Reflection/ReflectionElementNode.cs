using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Reflection
{
    public class ReflectionElementNode : INode
    {
        private readonly INode _node;

        public XName Name => _node.Name;
        public INode? Parent => _node.Parent;
        public INode? Next => _node.Next;
        public INode? Previous => _node.Previous;
        public string? Value => _node.Value;
        public XPathNodeType NodeType => _node.NodeType;

        public ReflectionElementNode(object seed, bool excludeNamespace = false) =>
            _node = new ExtensibleElementNode(
                  XName.Get(seed.GetType().Name, excludeNamespace ? "" : seed.GetXmlNamespace()),
                  seed,
                  ValueSelector,
                  AttributeSelector,
                  ChildSelector,
                  NamespacesSelector,
                  PreserveWhitespace
                  );

        protected virtual bool PreserveWhitespace(object obj) => true;
        protected virtual IEnumerable<XName>? NamespacesSelector(object arg) => Enumerable.Empty<XName>();
        protected virtual IEnumerable<(XName name, object child)>? ChildSelector(object arg) => Enumerable.Empty<(XName name, object child)>();
        protected virtual IEnumerable<(XName name, string? value)>? AttributeSelector(object arg) => Enumerable.Empty<(XName name, string? value)>();
        protected virtual string? ValueSelector(object arg) =>null;
    }
}
