﻿using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines.Definitions
{
    internal class PipelineBuildDefinition : IPipelineBuildDefinition
    {
        internal PipelineBuildDefinition(Pipe pipe)
        {
            this.Pipe = pipe;
        }

        public Pipe Pipe { get; }

        public Task? PipeWriter { get; internal set; }
        public OnPipelineError? OnWriterError { get; internal set; }
        public Task? PipeReader { get; internal set; }

        public OnPipelineError? OnReaderError { get; internal set; }

        public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
    }
}