namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    internal interface ISimpleNode : IElementNode
    {
        INode? Next { set; }
        INode? Previous { set; }
    }
}
