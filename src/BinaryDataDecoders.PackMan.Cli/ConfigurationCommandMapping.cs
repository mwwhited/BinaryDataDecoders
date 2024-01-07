using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.PackMan.Cli;

public class ConfigurationCommandMapping(
    IEnumerable<(string key, string value)> collection
        ) : Dictionary<string, string>(collection.ToDictionary(v => v.key switch
        {
            _ when v.key.StartsWith('-') => v.key,
            _ when v.key.Length == 1 => $"-{v.key}",
            _ => $"--{v.key}",
        }, v => v.value )), IConfigurationCommandMapping
{
}
