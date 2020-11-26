# BinaryDataDecoders.ToolKit.Threading.AsyncManualResetEvent

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.AsyncManualResetEvent` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                 |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `11`                                                         |
| Coverablelines  | `11`                                                         |
| Totallines      | `31`                                                         |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `4`                                                          |
| Branchcoverage  | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `ctor`      |
| 1          | 0     | 100      | `WaitAsync` |
| 1          | 0     | 100      | `Set`       |
| 4          | 0     | 0        | `Reset`     |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Threading/AsyncManualResetEvent.cs

```CSharp
〰1:   using System.Threading;
〰2:   using System.Threading.Tasks;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Threading
〰5:   {
〰6:       public class AsyncManualResetEvent
〰7:       {
〰8:           // http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266920.aspx
‼9:           private volatile TaskCompletionSource<bool> m_tcs = new TaskCompletionSource<bool>();
‼10:          public Task WaitAsync() { return m_tcs.Task; }
〰11:  
〰12:          public void Set()
〰13:          {
‼14:              var tcs = m_tcs;
‼15:              Task.Factory.StartNew(s => ((TaskCompletionSource<bool>)s).TrySetResult(true),
‼16:                  tcs, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
‼17:              tcs.Task.Wait();
‼18:          }
〰19:  
〰20:          public void Reset()
〰21:          {
〰22:              while (true)
〰23:              {
‼24:                  var tcs = m_tcs;
‼25:                  if (!tcs.Task.IsCompleted ||
‼26:                      Interlocked.CompareExchange(ref m_tcs, new TaskCompletionSource<bool>(), tcs) == tcs)
‼27:                      return;
〰28:              }
〰29:          }
〰30:      }
〰31:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

