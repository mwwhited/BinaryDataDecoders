using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines.Definitions;

internal static class OnPipelineErrorExtensions
{
    internal static async Task<ErrorHandling> Handle(this OnException? handler, object sender, Exception exception) =>
        await (handler ?? DefaultPipelineError).Invoke(sender, exception);

    internal static readonly OnException DefaultPipelineError = (s, e) =>
    {
        Debug.WriteLine($"Exception On: {s} => {e.Message}");
        return Task.FromResult(ErrorHandling.Throw);
    };
}