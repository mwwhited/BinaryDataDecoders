using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit.Tests.Linq.Search;

public interface IFilterQuery<T> : IFilterQuery { }
public interface IFilterQuery
{
    IDictionary<string, IFilterParameter> Filter { get; }
}
