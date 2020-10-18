namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface IXPathAttributeNode : IXPathNode<IXPathAttributeNode>
    {
        IXPathAttributeNode? Next { get; }
        IXPathAttributeNode? Previous { get; }
    }
}
