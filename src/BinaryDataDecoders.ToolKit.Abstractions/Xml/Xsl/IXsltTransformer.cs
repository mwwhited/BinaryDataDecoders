using System;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl;

/// <summary>
/// Interface for IXsltTransformer
/// </summary>
public interface IXsltTransformer
{
    /// <summary>
    /// Read input file as XML
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    IXPathNavigable? ReadAsXml(string fileName);

    /// <summary>
    /// Single action transform
    /// </summary>
    /// <param name="template">path for xslt stylesheet</param>
    /// <param name="input">source XML file</param>
    /// <param name="output">resulting text content</param>
    void Transform(string template, string input, string output);

    /// <summary>
    /// Single action transform
    /// </summary>
    /// <param name="template">path for xslt stylesheet</param>
    /// <param name="inputSource"></param>
    /// <param name="input">source XPathNavigable</param>
    /// <param name="output">resulting text content</param>
    void Transform(string template, string inputSource, IXPathNavigable input, string output);

    /// <summary>
    /// Multiaction action transform. 
    /// </summary>
    /// <param name="template">path for xslt stylesheet</param>
    /// <param name="input">Wild card allowed for multiple files</param>
    /// <param name="output">Output and suffix per file.</param>
    void TransformAll(string template, string input, string output, string? exclude = null);

    /// <summary>
    /// Multi-action transform. 
    /// </summary>
    /// <param name="template">path for XSLT style-sheet</param>
    /// <param name="input">Wild card allowed for multiple files</param>
    /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
    /// <param name="output">Output and suffix per file.</param>
    void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? exclude = null);

    /// <summary>
    /// Multi-action transform. Merge globbed files an handoff to single style
    /// </summary>
    /// <param name="template">path for XSLT style-sheet</param>
    /// <param name="input">Wild card allowed for multiple files</param>
    /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
    /// <param name="output">Output and suffix per file.</param>
    void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? exclude = null);
}