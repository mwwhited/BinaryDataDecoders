# BinaryDataDecoders.ToolKit.Threading.AsyncAutoResetEvent

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.AsyncAutoResetEvent` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `38`                                                       |
| Coverablelines  | `38`                                                       |
| Totallines      | `83`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `16`                                                       |
| Branchcoverage  | `0`                                                        |
| Coveredmethods  | `0`                                                        |
| Totalmethods    | `8`                                                        |
| Methodcoverage  | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `cctor`     |
| 1          | 0     | 100      | `ctor`      |
| 2          | 0     | 0        | `WaitAsync` |
| 6          | 0     | 0        | `Set`       |
| 1          | 0     | 100      | `cctor`     |
| 1          | 0     | 100      | `ctor`      |
| 2          | 0     | 0        | `WaitAsync` |
| 6          | 0     | 0        | `Set`       |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Threading/AsyncAutoResetEvent.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Threading.Tasks;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Threading;
〰5:   
〰6:   public class AsyncAutoResetEvent
〰7:   {
〰8:       //http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266923.aspx
‼9:       private readonly static Task s_completed = Task.FromResult(true);
‼10:      private readonly Queue<TaskCompletionSource<bool>> m_waits = new();
〰11:      private bool m_signaled;
〰12:      public Task WaitAsync()
〰13:      {
‼14:          lock (m_waits)
〰15:          {
‼16:              if (m_signaled)
〰17:              {
‼18:                  m_signaled = false;
‼19:                  return s_completed;
〰20:              }
〰21:              else
〰22:              {
‼23:                  var tcs = new TaskCompletionSource<bool>();
‼24:                  m_waits.Enqueue(tcs);
‼25:                  return tcs.Task;
〰26:              }
〰27:          }
‼28:      }
〰29:      public void Set()
〰30:      {
‼31:          TaskCompletionSource<bool>? toRelease = null;
‼32:          lock (m_waits)
〰33:          {
‼34:              if (m_waits.Count > 0)
‼35:                  toRelease = m_waits.Dequeue();
‼36:              else if (!m_signaled)
‼37:                  m_signaled = true;
‼38:          }
‼39:          toRelease?.SetResult(true);
‼40:      }
〰41:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Threading/AsyncAutoResetEvent.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Threading.Tasks;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Threading;
〰5:   
〰6:   public class AsyncAutoResetEvent
〰7:   {
〰8:       //http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266923.aspx
‼9:       private readonly static Task s_completed = Task.FromResult(true);
‼10:      private readonly Queue<TaskCompletionSource<bool>> m_waits = new();
〰11:      private bool m_signaled;
〰12:      public Task WaitAsync()
〰13:      {
‼14:          lock (m_waits)
〰15:          {
‼16:              if (m_signaled)
〰17:              {
‼18:                  m_signaled = false;
‼19:                  return s_completed;
〰20:              }
〰21:              else
〰22:              {
‼23:                  var tcs = new TaskCompletionSource<bool>();
‼24:                  m_waits.Enqueue(tcs);
‼25:                  return tcs.Task;
〰26:              }
〰27:          }
‼28:      }
〰29:      public void Set()
〰30:      {
‼31:          TaskCompletionSource<bool>? toRelease = null;
‼32:          lock (m_waits)
〰33:          {
‼34:              if (m_waits.Count > 0)
‼35:                  toRelease = m_waits.Dequeue();
‼36:              else if (!m_signaled)
‼37:                  m_signaled = true;
‼38:          }
‼39:          toRelease?.SetResult(true);
‼40:      }
〰41:  }
〰42:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

