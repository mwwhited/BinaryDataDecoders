using System;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl
{
    [AttributeUsage(AttributeTargets.Method)]
    public class XsltFunctionAttribute : Attribute
    {
        public string Name { get; }

        public bool HideOriginalName { get; set; }

        public XsltFunctionAttribute(string name) => Name = name;
    }
}
