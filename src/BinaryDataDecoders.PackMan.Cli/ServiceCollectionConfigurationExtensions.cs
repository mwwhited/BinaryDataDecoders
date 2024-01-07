using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BinaryDataDecoders.PackMan.Cli;

public static class ServiceCollectionConfigurationExtensions
{
    private const string Options = nameof(Options);

    private static string CleanEnd(string value, string end) =>
        value switch
        {
            string name when name.EndsWith(end) => name[..^end.Length],
            string name => name,
        };
    private static IServiceCollection ConfigureCommandMappings(
        this IServiceCollection services,
        IEnumerable<(string key, string value)> values
        ) => services.AddTransient<IConfigurationCommandMapping>(
            _ => new ConfigurationCommandMapping(values)
            );
    private static IServiceCollection ConfigureCommandMappings<TConfig>(
        this IServiceCollection services
        ) => services.ConfigureCommandMappings(
        from property in typeof(TConfig).GetProperties()
        let config = string.Join(':', CleanEnd(typeof(TConfig).Name, Options), property.Name)
        from attribute in property.GetCustomAttributes<CommandOptionAttribute>()
        from value in new[] { attribute.Short, attribute.Command }
        where !string.IsNullOrWhiteSpace(value)
        select (value, config)
        );

    public static IServiceCollection AddCommandLineOption<TConfig>(
        this IServiceCollection services
        )
        where TConfig : class
    {
        services.AddOptions<TConfig>().BindConfiguration(CleanEnd(typeof(TConfig).Name, Options));
        services.AddTransient(sp => sp.GetRequiredService<IOptions<TConfig>>().Value);
        services.ConfigureCommandMappings<TConfig>();
        services.TryAddSingleton<IConfigurationCommandMappingProvider, ConfigurationCommandMappingProvider>();
        return services;
    }
}
