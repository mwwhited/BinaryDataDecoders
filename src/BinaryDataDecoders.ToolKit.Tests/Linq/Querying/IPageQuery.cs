namespace BinaryDataDecoders.ToolKit.Tests.Linq.Search;

public interface IPageQuery<T> : IPageQuery { }
public interface IPageQuery
{
    int PageLength { get; }
    int CurrentPage { get; }
    bool ExcludeCount { get; }
}
