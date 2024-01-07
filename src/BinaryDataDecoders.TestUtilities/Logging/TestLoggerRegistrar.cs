using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.TestUtilities.Logging;

public static class TestLoggerRegistrar
{
    public static IServiceCollection AddTestLoggingServices(this IServiceCollection services, TestContext context) =>
        services
            .AddTransient<ITestContextWrapper>(sp => new TestContextWrapper(context))
            .AddSingleton(sp => LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Debug).AddDebug()))
            .AddSingleton<ILogger, TestLogger>()
            .AddSingleton(typeof(ILogger<>), typeof(TestLogger<>))
        ;
}
