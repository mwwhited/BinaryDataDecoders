namespace BinaryDataDecoders.ToolKit.Tests.Linq.Search;

public interface IFilterParameter
{
    string Operation { get; }
    object? Value { get; }
}
