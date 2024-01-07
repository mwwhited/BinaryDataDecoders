using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit.Tests.Linq.Search;

public interface ISortQuery<T> : ISortQuery { }
public interface ISortQuery
{
    IDictionary<string, OrderDirections> OrderBy { get; }
}
