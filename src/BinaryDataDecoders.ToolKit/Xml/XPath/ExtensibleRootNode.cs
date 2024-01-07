﻿using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath;

[DebuggerDisplay("R:>{Name}")]
internal class ExtensibleRootNode<T>(INode child) : IElementNode, IRootNode
{
    public INode? FirstChild { get; } = child;

    public XName Name => FirstChild?.Name ?? "root";

    public INode? Parent => null;
    public string? Value => null;

    public INode? Next => null;
    public INode? Previous => null;

    public IAttributeNode? FirstAttribute => null;
    public INamespaceNode? FirstNamespace => null;

    public XPathNodeType NodeType { get; } = XPathNodeType.Root;
}
