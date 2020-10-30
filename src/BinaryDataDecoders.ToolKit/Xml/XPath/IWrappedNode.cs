﻿using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    internal interface IWrappedNode
    {
        IWrappedNode? Previous { get; }
        XPathNavigator Current { get; }
        IWrappedNode? Next { get; }

        IWrappedNode First { get; }
        IWrappedNode Last { get; }
    }
}
