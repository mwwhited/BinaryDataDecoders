using System;

namespace BinaryDataDecoders.TestUtilities;

/// <summary>
/// This attribute may be used to mark what Class/Member is covered by a particular test method
/// </summary>
/// <remarks>
/// create and instance of TestTargetAttribute
/// </remarks>
/// <param name="class">type of related class</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class TestTargetAttribute(Type @class) : Attribute
{

    /// <summary>
    /// required type reference for related test
    /// </summary>
    public Type Class { get; } = @class;

    /// <summary>
    /// optional member mapping for related test
    /// </summary>
    public string? Member { get; set; }
}
