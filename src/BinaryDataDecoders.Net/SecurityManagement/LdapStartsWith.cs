namespace BinaryDataDecoders.Net.SecurityManagement;

public class LdapStartsWith : LdapSimpleFilter
{
    public LdapStartsWith(string attributeName, string value)
        : base(attributeName, LdapFilterTypes.Equals, value, "*")
    {
    }
}
