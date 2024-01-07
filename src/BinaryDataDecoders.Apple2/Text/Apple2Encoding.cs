using BinaryDataDecoders.ToolKit;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinaryDataDecoders.Apple2.Text;

/// <summary>
/// Represents Apple ][ encoding of Unicode characters 
/// </summary>
public class Apple2Encoding : ASCIIEncoding
{
    /// <summary>
    /// Get common instance of Apple2Encoding
    /// </summary>
    public static Apple2Encoding Apple2 { get; } = new Apple2Encoding();

    /// <summary>
    /// Description for email tags
    /// </summary>
    [ExcludeFromCodeCoverage]
    public override string BodyName => "Apple ][";
    /// <summary>
    /// Name for encoding
    /// </summary>
    [ExcludeFromCodeCoverage]
    public override string EncodingName => "Apple ][";

    /// <summary>
    /// Decodes AppleIi byte array into string
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="byteCount"></param>
    /// <param name="chars"></param>
    /// <param name="charCount"></param>
    /// <returns></returns>
    public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount)
    {
        var len = byteCount < charCount ? byteCount : charCount;

        var byteSpan = new ReadOnlySpan<byte>(bytes, byteCount);
        var charSpan = new Span<char>(chars, charCount);

        byteSpan.CopyToWithTransform(charSpan, i => (char)(i & 0x7f));
        return byteCount < charCount ? byteCount : charCount;
    }
}
