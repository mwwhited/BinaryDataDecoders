namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface INamespaceNode : INode
    {
        INamespaceNode? Next { get; }
        INamespaceNode? Previous { get; }
    }
}
