namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface IXPathItemNode : IXPathNode<IXPathItemNode>
    {
        IXPathItemNode? Next { get; }
        IXPathItemNode? Previous { get; }

        IXPathAttributeNode? FirstAttribute { get; }
        IXPathItemNode? FirstChild { get; }
        IXPathNamespaceNode? FirstNamespace { get; }
    }
}
