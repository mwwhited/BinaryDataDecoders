using System;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.Net.SecurityManagement;

public class LdapSimpleFilter : ILdapFilter
{
    public LdapSimpleFilter(string attributeName, LdapFilterTypes operation, Guid value)
        : this(attributeName, operation, value.ToByteArray())
    {
    }

    public LdapSimpleFilter(string attributeName, LdapFilterTypes operation, byte[] value)
        : this(attributeName, operation, null, (value ?? Enumerable.Empty<byte>())
                                                        .Aggregate(new StringBuilder(),
                                                                   (sb, v) => sb.AppendFormat("\\{0:X}", v),
                                                                   sb => sb.ToString()))
    {
    }

    public LdapSimpleFilter(string attributeName, LdapFilterTypes operation, string value)
        : this(attributeName, operation, value, null)
    {
    }
    internal LdapSimpleFilter(string attributeName, LdapFilterTypes operation, string value, string unEscapedSuffix)
    {
        AttributeName = attributeName;
        Operation = operation;
        Value = value;
        UnEscapedSuffix = unEscapedSuffix;
    }

    public string AttributeName { get; private set; }
    public LdapFilterTypes Operation { get; private set; }
    public string Value { get; private set; }
    internal string UnEscapedSuffix { get; private set; }

    public override bool Equals(object obj)
    {
        var inner = obj as LdapSimpleFilter;
        if (inner == null)
        {
            return false;
        }

        return new
        {
            AttributeName = AttributeName.ToUpperInvariant(),
            Operation,
            Value = (Value ?? "").ToUpperInvariant(),
            UnEscapedSuffix = (UnEscapedSuffix ?? "").ToUpperInvariant(),
        }.Equals(new
        {
            AttributeName = inner.AttributeName.ToUpperInvariant(),
            inner.Operation,
            Value = (inner.Value ?? "").ToUpperInvariant(),
            UnEscapedSuffix = (inner.UnEscapedSuffix ?? "").ToUpperInvariant(),
        });
    }

    public override int GetHashCode()
    {
        return new
        {
            AttributeName,
            Operation,
            Value,
            UnEscapedSuffix,
        }.GetHashCode();
    }
}
