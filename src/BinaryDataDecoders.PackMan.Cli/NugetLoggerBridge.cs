using Microsoft.Extensions.Logging;
using NuGet.Common;
using System.Threading.Tasks;

namespace BinaryDataDecoders.PackMan.Cli;

public class NugetLoggerBridge(
    ILogger<NugetLoggerBridge> logger
        ) : LoggerBase
{
    public override void Log(ILogMessage message) =>
        logger.Log(Convert(message.Level), Convert(message.Code), message, null, (s, e) => s.FormatWithCode());

    private static EventId Convert(NuGetLogCode code) => new((int)code, code.ToString());

    private Microsoft.Extensions.Logging.LogLevel Convert(NuGet.Common.LogLevel level) =>
        level switch
        {
            NuGet.Common.LogLevel.Verbose => Microsoft.Extensions.Logging.LogLevel.Trace,
            NuGet.Common.LogLevel.Warning => Microsoft.Extensions.Logging.LogLevel.Warning,
            NuGet.Common.LogLevel.Information => Microsoft.Extensions.Logging.LogLevel.Information,
            NuGet.Common.LogLevel.Error => Microsoft.Extensions.Logging.LogLevel.Error,
            NuGet.Common.LogLevel.Debug => Microsoft.Extensions.Logging.LogLevel.Debug,
            NuGet.Common.LogLevel.Minimal => Microsoft.Extensions.Logging.LogLevel.Information,
            _ => Microsoft.Extensions.Logging.LogLevel.Debug,
        };

    public override Task LogAsync(ILogMessage message)
    {
        Log(message);
        return Task.CompletedTask;
    }
}
