using System;

namespace BinaryDataDecoders.PackMan.Cli
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CommandOptionAttribute : Attribute
    {
        public CommandOptionAttribute(
            string? @short = null,
            string? command = null
            )
        {
            Short = @short;
            Command = command;
        }

        public string? Short { get; init; }
        public string? Command { get; init; }
        public string? HelpText { get; init; }
        public bool Required { get; init; }
    }
}
