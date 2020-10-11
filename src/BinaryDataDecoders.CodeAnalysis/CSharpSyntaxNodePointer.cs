using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class CSharpSyntaxNodePointer
    {
        public const int RootIndex = -1;

        public CSharpSyntaxNodePointer? Owner { get; }
        public SyntaxNodeOrToken Current { get; }
        public int Index { get; }
        public int Depth { get; }

        public bool IsText { get; }
        public int AttributeIndex { get; }

        public CSharpSyntaxNodePointer(SyntaxNodeOrToken entry, CSharpSyntaxNodePointer? owner, int index, int depth, bool isText = false, int attributeIndex = RootIndex)
        {
            Owner = owner;
            Current = entry;
            Index = index;
            Depth = depth;
            IsText = isText;
            AttributeIndex = attributeIndex;
        }

        public string Name =>
            AttributeIndex switch
            {
                0 => "type",
                1 => "raw-kind",
                2 => "lang",
                3 => "location",

                _ => Current.Kind().ToString()
            };

        public string Value =>
            AttributeIndex switch
            {
                0 => Current.IsMissing ? "missing" : Current.IsNode ? "node" : Current.IsToken ? "token" : "unknown",
                1 => Current.RawKind.ToString(),
                2 => Current.Language,
                3 => Current.GetLocation()?.ToString() ?? "",

                _ => Current.ToString()
            };

        public bool HasAttributeIndex(int attributeIndex) => AttributeIndex == RootIndex && 0 <= attributeIndex && attributeIndex <= 3;

        public bool HasChildren => Current.ChildNodesAndTokens().Any();// Current.IsNode &&
        public int NumberOfChildren => Current.ChildNodesAndTokens().Count;
        public XPathNodeType NodeType
        {
            get
            {
                if (Current.Parent == null) return XPathNodeType.Root;
                else if (IsText) return XPathNodeType.Text;
                else if (!HasAttributes) return XPathNodeType.Attribute;
                else return XPathNodeType.Element;
            }
        }

        public bool HasAttributes => AttributeIndex == RootIndex;

        public override bool Equals(object obj) =>
            obj switch
            {
                CSharpSyntaxNodePointer pointer => this.AttributeIndex == pointer.AttributeIndex && this.Equals(pointer.Current),
                SyntaxNodeOrToken nodeOrToken => this.Current.IsEquivalentTo(nodeOrToken),
                _ => false
            };

        public override string ToString() => $"{new string(Depth < 0 ? '>' : ' ', Math.Abs(Depth))}|{Name}=@@@{Value}@@@\t[{NodeType}] ({Depth}:{Index})";
    }
}
