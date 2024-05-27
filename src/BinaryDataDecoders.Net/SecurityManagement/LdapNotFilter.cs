namespace BinaryDataDecoders.Net.SecurityManagement;

public class LdapNotFilter : ILdapFilter
{
    public LdapNotFilter(ILdapFilter wrapped)
    {
        Wrapped = wrapped;
    }

    public ILdapFilter Wrapped { get; private set; }

    public override bool Equals(object obj)
    {
        var inner = obj as LdapNotFilter;
        if (inner == null)
        {
            return false;
        }
        return Wrapped.Equals(inner.Wrapped);
    }

    public override int GetHashCode()
    {
        return new
        {
            Wrapped,
        }.GetHashCode();
    }
}
