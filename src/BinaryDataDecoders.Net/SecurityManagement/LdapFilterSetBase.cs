using System.Collections.Generic;

namespace BinaryDataDecoders.Net.SecurityManagement;

public abstract class LdapFilterSetBase : ILdapFilter
{
    public LdapFilterSetBase(LdapFilterSetOperations operation, IEnumerable<ILdapFilter> filterSet)
    {
        Operation = operation;
        FilterSet = filterSet;
    }

    public LdapFilterSetOperations Operation { get; private set; }
    public IEnumerable<ILdapFilter> FilterSet { get; private set; }
}
