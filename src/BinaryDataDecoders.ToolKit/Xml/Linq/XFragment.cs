using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.Linq
{

    public class XFragment : IList<XNode>
    {
        private IList<XNode> Nodes { get; } = new List<XNode>();

        public XFragment(IEnumerable<XNode> nodes)
        {
            foreach (var node in nodes ?? Enumerable.Empty<XNode>().Where(n => n != null))
                this.Nodes.Add(node);
        }

        public XFragment(XNode node, params XNode[] nodes)
            : this(new[] { node }.Concat(nodes ?? Enumerable.Empty<XNode>()))
        {
        }

        public XFragment(string xml)
            : this(XFragment.Parser(xml).ToArray())
        {
        }
        public XFragment(XmlReader xmlReader)
            : this(XFragment.Parser(xmlReader).ToArray())
        {
        }

        private static IEnumerable<XNode> Parser(string xml)
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
                foreach (var node in Parser(xmlReader))
                    yield return node;
        }

        private static IEnumerable<XNode> Parser(XmlReader xmlReader)
        {
            if (xmlReader == null)
                yield break;

            xmlReader.MoveToContent();
            while (xmlReader.ReadState != ReadState.EndOfFile)
                yield return XNode.ReadFrom(xmlReader);
        }

        public override string ToString() => (string)this;
        public XmlReader CreateReader() =>
            XmlReader.Create(new StringReader(this), new XmlReaderSettings
            {
                ConformanceLevel = ConformanceLevel.Fragment,
            });

        public static XFragment Parse(string xml) => new XFragment(xml);
        public static XFragment Parse(XmlReader xmlReader) => new XFragment(xmlReader);

        #region IEnumerable 

        public IEnumerator<XNode> GetEnumerator() =>
            (this.Nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        #endregion

        #region IList

        public int Count => this.Nodes.Count;
        public bool IsReadOnly => this.Nodes.IsReadOnly;
        public XNode this[int index]
        {
            get => this.Nodes[index];
            set => this.Nodes[index] = value;
        }

        public int IndexOf(XNode item) => this.Nodes.IndexOf(item);
        public void Insert(int index, XNode item) => this.Nodes.Insert(index, item);
        public void RemoveAt(int index) => this.Nodes.RemoveAt(index);
        public void Add(XNode item) => this.Nodes.Add(item);
        public void Clear() => this.Nodes.Clear();
        public bool Contains(XNode item) => this.Nodes.Contains(item);
        public void CopyTo(XNode[] array, int arrayIndex) => this.Nodes.CopyTo(array, arrayIndex);
        public bool Remove(XNode item) => this.Nodes.Remove(item);

        #endregion

        #region Conversions 

        public static implicit operator XFragment(string xml) => new XFragment(xml);
        public static implicit operator string(XFragment fragment)
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
                foreach (var node in fragment)
                {
                    node.WriteTo(xmlwriter);
                    //var reader = node.CreateReader();
                    //    xmlwriter.WriteNode(reader, false);
                }

            return sb.ToString();
        }

        public static implicit operator XFragment(XNode[] nodes) => new XFragment(nodes);
        public static implicit operator XFragment(XNode node) => new XFragment(node);

        #endregion
    }
}
