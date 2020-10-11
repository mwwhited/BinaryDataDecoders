using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class CSharpSyntaxNodePointer
    {
        public CSharpSyntaxNodePointer? Owner { get; }
        public SyntaxNodeOrToken Current { get; }
        public int Index { get; }
        public int Depth { get; }

        public CSharpSyntaxNodePointer(SyntaxNodeOrToken entry, CSharpSyntaxNodePointer? owner, int index, int depth)
        {
            Owner = owner;
            Current = entry;
            Index = index;
            Depth = depth;
        }

        public string Name => Current.Kind().ToString();
        public string Value => Current.ToString();
        public bool HasChildren => Current.ChildNodesAndTokens().Any();// Current.IsNode &&
        public int NumberOfChildren => Current.ChildNodesAndTokens().Count;
        public XPathNodeType NodeType
        {
            get
            {
                if (Current.Parent == null) return XPathNodeType.Root;
                else if (HasChildren) return XPathNodeType.Element;
                else return XPathNodeType.Text;
            }
        }

        internal CSharpSyntaxNodePointer Clone() => new CSharpSyntaxNodePointer(Current, this, Index, Depth);

        public override bool Equals(object obj) =>
            obj switch
            {
                CSharpSyntaxNodePointer pointer => this.Equals(pointer.Current),
                SyntaxNodeOrToken nodeOrToken => this.Current.IsEquivalentTo(nodeOrToken),
                _ => false
            };

        public override string ToString() => $"{new string(' ', Depth)}|{Name}=@@@{Value}@@@\t[{NodeType}] ({Depth}:{Index})";
    }
}
