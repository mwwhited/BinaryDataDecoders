namespace BinaryDataDecoders.ToolKit.Tests.Linq.Search;

public interface ISearchQuery<T> : ISearchQuery { }
public interface ISearchQuery
{
    string? Term { get; }
}