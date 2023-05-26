using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BinaryDataDecoders.PackMan.Cli
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            string[] args
            ) => services
            .AddLogging(opt =>
            {
                opt.AddConsole();
            })
            .AddSingleton<IConfiguration>(sp =>
                new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .AddCommandLine(opts =>
                    {
                        opts.Args = args;
                        opts.SwitchMappings = sp.GetService<IConfigurationCommandMappingProvider>()?.SwitchMappings;
                    })
                    .Build()
            )
            ;
    }
}
