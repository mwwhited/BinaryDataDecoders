using System;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.Xml.XPath
{
    partial class SyntaxTreeXPathNavigator
    {
        public override XmlWriter AppendChild() => throw new NotSupportedException();
        public override void AppendChild(string newChild) => throw new NotSupportedException();
        public override void AppendChild(XmlReader newChild) => throw new NotSupportedException();
        public override void AppendChild(XPathNavigator newChild) => throw new NotSupportedException();
        public override void AppendChildElement(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override void CreateAttribute(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override XmlWriter CreateAttributes() => throw new NotSupportedException();
        public override void DeleteRange(XPathNavigator lastSiblingToDelete) => throw new NotSupportedException();
        public override void DeleteSelf() => throw new NotSupportedException();
        public override XmlWriter InsertAfter() => throw new NotSupportedException();
        public override void InsertAfter(string newSibling) => throw new NotSupportedException();
        public override void InsertAfter(XmlReader newSibling) => throw new NotSupportedException();
        public override void InsertAfter(XPathNavigator newSibling) => throw new NotSupportedException();
        public override XmlWriter InsertBefore() => throw new NotSupportedException();
        public override void InsertBefore(string newSibling) => throw new NotSupportedException();
        public override void InsertBefore(XmlReader newSibling) => throw new NotSupportedException();
        public override void InsertBefore(XPathNavigator newSibling) => throw new NotSupportedException();
        public override void InsertElementAfter(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override void InsertElementBefore(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override XmlWriter PrependChild() => throw new NotSupportedException();
        public override void PrependChild(string newChild) => throw new NotSupportedException();
        public override void PrependChild(XmlReader newChild) => throw new NotSupportedException();
        public override void PrependChild(XPathNavigator newChild) => throw new NotSupportedException();
        public override void PrependChildElement(string prefix, string localName, string namespaceURI, string value) => throw new NotSupportedException();
        public override void ReplaceSelf(string newNode) => throw new NotSupportedException();
        public override void ReplaceSelf(XmlReader newNode) => throw new NotSupportedException();
        public override XmlWriter ReplaceRange(XPathNavigator lastSiblingToReplace) => throw new NotSupportedException();
        public override void ReplaceSelf(XPathNavigator newNode) => throw new NotSupportedException();
        public override void SetTypedValue(object typedValue) => throw new NotSupportedException();
        public override void SetValue(string value) => throw new NotSupportedException();
        public override void WriteSubtree(XmlWriter writer) => throw new NotSupportedException();
    }
}
