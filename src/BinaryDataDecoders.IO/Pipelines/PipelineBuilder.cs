using BinaryDataDecoders.IO.Pipelines.Definitions;
using BinaryDataDecoders.IO.Pipelines.Factories;
using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines
{
    public static class PipelineBuilder
    {
        public static IPipelineBuildDefinition Follow(this Stream stream, int minimumBufferSize = 4096)
        {
            return new Pipe().FollowStream(stream, minimumBufferSize);
        }
        internal static IPipelineBuildDefinition FollowStream(this Pipe pipe, Stream stream, int minimumBufferSize = 4096)
        {
            return new PipelineBuildDefinition(pipe).FollowStream(stream, minimumBufferSize);
        }
        internal static IPipelineBuildDefinition FollowStream(this IPipelineBuildDefinition pipeline, Stream stream, int minimumBufferSize = 4096)
        {
            if (!(pipeline is PipelineBuildDefinition wrapped))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (wrapped.PipeWriter != null)
            {
                throw new NotSupportedException("this pipeline already has a writer");
            }
            wrapped.PipeWriter = new StreamPipelineFactory().CreateWriter(wrapped, stream, minimumBufferSize);
            return wrapped;
        }

        public static IPipelineBuildDefinition With(this IPipelineBuildDefinition pipeline, ISegmenter segmenter)
        {
            if (!(pipeline is PipelineBuildDefinition wrapped))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (wrapped.PipeReader != null)
            {
                throw new NotSupportedException("this pipeline already has a reader");
            }
            wrapped.PipeReader = new SegmentPipeFactory().CreateReader(wrapped, segmenter);
            return wrapped;
        }
        public static IPipelineBuildDefinition With(this IPipelineBuildDefinition pipeline, Stream stream)
        {
            if (!(pipeline is PipelineBuildDefinition wrapped))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (wrapped.PipeReader != null)
            {
                throw new NotSupportedException("this pipeline already has a reader");
            }
            wrapped.PipeReader = new StreamPipelineFactory().CreateReader(pipeline: wrapped, stream);
            return wrapped;
        }

        //OnError
        //OnReadError
        //OnWriteError

        public static Task RunAsync(this IPipelineBuildDefinition pipeline, CancellationToken cancellationToken = default)
        {
            if (!(pipeline is PipelineBuildDefinition wrapped))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (wrapped.PipeWriter == null)
            {
                throw new NotSupportedException("this pipeline is not configured with a writer");
            }
            else if (wrapped.PipeReader == null)
            {
                throw new NotSupportedException("this pipeline is not configured with a reader");
            }

            cancellationToken.Register(() => wrapped.CancellationTokenSource.Cancel());

            return Task.WhenAll(
                Task.Run(async () => await wrapped.PipeWriter),
                Task.Run(async () => await wrapped.PipeReader)
                );
        }
    }
}