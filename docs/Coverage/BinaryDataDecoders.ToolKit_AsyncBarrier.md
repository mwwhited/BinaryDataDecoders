# BinaryDataDecoders.ToolKit.Threading.AsyncBarrier

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.AsyncBarrier` |
| Assembly        | `BinaryDataDecoders.ToolKit`                        |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `12`                                                |
| Coverablelines  | `12`                                                |
| Totallines      | `36`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `4`                                                 |
| Branchcoverage  | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `2`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 2          | 0     | 0        | `ctor`          |
| 2          | 0     | 0        | `SignalAndWait` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Threading/AsyncBarrier.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Concurrent;
〰3:   using System.Threading;
〰4:   using System.Threading.Tasks;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Threading
〰7:   {
〰8:       public class AsyncBarrier
〰9:       {
〰10:      //http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266932.aspx
〰11:          private readonly int m_participantCount;
〰12:          private int m_remainingParticipants;
〰13:          private ConcurrentStack<TaskCompletionSource<bool>> m_waiters;
〰14:  
〰15:          public AsyncBarrier(int participantCount)
〰16:          {
‼17:              if (participantCount <= 0) throw new ArgumentOutOfRangeException("participantCount");
‼18:              m_remainingParticipants = m_participantCount = participantCount;
‼19:              m_waiters = new ConcurrentStack<TaskCompletionSource<bool>>();
‼20:          }
〰21:  
〰22:          public Task SignalAndWait()
〰23:          {
‼24:              var tcs = new TaskCompletionSource<bool>();
‼25:              m_waiters.Push(tcs);
‼26:              if (Interlocked.Decrement(ref m_remainingParticipants) == 0)
〰27:              {
‼28:                  m_remainingParticipants = m_participantCount;
‼29:                  var waiters = m_waiters;
‼30:                  m_waiters = new ConcurrentStack<TaskCompletionSource<bool>>();
‼31:                  Parallel.ForEach(waiters, w => w.SetResult(true));
〰32:              }
‼33:              return tcs.Task;
〰34:          }
〰35:      }
〰36:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

