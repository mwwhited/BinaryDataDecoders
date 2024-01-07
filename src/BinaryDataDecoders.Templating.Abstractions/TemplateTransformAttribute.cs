using System;

namespace BinaryDataDecoders.Templating.Abstractions;

[AttributeUsage(AttributeTargets.Class)]
public class TemplateTransformAttribute(int priority, params string[] targetMediaTypes) : Attribute
{
    public TemplateTransformAttribute(params string[] targetMediaTypes) : this(0, targetMediaTypes) { }

    public string[] TargetMediaTypes { get; } = targetMediaTypes;
    public int Priority { get; } = priority;
}
