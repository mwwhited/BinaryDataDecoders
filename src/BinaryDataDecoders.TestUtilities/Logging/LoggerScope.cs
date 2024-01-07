using System;

namespace BinaryDataDecoders.TestUtilities.Logging;

internal class LoggerScope<TState>(TState state) : IDisposable
{
    public void Dispose() { }
}