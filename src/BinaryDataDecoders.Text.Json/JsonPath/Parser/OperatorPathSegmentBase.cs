namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public abstract class OperatorPathSegmentBase<TEnum> : WrappedPathSegmentBase<TEnum>
    {
        protected OperatorPathSegmentBase(TEnum @enum) : base(@enum) { }
    }
}
