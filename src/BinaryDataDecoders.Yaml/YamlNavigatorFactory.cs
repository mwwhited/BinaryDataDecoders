using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using YamlDotNet.RepresentationModel;

namespace BinaryDataDecoders.Yaml
{
    public static class YamlNavigatorFactory
    {

        public static IXPathNavigable ToNavigable(this YamlDocument yaml, XName? rootName = null, string? baseUri = null) =>
            yaml.RootNode.ToNavigable(rootName, baseUri);

        public static IXPathNavigable ToNavigable(this YamlNode yaml, XName? rootName = null, string? baseUri = null) =>
            new ExtensibleNavigator(yaml.AsNode(rootName, baseUri));

        public static INode AsNode(this YamlDocument yaml, XName? rootName = null, string? baseUri = null) =>
            yaml.RootNode.AsNode(rootName, baseUri);

        public static INode AsNode(this YamlNode yaml, XName? rootName = null, string? baseUri = null)
        {
            if (rootName == null || string.IsNullOrWhiteSpace(rootName.LocalName))
                rootName = XName.Get(yaml.NodeType.ToString());

            return new ExtensibleElementNode<YamlNode>(
                rootName,
                yaml,

                 valueSelector: v => v switch
                 {
                     YamlScalarNode scalar => scalar.Value,
                     _ => null,
                 },

                  attributeSelector: a => a switch
                  {
                      _ when !string.IsNullOrWhiteSpace(a.Tag) => new[] { ((XName)nameof(a.Tag), a.Tag ), },
                      _ => null,
                  },

                 childSelector: c => c switch
                 {
                     YamlMappingNode mapping => mapping.Select(i => (XName.Get(i.Key is YamlScalarNode s ? s.Value : "item", rootName.NamespaceName), i.Value)),
                     YamlSequenceNode mapping => mapping.Select(i => (XName.Get("item", rootName.NamespaceName), i)),
                     YamlScalarNode scalar => null,
                     _ => null,
                 }
            );
        }
    }
}
