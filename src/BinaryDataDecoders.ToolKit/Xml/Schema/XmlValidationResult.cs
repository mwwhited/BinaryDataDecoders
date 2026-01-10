using System.Xml.Schema;

namespace BinaryDataDecoders.ToolKit.Xml.Schema;

public class XmlValidationResult
{
    public XmlSchemaException Exception { get; init; } = null!;
    public string Message { get; init; } = null!;
    public XmlSeverityType Severity { get; init; }
}
