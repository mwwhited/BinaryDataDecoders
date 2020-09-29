namespace BinaryDataDecoders.ToolKit.Xml.Xsl
{
    /// <summary>
    /// Interface for IXsltTransformer
    /// </summary>
    public interface IXsltTransformer
    {
        /// <summary>
        /// Single action transform
        /// </summary>
        /// <param name="template">path for xslt stylesheet</param>
        /// <param name="input">source XML file</param>
        /// <param name="output">resulting text content</param>
        void Transform(string template, string input, string output);

        /// <summary>
        /// Multiaction action transform. 
        /// </summary>
        /// <param name="template">path for xslt stylesheet</param>
        /// <param name="input">Wild card allowed for multiple files</param>
        /// <param name="output">Output and suffix per file.</param>
        void TransformAll(string template, string input, string output);
    }
}