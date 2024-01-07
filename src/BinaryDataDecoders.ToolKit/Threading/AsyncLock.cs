using System;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit.Threading;

public class AsyncLock
{
    // http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10266988.aspx
    private readonly AsyncSemaphore m_semaphore;
    private readonly Task<Releaser> m_releaser;

    public AsyncLock()
    {
        m_semaphore = new AsyncSemaphore(1);
        m_releaser = Task.FromResult(new Releaser(this));
    }

    public Task<Releaser> LockAsync()
    {
        var wait = m_semaphore.WaitAsync();
        return wait.IsCompleted ?
            m_releaser :
            wait.ContinueWith((_, state) => new Releaser((AsyncLock)state),
                this, CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
    }

    public readonly struct Releaser : IDisposable
    {
        private readonly AsyncLock m_toRelease;

        internal Releaser(AsyncLock toRelease) { m_toRelease = toRelease; }

        public void Dispose()
        {
            m_toRelease?.m_semaphore.Release();
        }
    }
}
