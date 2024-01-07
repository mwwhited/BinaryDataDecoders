using Microsoft.CodeAnalysis;

namespace BinaryDataDecoders.CodeAnalysis;

internal interface ISemanticModelNode
{
    SemanticModel Semantic { get; }
    object Node { get; }
}
