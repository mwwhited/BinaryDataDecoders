namespace BinaryDataDecoders.ToolKit;

/// <summary>
/// delimiter used optin for <see cref="MemoryEx"/>
/// </summary>
public enum DelimiterOptions
{
    /// <summary>
    /// Do not include the delimiter in the resulting memory chunks
    /// </summary>
    Exclude = 0,
    /// <summary>
    /// Include delimiter in the left side of break
    /// </summary>
    Return = -1,
    /// <summary>
    /// Include the delimiter in the right side of the break;
    /// </summary>
    Carry = 1,
}
