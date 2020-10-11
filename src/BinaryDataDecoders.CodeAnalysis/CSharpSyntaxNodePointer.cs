using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Xml.XPath;
using static System.Xml.XPath.XPathNodeType;

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

        public CSharpSyntaxNodePointer(
            SyntaxNodeOrToken entry,
            CSharpSyntaxNodePointer? owner,
            int index,
            int depth,
            bool isText = false,
            int attributeIndex = RootIndex
            )
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
                2 => "location-kind",
                3 => "location-start",
                4 => "location-end",
                5 => "lang",

                _ => Current.Kind().ToString()
            };

        public string Value => $@"{
            AttributeIndex switch
            {
                0 => Current.IsMissing? "missing" : Current.IsNode? "node" : Current.IsToken? "token" : "unknown",
                1 => Current.RawKind,
                2 => Current.GetLocation()?.Kind,
                3 => Current.GetLocation()?.SourceSpan.Start,
                4 => Current.GetLocation()?.SourceSpan.End,
                5 => Current.Language,

                _ => Current.ToString()
            }}";

        public bool HasAttributeIndex(int attributeIndex) =>
            AttributeIndex switch
            {
                RootIndex when (0 <= attributeIndex && attributeIndex <= 5) => true,
                _ => false
            };

        public bool HasChildren => Current.ChildNodesAndTokens().Any();// Current.IsNode &&
        public int NumberOfChildren => Current.ChildNodesAndTokens().Count;
        public XPathNodeType NodeType
        {
            get
            {
                if (Index == RootIndex && Depth == RootIndex) return Root;
                else if (IsText) return Text;
                else if (!HasAttributes) return XPathNodeType.Attribute;
                else return Element;
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

        public override string ToString() =>
             NodeType switch
             {
                 Root => $"{new string(Depth < 0 ? '>' : ' ', Math.Abs(Depth))}|{Name}$$$\t[{NodeType}] ({Depth}:{Index})",
                 Element => $"{new string(Depth < 0 ? '>' : ' ', Math.Abs(Depth))}|{Name}$$$\t[{NodeType}] ({Depth}:{Index})",
                 _ => $"{new string(Depth < 0 ? '>' : ' ', Math.Abs(Depth))}|{Name}=@@@{Value}@@@\t[{NodeType}] ({Depth}:{Index})"
             };
    }
}
