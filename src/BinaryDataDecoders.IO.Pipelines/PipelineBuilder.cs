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
        public static IPipelineBuildDefinition Follow(this Stream stream, int minimumBufferSize = 4096) =>
            new Pipe().FollowStream(stream, minimumBufferSize);
        internal static IPipelineBuildDefinition FollowStream(this Pipe pipe, Stream stream, int minimumBufferSize = 4096) =>
            new PipelineBuildDefinition(pipe).FollowStream(stream, minimumBufferSize);

        internal static IPipelineBuildDefinition FollowStream(this IPipelineBuildDefinition pipeline, Stream stream, int minimumBufferSize = 4096)
        {
            if (!(pipeline is PipelineBuildDefinition def))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (def.PipeWriter != null)
            {
                throw new NotSupportedException("this pipeline already has a writer");
            }
            def.PipeWriter = new StreamPipelineFactory().CreateWriter(def, stream, minimumBufferSize);
            return def;
        }

        public static IPipelineBuildDefinition With(this IPipelineBuildDefinition pipeline, ISegmenter segmenter)
        {
            if (!(pipeline is PipelineBuildDefinition def))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (def.PipeReader != null)
            {
                throw new NotSupportedException("this pipeline already has a reader");
            }
            def.PipeReader = new SegmentPipeFactory().CreateReader(def, segmenter);
            return def;
        }
        public static IPipelineBuildDefinition With(this IPipelineBuildDefinition pipeline, Stream stream)
        {
            if (!(pipeline is PipelineBuildDefinition def))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (def.PipeReader != null)
            {
                throw new NotSupportedException("this pipeline already has a reader");
            }
            def.PipeReader = new StreamPipelineFactory().CreateReader(pipeline: def, stream);
            return def;
        }

        public static IPipelineBuildDefinition OnError(this IPipelineBuildDefinition pipeline, OnPipelineError onPipelineError)
        {
            if (!(pipeline is PipelineBuildDefinition def))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (def.PipeReader != null)
            {
                throw new NotSupportedException("this pipeline already has a reader");
            }
            def.OnError = onPipelineError;
            return def;
        }
        public static IPipelineBuildDefinition OnReaderError(this IPipelineBuildDefinition pipeline, OnPipelineError onPipelineError)
        {
            if (!(pipeline is PipelineBuildDefinition def))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (def.PipeReader != null)
            {
                throw new NotSupportedException("this pipeline already has a reader");
            }
            def.OnReaderError = onPipelineError;
            return def;
        }
        public static IPipelineBuildDefinition OnWriterError(this IPipelineBuildDefinition pipeline, OnPipelineError onPipelineError)
        {
            if (!(pipeline is PipelineBuildDefinition def))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (def.PipeReader != null)
            {
                throw new NotSupportedException("this pipeline already has a reader");
            }
            def.OnWriterError = onPipelineError;
            return def;
        }

        public static Task RunAsync(this IPipelineBuildDefinition pipeline, CancellationToken cancellationToken = default)
        {
            if (!(pipeline is PipelineBuildDefinition def))
            {
                throw new NotSupportedException($"{pipeline.GetType()} is not supported");
            }
            else if (def.PipeWriter == null)
            {
                throw new NotSupportedException("this pipeline is not configured with a writer");
            }
            else if (def.PipeReader == null)
            {
                throw new NotSupportedException("this pipeline is not configured with a reader");
            }

            cancellationToken.Register(() => def.CancellationTokenSource.Cancel());

            return Task.WhenAll(
                Task.Run(async () => await def.PipeWriter),
                Task.Run(async () => await def.PipeReader)
                );
        }
    }
}