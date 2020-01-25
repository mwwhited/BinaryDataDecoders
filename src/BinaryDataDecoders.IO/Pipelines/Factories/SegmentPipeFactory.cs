using BinaryDataDecoders.IO.Pipelines.Definitions;
using BinaryDataDecoders.IO.Pipelines.Segmenters;
using System;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines.Factories
{
    internal class SegmentPipeFactory
    {
        internal async Task CreateReader(PipelineBuildDefinition pipeline, ISegmenter segmenter)
        {
            var context = new
            {
                pipeline = pipeline.Pipe.Reader,
                onError = pipeline.OnReaderError,
                cancellationToken = pipeline.CancellationTokenSource.Token,
                owner = segmenter,
            };

            var completed = false;
            while (!context.cancellationToken.IsCancellationRequested)
            {
                var result = await context.pipeline.ReadAsync(context.cancellationToken);
                try
                {
                    var buffer = result.Buffer;

                    while (!context.cancellationToken.IsCancellationRequested)
                    {
                        var read = await segmenter.TryReadAsync(buffer);
                        buffer = read.RemainingData;
                        if (read.Status == SegmentationStatus.Incomplete)
                        {
                            break;
                        }
                        else if (read.Status == SegmentationStatus.Invalid)
                        {
                            throw new InvalidSegmentationException();
                        }
                    }

                    // Tell the PipeReader how much of the buffer we have consumed
                    context.pipeline.AdvanceTo(buffer.Start, buffer.End);
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

                // Stop reading if there's no more data coming
                if (result.IsCompleted || completed)
                {
                    break;
                }
            }

            //Mark the PipeReader as complete
            context.pipeline.Complete();
        }
    }
}