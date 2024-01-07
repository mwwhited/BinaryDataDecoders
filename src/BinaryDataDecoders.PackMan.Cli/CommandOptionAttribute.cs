using System;

namespace BinaryDataDecoders.PackMan.Cli;

[AttributeUsage(AttributeTargets.Property)]
public class CommandOptionAttribute(
    string? @short = null,
    string? command = null
        ) : Attribute
{
    public string? Short { get; init; } = @short;
    public string? Command { get; init; } = command;
    public string? HelpText { get; init; }
    public bool Required { get; init; }
}
