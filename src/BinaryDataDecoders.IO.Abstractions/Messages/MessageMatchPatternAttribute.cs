using System;

namespace BinaryDataDecoders.IO.Messages
{
    /// <summary>
    /// prefix pattern to identify decoding patterns
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
    public class MessageMatchPatternAttribute : Attribute
    {
        /// <summary>
        /// attribute to assign expected prefix to related structure
        /// </summary>
        /// <param name="pattern">prefix pattern to identify decoding patterns
        /// <code>
        ///     allowed characters: matches on a nibble
        ///         0 to F hexadecimal value
        ///         period (.), asterisk (*), or question (?) may be used for wild cards
        ///         other characters are ignored
        /// </code>
        /// </param>
        public MessageMatchPatternAttribute(string pattern)
        {
            Pattern = pattern;
        }

        /// <summary>
        /// prefix pattern to identify decoding patterns
        /// </summary>
        public string Pattern { get; }

        /// <summary>
        /// prefix pattern to identify decoding patterns
        /// </summary>
        public string? Mask { get; set; }

        /// <summary>
        /// override check order
        /// </summary>
        public int Priority { get; set; }

    }
}
