using System;

namespace BinaryDataDecoders.TestUtilities
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TestTargetAttribute : Attribute
    {
        public TestTargetAttribute(Type @class) => Class = @class;

        public Type Class { get; }
        public string Member { get; set; }
    }
}
