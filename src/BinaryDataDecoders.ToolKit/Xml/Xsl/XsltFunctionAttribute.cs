using System;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl;

[AttributeUsage(AttributeTargets.Method)]
public class XsltFunctionAttribute(string name) : Attribute
{
    public string Name { get; } = name;

    public bool HideOriginalName { get; set; }
}
