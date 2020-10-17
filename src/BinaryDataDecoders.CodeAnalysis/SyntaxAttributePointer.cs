using BinaryDataDecoders.ToolKit.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class SyntaxAttributePointer : ISyntaxPointer
    {
        public SyntaxAttributePointer(XName name, object value, ISyntaxPointer owner)
        {
            this.XName = name;
            this.Name = name.LocalName;
            this.NamespaceUri = name.NamespaceName;
            this.Value = $"{value}";
            this.Owner = owner;
        }

        public ISyntaxPointer? Owner { get; }
        public XName XName { get; }

        public string NamespaceUri { get; }
        public string Name { get; }
        public string Value { get; }

        public bool HasChildren => false;
        public bool HasAttributes => false;

        public IEnumerable<ISyntaxPointer> Children => Enumerable.Empty<ISyntaxPointer>();
        public IReversibleEnumerator<ISyntaxPointer> ChildrenEnumerator => Children.GetReversibleEnumerator();
        public IEnumerable<ISyntaxPointer> Attributes => Enumerable.Empty<ISyntaxPointer>();
        public IReversibleEnumerator<ISyntaxPointer> AttributesEnumerator => Attributes.GetReversibleEnumerator();

        public override bool Equals(object obj) =>
            obj is SyntaxAttributePointer attrib &&
                this.NamespaceUri == attrib.NamespaceUri &&
                this.Name == attrib.Name &&
                this.Value == attrib.Value;
    }
}