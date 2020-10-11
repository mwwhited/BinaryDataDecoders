using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class CSharpSyntaxNodePointer
    {
        public CSharpSyntaxNodePointer? Owner { get; }
        public SyntaxNodeOrToken Current { get; }
        public int Index { get; }
        public int Depth { get; }

        public bool IsText { get; }

        public CSharpSyntaxNodePointer(SyntaxNodeOrToken entry, CSharpSyntaxNodePointer? owner, int index, int depth, bool isText = false)
        {
            Owner = owner;
            Current = entry;
            Index = index;
            Depth = depth;
            IsText = isText;
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
                else if (IsText) return XPathNodeType.Text;
                else return XPathNodeType.Element;
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
