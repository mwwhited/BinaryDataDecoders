using System;

namespace BinaryDataDecoders.TestUtilities
{
    /// <summary>
    /// This attribute may be used to mark what Class/Member is covered by a particular test method
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TestTargetAttribute : Attribute
    {
        /// <summary>
        /// create and instance of TestTargetAttribute
        /// </summary>
        /// <param name="class">type of related class</param>
        public TestTargetAttribute(Type @class) => Class = @class;

        /// <summary>
        /// required type reference for related test
        /// </summary>
        public Type Class { get; }

        /// <summary>
        /// optional member mapping for related test
        /// </summary>
        public string? Member { get; set; }
    }
}
