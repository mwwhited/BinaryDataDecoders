using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class SyntaxRootPointer : SyntaxPointerBase<SyntaxTree>
    {
        private readonly ISyntaxPointer _entry;

        public SyntaxRootPointer(SyntaxTree tree) : base(tree, null)
        {
            _entry = Item.GetRoot().ToSyntaxPointer(this);
        }

        protected override IEnumerable<ISyntaxPointer> GetChildren()
        {
            yield return _entry;
        }
    }
}
