# BinaryDataDecoders.ToolKit.Threading.AsyncSemaphore

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.AsyncSemaphore` |
| Assembly        | `BinaryDataDecoders.ToolKit`                          |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `22`                                                  |
| Coverablelines  | `22`                                                  |
| Totallines      | `52`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `8`                                                   |
| Branchcoverage  | `0`                                                   |
| Coveredmethods  | `0`                                                   |
| Totalmethods    | `4`                                                   |
| Methodcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `cctor`     |
| 2          | 0     | 0        | `ctor`      |
| 2          | 0     | 0        | `WaitAsync` |
| 4          | 0     | 0        | `Release`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Threading/AsyncSemaphore.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Threading
〰6:   {
〰7:       public class AsyncSemaphore
〰8:       {
〰9:           // http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10266983.aspx
‼10:          private readonly static Task s_completed = Task.FromResult(true);
‼11:          private readonly Queue<TaskCompletionSource<bool>> m_waiters = new Queue<TaskCompletionSource<bool>>();
〰12:          private int m_currentCount;
〰13:  
〰14:          public AsyncSemaphore(int initialCount)
〰15:          {
‼16:              if (initialCount < 0) throw new ArgumentOutOfRangeException("initialCount");
‼17:              m_currentCount = initialCount;
‼18:          }
〰19:  
〰20:          public Task WaitAsync()
〰21:          {
‼22:              lock (m_waiters)
〰23:              {
‼24:                  if (m_currentCount > 0)
〰25:                  {
‼26:                      --m_currentCount;
‼27:                      return s_completed;
〰28:                  }
〰29:                  else
〰30:                  {
‼31:                      var waiter = new TaskCompletionSource<bool>();
‼32:                      m_waiters.Enqueue(waiter);
‼33:                      return waiter.Task;
〰34:                  }
〰35:              }
‼36:          }
〰37:  
〰38:          public void Release()
〰39:          {
‼40:              TaskCompletionSource<bool> toRelease = default;
‼41:              lock (m_waiters)
〰42:              {
‼43:                  if (m_waiters.Count > 0)
‼44:                      toRelease = m_waiters.Dequeue();
〰45:                  else
‼46:                      ++m_currentCount;
‼47:              }
‼48:              if (toRelease != null)
‼49:                  toRelease.SetResult(true);
‼50:          }
〰51:      }
〰52:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

