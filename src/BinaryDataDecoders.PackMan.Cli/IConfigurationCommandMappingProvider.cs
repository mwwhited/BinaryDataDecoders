using System.Collections.Generic;

namespace BinaryDataDecoders.PackMan.Cli
{
    public interface IConfigurationCommandMappingProvider
    {
        IDictionary<string, string> SwitchMappings { get; }
    }
}
