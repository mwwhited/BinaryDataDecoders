namespace BinaryDataDecoders.ToolKit.Tests.Linq.Search;

public interface IQuery<T> : IQuery, IPageQuery<T>, ISortQuery<T>, IFilterQuery<T>, ISearchQuery<T> { }
public interface IQuery : IPageQuery, ISortQuery, IFilterQuery, ISearchQuery { }
