using System;
using System.IO;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines
{

    internal class StreamPipelineFactory
    {
        //https://devblogs.microsoft.com/dotnet/system-io-pipelines-high-performance-io-in-net/
        internal async Task CreateWriter(PipelineBuilder wrapped, Stream stream, int minimumBufferSize)
        {
            var context = new
            {
                pipeline = wrapped.Pipe.Writer,
                onError = wrapped.OnWriterError,
                cancellationToken = wrapped.CancellationTokenSource.Token,
                owner = stream,
            };

            var completed = false;
            while (!context.cancellationToken.IsCancellationRequested)
            {
                // Allocate at least 512 bytes from the PipeWriter
                var memory = context.pipeline.GetMemory(minimumBufferSize);
                try
                {
                    var read = await context.owner.ReadAsync(memory, context.cancellationToken);
                    if (read == 0)
                    {
                        break;
                    }

                    // Tell the PipeWriter how much was read from the Socket
                    context.pipeline.Advance(read);
                }
                catch (Exception ex)
                {
                    var errorHandling = await context.onError.Handle(context.owner, ex);
                    switch (errorHandling)
                    {
                        case PipelineErrorHandling.Ignore:
                            //Note: do nothing
                            break;

                        case PipelineErrorHandling.Stop:
                            completed = true;
                            break;

                        default:
                        case PipelineErrorHandling.Throw:
                            context.pipeline.Complete(ex);
                            return;
                    }
                }

                // Make the data available to the PipeReader
                var result = await context.pipeline.FlushAsync();
                if (result.IsCompleted || completed)
                {
                    break;
                }
            }

            // Tell the PipeReader that there's no more data coming
            context.pipeline.Complete();
        }

        internal Task? CreateReader(PipelineBuilder pipeline, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}