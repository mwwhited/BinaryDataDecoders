using System;

namespace BinaryDataDecoders.IO
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DeviceTargetAttribute : Attribute
    {
        public DeviceTargetAttribute(Type target) => Target = target;
        public Type Target { get; }
    }
}