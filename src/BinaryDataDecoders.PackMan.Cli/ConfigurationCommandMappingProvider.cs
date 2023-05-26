using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.PackMan.Cli
{
    public class ConfigurationCommandMappingProvider : IConfigurationCommandMappingProvider
    {
        private readonly IEnumerable<IConfigurationCommandMapping> _mappings;

        public ConfigurationCommandMappingProvider(
            IEnumerable<IConfigurationCommandMapping> mappings
            )
        {
            _mappings = mappings;
        }

        public IDictionary<string, string> SwitchMappings =>
            new Dictionary<string, string>(
                from map in _mappings
                from kvp in map
                group kvp by kvp.Key into kvps
                select kvps.First()
            );
    }
}
