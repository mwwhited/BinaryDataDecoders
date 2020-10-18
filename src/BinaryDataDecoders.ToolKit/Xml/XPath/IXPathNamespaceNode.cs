namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface IXPathNamespaceNode : IXPathNode<IXPathNamespaceNode>
    {
        IXPathNamespaceNode? Next { get; }
        IXPathNamespaceNode? Previous { get; }
    }
}
