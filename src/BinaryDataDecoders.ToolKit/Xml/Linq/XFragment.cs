using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.Linq;


public class XFragment : IList<XNode>
{
    // https://github.com/OutOfBandDevelopment/Samples/blob/master/HandyClasses/XFragment.cs
    private IList<XNode> Nodes { get; } = new List<XNode>();

    public XFragment(IEnumerable<XNode> nodes)
    {
        foreach (var node in (nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null))
            this.Nodes.Add(node);
    }

    public XFragment(XNode node, params XNode[] nodes)
        : this(new[] { node }.Concat(nodes ?? Enumerable.Empty<XNode>()))
    {
    }

    public XFragment(string? xml)
        : this(Parser(xml).ToArray())
    {
    }
    public XFragment(XmlReader xmlReader)
        : this(Parser(xmlReader).ToArray())
    {
    }

    private static IEnumerable<XNode> Parser(string? xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
            yield break;

        var settings = new XmlReaderSettings
        {
            ConformanceLevel = ConformanceLevel.Fragment,
            IgnoreWhitespace = true
        };

        using (var stringReader = new StringReader(xml))
        using (var xmlReader = XmlReader.Create(stringReader, settings))
        {
            foreach (var node in XFragment.Parser(xmlReader))
                yield return node;
        }
    }

    private static IEnumerable<XNode> Parser(XmlReader xmlReader)
    {
        if (xmlReader == null)
            yield break;

        xmlReader.MoveToContent();
        while (xmlReader.ReadState != ReadState.EndOfFile)
            yield return XNode.ReadFrom(xmlReader);
    }

    public override string? ToString() => this;

    public XmlReader CreateReader() => XmlReader.Create(new StringReader(this), new XmlReaderSettings
    {
        ConformanceLevel = ConformanceLevel.Fragment,
    });

    public static XFragment Parse(string xml) => new(xml);
    public static XFragment Parse(XmlReader xmlReader) => new(xmlReader);

    #region IEnumerable 

    public IEnumerator<XNode> GetEnumerator() => (Nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion

    #region IList

    public int Count => Nodes.Count;
    public bool IsReadOnly => Nodes.IsReadOnly;
    public XNode this[int index]
    {
        get => Nodes[index];
        set => Nodes[index] = value;
    }

    public int IndexOf(XNode item) => Nodes.IndexOf(item);
    public void Insert(int index, XNode item) => Nodes.Insert(index, item);
    public void RemoveAt(int index) => Nodes.RemoveAt(index);
    public void Add(XNode item) => Nodes.Add(item);
    public void Clear() => Nodes.Clear();
    public bool Contains(XNode item) => Nodes.Contains(item);
    public void CopyTo(XNode[] array, int arrayIndex) => Nodes.CopyTo(array, arrayIndex);
    public bool Remove(XNode item) => Nodes.Remove(item);

    #endregion

    #region Conversions 

    public static implicit operator XFragment(string? xml) => new(xml);

    public static implicit operator string?(XFragment fragment)
    {
        if (fragment == null)
            return null;

        var settings = new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
            ConformanceLevel = ConformanceLevel.Fragment,
        };
        var sb = new StringBuilder();
        using (var xmlwriter = XmlWriter.Create(sb, settings))
        {
            foreach (var node in fragment)
            {
                xmlwriter.WriteNode(node.CreateReader(), false);
            }
        }

        return sb.ToString();
    }

    public static implicit operator XFragment(XNode[] nodes) => new(nodes);

    public static implicit operator XFragment(XNode node) => new(node);

    #endregion
}
