using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace BinaryDataDecoders.TestUtilities.Logging
{
    public class TestLogger : ILogger
    {
        protected readonly TestContext _context;
        protected readonly string? _category;

        public TestLogger(
            TestContext testContext,
            string category = null
            )
        {
            _context = testContext;
            _category = string.IsNullOrWhiteSpace(category) ? null : category;
        }

        public TestLogger(
            ITestContextWrapper contextWrapper,
            string category = null
            )
        {
            _context = contextWrapper.Context;
            _category = string.IsNullOrWhiteSpace(category) ? null : category;
        }

        public virtual IDisposable BeginScope<TState>(TState state) => new LoggerScope<TState>(state);
        public virtual bool IsEnabled(LogLevel logLevel) =>true;
        public virtual void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            void WriteMessage(string message)
            {
                if (_context == null)
                {
                    Debug.WriteLine(message);
                }
                else
                {
                    _context.WriteLine(message);
                }
            }

            if (formatter != null)
            {
                WriteMessage($@"{_category}-LOG>{logLevel}({eventId}): {formatter(state, exception)}");
            }
            else
            {
                WriteMessage($@"{_category}-LOG>{logLevel}({eventId}): {state}");
                if (exception != null)
                {
                    WriteMessage($@"{_category}-ERROR>{logLevel}({eventId}): {exception}");
                }
            }
        }
    }

    public class TestLogger<T> : TestLogger, ILogger<T>
    {
        public TestLogger(
            TestContext testContext
            ) : base(testContext, typeof(T).FullName)
        {
        }
        public TestLogger(
            ITestContextWrapper contextWrapper
            ) : base(contextWrapper, typeof(T).FullName)
        {
        }
    }
}