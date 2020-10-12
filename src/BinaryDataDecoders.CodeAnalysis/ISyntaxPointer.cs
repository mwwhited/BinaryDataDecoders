using BinaryDataDecoders.ToolKit.Collections;
using System.Collections.Generic;

namespace BinaryDataDecoders.CodeAnalysis
{
    public interface ISyntaxPointer
    {
        public ISyntaxPointer? Owner { get; }
        bool HasChildren { get; }
        bool HasAttributes { get; }
        string Name { get; }
        string Value { get; }

        IEnumerable<ISyntaxPointer> Children { get; }
        IEnumerable<ISyntaxPointer> Attributes { get; }

        IReversibleEnumerator<ISyntaxPointer> ChildrenEnumerator { get; }
        IReversibleEnumerator<ISyntaxPointer> AttributesEnumerator { get; }
        string NamespaceUri { get; }
    }
}
