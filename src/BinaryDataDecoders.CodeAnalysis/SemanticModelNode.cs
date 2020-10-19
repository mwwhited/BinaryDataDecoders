using Microsoft.CodeAnalysis;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal sealed class SemanticModelNode : ISemanticModelNode
    {
        public SemanticModelNode(SemanticModel semantic, object node)
        {
            Semantic = semantic;
            Node = node;
        }
        public SemanticModel Semantic { get; }
        public object Node { get; }
    }
}
