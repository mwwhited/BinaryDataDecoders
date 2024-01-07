using System;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit.Threading;

public class AsyncCountdownEvent
{
    // http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266930.aspx
    private readonly AsyncManualResetEvent m_amre = new();
    private int m_count;

    public AsyncCountdownEvent(int initialCount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(initialCount, nameof(initialCount));
        m_count = initialCount;
    }

    public Task WaitAsync() { return m_amre.WaitAsync(); }

    public void Signal()
    {
        if (m_count <= 0)
            throw new InvalidOperationException();

        int newCount = Interlocked.Decrement(ref m_count);
        if (newCount == 0)
            m_amre.Set();
        else if (newCount < 0)
            throw new InvalidOperationException();
    }

    public Task SignalAndWait()
    {
        Signal();
        return WaitAsync();
    }
}
