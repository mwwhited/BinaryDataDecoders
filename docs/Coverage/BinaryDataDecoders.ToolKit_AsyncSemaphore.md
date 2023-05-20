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
‼16:              if (initialCount < 0)
‼17:                  throw new ArgumentOutOfRangeException("initialCount");
‼18:              m_currentCount = initialCount;
‼19:          }
〰20:  
〰21:          public Task WaitAsync()
〰22:          {
‼23:              lock (m_waiters)
〰24:              {
‼25:                  if (m_currentCount > 0)
〰26:                  {
‼27:                      --m_currentCount;
‼28:                      return s_completed;
〰29:                  }
〰30:                  else
〰31:                  {
‼32:                      var waiter = new TaskCompletionSource<bool>();
‼33:                      m_waiters.Enqueue(waiter);
‼34:                      return waiter.Task;
〰35:                  }
〰36:              }
‼37:          }
〰38:  
〰39:          public void Release()
〰40:          {
‼41:              TaskCompletionSource<bool>? toRelease = default;
‼42:              lock (m_waiters)
〰43:              {
‼44:                  if (m_waiters.Count > 0)
‼45:                      toRelease = m_waiters.Dequeue();
〰46:                  else
‼47:                      ++m_currentCount;
‼48:              }
‼49:              toRelease?.SetResult(true);
‼50:          }
〰51:      }
〰52:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

