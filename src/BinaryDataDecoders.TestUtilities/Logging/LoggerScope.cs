using System;

namespace BinaryDataDecoders.TestUtilities.Logging
{
    internal class LoggerScope<TState> : IDisposable
    {
        private readonly TState _state;
        public LoggerScope(TState state) => _state = state;
        public void Dispose() { }
    }
}