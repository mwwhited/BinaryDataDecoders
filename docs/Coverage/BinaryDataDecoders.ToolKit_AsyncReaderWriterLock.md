# BinaryDataDecoders.ToolKit.Threading.AsyncReaderWriterLock

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.AsyncReaderWriterLock` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                 |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `53`                                                         |
| Coverablelines  | `53`                                                         |
| Totallines      | `126`                                                        |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `22`                                                         |
| Branchcoverage  | `0`                                                          |
| Coveredmethods  | `0`                                                          |
| Totalmethods    | `7`                                                          |
| Methodcoverage  | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `ctor`            |
| 4          | 0     | 0        | `ReaderLockAsync` |
| 6          | 0     | 0        | `ReaderRelease`   |
| 2          | 0     | 0        | `WriterLockAsync` |
| 6          | 0     | 0        | `WriterRelease`   |
| 1          | 0     | 100      | `ctor`            |
| 4          | 0     | 0        | `Dispose`         |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Threading/AsyncReaderWriterLock.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Threading
〰6:   {
〰7:       public class AsyncReaderWriterLock
〰8:       {
〰9:       // http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10267069.aspx
〰10:          private readonly Task<Releaser> m_readerReleaser;
〰11:          private readonly Task<Releaser> m_writerReleaser;
〰12:  
‼13:          private readonly Queue<TaskCompletionSource<Releaser>> m_waitingWriters = new Queue<TaskCompletionSource<Releaser>>();
‼14:          private TaskCompletionSource<Releaser> m_waitingReader = new TaskCompletionSource<Releaser>();
〰15:          private int m_readersWaiting;
〰16:          private int m_status;
〰17:  
〰18:          public AsyncReaderWriterLock()
〰19:          {
‼20:              m_readerReleaser = Task.FromResult(new Releaser(this, false));
‼21:              m_writerReleaser = Task.FromResult(new Releaser(this, true));
‼22:          }
〰23:  
〰24:          public Task<Releaser> ReaderLockAsync()
〰25:          {
‼26:              lock (m_waitingWriters)
〰27:              {
‼28:                  if (m_status >= 0 && m_waitingWriters.Count == 0)
〰29:                  {
‼30:                      ++m_status;
‼31:                      return m_readerReleaser;
〰32:                  }
〰33:                  else
〰34:                  {
‼35:                      ++m_readersWaiting;
‼36:                      return m_waitingReader.Task.ContinueWith(t => t.Result);
〰37:                  }
〰38:              }
‼39:          }
〰40:          private void ReaderRelease()
〰41:          {
‼42:              TaskCompletionSource<Releaser> toWake = null;
〰43:  
〰44:  
‼45:              lock (m_waitingWriters)
〰46:              {
‼47:                  --m_status;
‼48:                  if (m_status == 0 && m_waitingWriters.Count > 0)
〰49:                  {
‼50:                      m_status = -1;
‼51:                      toWake = m_waitingWriters.Dequeue();
〰52:                  }
‼53:              }
〰54:  
‼55:              if (toWake != null)
‼56:                  toWake.SetResult(new Releaser(this, true));
‼57:          }
〰58:  
〰59:  
〰60:          public Task<Releaser> WriterLockAsync()
〰61:          {
‼62:              lock (m_waitingWriters)
〰63:              {
‼64:                  if (m_status == 0)
〰65:                  {
‼66:                      m_status = -1;
‼67:                      return m_writerReleaser;
〰68:                  }
〰69:                  else
〰70:                  {
‼71:                      var waiter = new TaskCompletionSource<Releaser>();
‼72:                      m_waitingWriters.Enqueue(waiter);
‼73:                      return waiter.Task;
〰74:                  }
〰75:              }
‼76:          }
〰77:  
〰78:          private void WriterRelease()
〰79:          {
‼80:              TaskCompletionSource<Releaser> toWake = null;
‼81:              bool toWakeIsWriter = false;
〰82:  
‼83:              lock (m_waitingWriters)
〰84:              {
‼85:                  if (m_waitingWriters.Count > 0)
〰86:                  {
‼87:                      toWake = m_waitingWriters.Dequeue();
‼88:                      toWakeIsWriter = true;
〰89:                  }
‼90:                  else if (m_readersWaiting > 0)
〰91:                  {
‼92:                      toWake = m_waitingReader;
‼93:                      m_status = m_readersWaiting;
‼94:                      m_readersWaiting = 0;
‼95:                      m_waitingReader = new TaskCompletionSource<Releaser>();
〰96:                  }
‼97:                  else m_status = 0;
‼98:              }
〰99:  
‼100:             if (toWake != null)
‼101:                 toWake.SetResult(new Releaser(this, toWakeIsWriter));
‼102:         }
〰103: 
〰104: 
〰105:         public struct Releaser : IDisposable
〰106:         {
〰107:             private readonly AsyncReaderWriterLock m_toRelease;
〰108:             private readonly bool m_writer;
〰109: 
〰110:             internal Releaser(AsyncReaderWriterLock toRelease, bool writer)
〰111:             {
‼112:                 m_toRelease = toRelease;
‼113:                 m_writer = writer;
‼114:             }
〰115: 
〰116:             public void Dispose()
〰117:             {
‼118:                 if (m_toRelease != null)
〰119:                 {
‼120:                     if (m_writer) m_toRelease.WriterRelease();
‼121:                     else m_toRelease.ReaderRelease();
〰122:                 }
‼123:             }
〰124:         }
〰125:     }
〰126: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

