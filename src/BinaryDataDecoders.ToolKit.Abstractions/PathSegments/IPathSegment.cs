namespace BinaryDataDecoders.ToolKit.PathSegments;

public interface IPathSegment<out T> : IPathSegment
{
    T Value { get; }
}
public interface IPathSegment
{
}
