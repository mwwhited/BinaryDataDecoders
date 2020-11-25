using System.Xml.Schema;

namespace BinaryDataDecoders.ToolKit.Xml.Schema
{
    public class XmlValidationResult
    {
        public XmlSchemaException Exception { get; internal set; }
        public string Message { get; internal set; }
        public XmlSeverityType Severity { get; internal set; }
    }
}
