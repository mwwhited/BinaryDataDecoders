namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface IAttributeNode : INode
    {
        IAttributeNode? Next { get; }
        IAttributeNode? Previous { get; }
    }
}
