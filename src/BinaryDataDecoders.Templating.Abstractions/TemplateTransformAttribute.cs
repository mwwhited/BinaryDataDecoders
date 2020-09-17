using System;

namespace BinaryDataDecoders.Templating.Abstractions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TemplateTransformAttribute : Attribute
    {
        public TemplateTransformAttribute(params string[] targetMediaTypes) : this(0, targetMediaTypes) { }
        public TemplateTransformAttribute(int priority, params string[] targetMediaTypes)
        {
            this.Priority = priority;
            this.TargetMediaTypes = targetMediaTypes;
        }

        public string[] TargetMediaTypes { get; }
        public int Priority { get; }
    }
}
