# BinaryDataDecoders.ToolKit.Threading.AsyncReaderWriterLock

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.AsyncReaderWriterLock` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                 |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `104`                                                        |
| Coverablelines  | `104`                                                        |
| Totallines      | `249`                                                        |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `44`                                                         |
| Branchcoverage  | `0`                                                          |
| Coveredmethods  | `0`                                                          |
| Totalmethods    | `14`                                                         |
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
〰5:   namespace BinaryDataDecoders.ToolKit.Threading;
〰6:   
〰7:   public class AsyncReaderWriterLock
〰8:   {
〰9:       // http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10267069.aspx
〰10:      private readonly Task<Releaser> m_readerReleaser;
〰11:      private readonly Task<Releaser> m_writerReleaser;
〰12:  
‼13:      private readonly Queue<TaskCompletionSource<Releaser>> m_waitingWriters = new();
‼14:      private TaskCompletionSource<Releaser> m_waitingReader = new();
〰15:      private int m_readersWaiting;
〰16:      private int m_status;
〰17:  
〰18:      public AsyncReaderWriterLock()
〰19:      {
‼20:          m_readerReleaser = Task.FromResult(new Releaser(this, false));
‼21:          m_writerReleaser = Task.FromResult(new Releaser(this, true));
‼22:      }
〰23:  
〰24:      public Task<Releaser> ReaderLockAsync()
〰25:      {
‼26:          lock (m_waitingWriters)
〰27:          {
‼28:              if (m_status >= 0 && m_waitingWriters.Count == 0)
〰29:              {
‼30:                  ++m_status;
‼31:                  return m_readerReleaser;
〰32:              }
〰33:              else
〰34:              {
‼35:                  ++m_readersWaiting;
‼36:                  return m_waitingReader.Task.ContinueWith(t => t.Result);
〰37:              }
〰38:          }
‼39:      }
〰40:      private void ReaderRelease()
〰41:      {
‼42:          TaskCompletionSource<Releaser>? toWake = null;
‼43:          lock (m_waitingWriters)
〰44:          {
‼45:              --m_status;
‼46:              if (m_status == 0 && m_waitingWriters.Count > 0)
〰47:              {
‼48:                  m_status = -1;
‼49:                  toWake = m_waitingWriters.Dequeue();
〰50:              }
‼51:          }
〰52:  
‼53:          toWake?.SetResult(new Releaser(this, true));
‼54:      }
〰55:  
〰56:  
〰57:      public Task<Releaser> WriterLockAsync()
〰58:      {
‼59:          lock (m_waitingWriters)
〰60:          {
‼61:              if (m_status == 0)
〰62:              {
‼63:                  m_status = -1;
‼64:                  return m_writerReleaser;
〰65:              }
〰66:              else
〰67:              {
‼68:                  var waiter = new TaskCompletionSource<Releaser>();
‼69:                  m_waitingWriters.Enqueue(waiter);
‼70:                  return waiter.Task;
〰71:              }
〰72:          }
‼73:      }
〰74:  
〰75:      private void WriterRelease()
〰76:      {
‼77:          TaskCompletionSource<Releaser>? toWake = null;
‼78:          bool toWakeIsWriter = false;
〰79:  
‼80:          lock (m_waitingWriters)
〰81:          {
‼82:              if (m_waitingWriters.Count > 0)
〰83:              {
‼84:                  toWake = m_waitingWriters.Dequeue();
‼85:                  toWakeIsWriter = true;
〰86:              }
‼87:              else if (m_readersWaiting > 0)
〰88:              {
‼89:                  toWake = m_waitingReader;
‼90:                  m_status = m_readersWaiting;
‼91:                  m_readersWaiting = 0;
‼92:                  m_waitingReader = new TaskCompletionSource<Releaser>();
〰93:              }
〰94:              else
‼95:                  m_status = 0;
‼96:          }
〰97:  
‼98:          toWake?.SetResult(new Releaser(this, toWakeIsWriter));
‼99:      }
〰100: 
〰101: 
〰102:     public readonly struct Releaser : IDisposable
〰103:     {
〰104:         private readonly AsyncReaderWriterLock m_toRelease;
〰105:         private readonly bool m_writer;
〰106: 
〰107:         internal Releaser(AsyncReaderWriterLock toRelease, bool writer)
〰108:         {
‼109:             m_toRelease = toRelease;
‼110:             m_writer = writer;
‼111:         }
〰112: 
〰113:         public void Dispose()
〰114:         {
‼115:             if (m_toRelease != null)
〰116:             {
‼117:                 if (m_writer)
‼118:                     m_toRelease.WriterRelease();
〰119:                 else
‼120:                     m_toRelease.ReaderRelease();
〰121:             }
‼122:         }
〰123:     }
〰124: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Threading/AsyncReaderWriterLock.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Threading;
〰6:   
〰7:   public class AsyncReaderWriterLock
〰8:   {
〰9:       // http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10267069.aspx
〰10:      private readonly Task<Releaser> m_readerReleaser;
〰11:      private readonly Task<Releaser> m_writerReleaser;
〰12:  
‼13:      private readonly Queue<TaskCompletionSource<Releaser>> m_waitingWriters = new();
‼14:      private TaskCompletionSource<Releaser> m_waitingReader = new();
〰15:      private int m_readersWaiting;
〰16:      private int m_status;
〰17:  
〰18:      public AsyncReaderWriterLock()
〰19:      {
‼20:          m_readerReleaser = Task.FromResult(new Releaser(this, false));
‼21:          m_writerReleaser = Task.FromResult(new Releaser(this, true));
‼22:      }
〰23:  
〰24:      public Task<Releaser> ReaderLockAsync()
〰25:      {
‼26:          lock (m_waitingWriters)
〰27:          {
‼28:              if (m_status >= 0 && m_waitingWriters.Count == 0)
〰29:              {
‼30:                  ++m_status;
‼31:                  return m_readerReleaser;
〰32:              }
〰33:              else
〰34:              {
‼35:                  ++m_readersWaiting;
‼36:                  return m_waitingReader.Task.ContinueWith(t => t.Result);
〰37:              }
〰38:          }
‼39:      }
〰40:      private void ReaderRelease()
〰41:      {
‼42:          TaskCompletionSource<Releaser>? toWake = null;
‼43:          lock (m_waitingWriters)
〰44:          {
‼45:              --m_status;
‼46:              if (m_status == 0 && m_waitingWriters.Count > 0)
〰47:              {
‼48:                  m_status = -1;
‼49:                  toWake = m_waitingWriters.Dequeue();
〰50:              }
‼51:          }
〰52:  
‼53:          toWake?.SetResult(new Releaser(this, true));
‼54:      }
〰55:  
〰56:  
〰57:      public Task<Releaser> WriterLockAsync()
〰58:      {
‼59:          lock (m_waitingWriters)
〰60:          {
‼61:              if (m_status == 0)
〰62:              {
‼63:                  m_status = -1;
‼64:                  return m_writerReleaser;
〰65:              }
〰66:              else
〰67:              {
‼68:                  var waiter = new TaskCompletionSource<Releaser>();
‼69:                  m_waitingWriters.Enqueue(waiter);
‼70:                  return waiter.Task;
〰71:              }
〰72:          }
‼73:      }
〰74:  
〰75:      private void WriterRelease()
〰76:      {
‼77:          TaskCompletionSource<Releaser>? toWake = null;
‼78:          bool toWakeIsWriter = false;
〰79:  
‼80:          lock (m_waitingWriters)
〰81:          {
‼82:              if (m_waitingWriters.Count > 0)
〰83:              {
‼84:                  toWake = m_waitingWriters.Dequeue();
‼85:                  toWakeIsWriter = true;
〰86:              }
‼87:              else if (m_readersWaiting > 0)
〰88:              {
‼89:                  toWake = m_waitingReader;
‼90:                  m_status = m_readersWaiting;
‼91:                  m_readersWaiting = 0;
‼92:                  m_waitingReader = new TaskCompletionSource<Releaser>();
〰93:              }
〰94:              else
‼95:                  m_status = 0;
‼96:          }
〰97:  
‼98:          toWake?.SetResult(new Releaser(this, toWakeIsWriter));
‼99:      }
〰100: 
〰101: 
〰102:     public readonly struct Releaser : IDisposable
〰103:     {
〰104:         private readonly AsyncReaderWriterLock m_toRelease;
〰105:         private readonly bool m_writer;
〰106: 
〰107:         internal Releaser(AsyncReaderWriterLock toRelease, bool writer)
〰108:         {
‼109:             m_toRelease = toRelease;
‼110:             m_writer = writer;
‼111:         }
〰112: 
〰113:         public void Dispose()
〰114:         {
‼115:             if (m_toRelease != null)
〰116:             {
‼117:                 if (m_writer)
‼118:                     m_toRelease.WriterRelease();
〰119:                 else
‼120:                     m_toRelease.ReaderRelease();
〰121:             }
‼122:         }
〰123:     }
〰124: }
〰125: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

