using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines.Definitions
{
    internal class PipelineBuildDefinition : IPipelineBuildDefinition
    {
        internal PipelineBuildDefinition(Pipe pipe) => this.Pipe = pipe;

        internal Pipe Pipe { get; }
        internal OnException? OnError { get; set; }
        internal Task? PipeWriter { get; set; }
        internal OnException? OnWriterError { get; set; }
        internal Task? PipeReader { get; set; }
        internal OnException? OnReaderError { get; set; }
        internal CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
    }
}