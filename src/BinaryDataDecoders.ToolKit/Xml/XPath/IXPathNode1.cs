namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface IXPathNode<TXPathNode> : IXPathNode
        where TXPathNode : class, IXPathNode
    {
        TXPathNode? Next { get; }
        TXPathNode? Previous { get; }
    }
}
