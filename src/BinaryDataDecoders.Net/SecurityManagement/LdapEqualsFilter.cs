using System;

namespace BinaryDataDecoders.Net.SecurityManagement;

public class LdapEqualsFilter : LdapSimpleFilter
{
    public LdapEqualsFilter(string attributeName, Guid value)
        : base(attributeName, LdapFilterTypes.Equals, value)
    {
    }

    public LdapEqualsFilter(string attributeName, byte[] value)
        : base(attributeName, LdapFilterTypes.Equals, value)
    {
    }

    public LdapEqualsFilter(string attributeName, string value)
        : base(attributeName, LdapFilterTypes.Equals, value)
    {
    }
}
