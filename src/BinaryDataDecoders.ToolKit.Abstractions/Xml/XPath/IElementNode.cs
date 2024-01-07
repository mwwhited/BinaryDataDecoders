namespace BinaryDataDecoders.ToolKit.Xml.XPath;

public interface IElementNode : INode
{
    IAttributeNode? FirstAttribute { get; }
    INode? FirstChild { get; }
    INamespaceNode? FirstNamespace { get; }
}
