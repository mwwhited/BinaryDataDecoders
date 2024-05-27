using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.Net.SecurityManagement;

public class LdapOrFilter : LdapFilterSetBase
{
    public LdapOrFilter(ILdapFilter filter, params ILdapFilter[] filterSet)
        : this(new[] { filter }.Concat(filterSet))
    {
    }
    public LdapOrFilter(IEnumerable<ILdapFilter> filterSet)
        : base(LdapFilterSetOperations.And, filterSet)
    {
    }
}
