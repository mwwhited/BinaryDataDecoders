using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.PackMan.Cli;

public class ConfigurationCommandMappingProvider(
    IEnumerable<IConfigurationCommandMapping> mappings
        ) : IConfigurationCommandMappingProvider
{
    public IDictionary<string, string> SwitchMappings =>
        new Dictionary<string, string>(
            from map in mappings
            from kvp in map
            group kvp by kvp.Key into kvps
            select kvps.First()
        );
}
