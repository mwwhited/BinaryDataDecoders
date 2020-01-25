using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines.Definitions
{
    internal static class OnPipelineErrorExtensions
    {
        internal static async Task<PipelineErrorHandling> Handle(this OnPipelineError? handler, object sender, Exception exception)
        {
            return await (handler ?? DefaultPipelineError).Invoke(sender, exception);
        }

        internal static readonly OnPipelineError DefaultPipelineError = (s, e) =>
        {
            Debug.WriteLine($"Exception On: {s} => {e.Message}");
            return Task.FromResult(PipelineErrorHandling.Throw);
        };
    }
}