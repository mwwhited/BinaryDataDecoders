# BinaryDataDecoders.ToolKit.Threading.AsyncCountdownEvent

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.AsyncCountdownEvent` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `30`                                                       |
| Coverablelines  | `30`                                                       |
| Totallines      | `77`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `12`                                                       |
| Branchcoverage  | `0`                                                        |
| Coveredmethods  | `0`                                                        |
| Totalmethods    | `8`                                                        |
| Methodcoverage  | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 0     | 100      | `ctor`          |
| 1          | 0     | 100      | `WaitAsync`     |
| 6          | 0     | 0        | `Signal`        |
| 1          | 0     | 100      | `SignalAndWait` |
| 1          | 0     | 100      | `ctor`          |
| 1          | 0     | 100      | `WaitAsync`     |
| 6          | 0     | 0        | `Signal`        |
| 1          | 0     | 100      | `SignalAndWait` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Threading/AsyncCountdownEvent.cs

```CSharp
〰1:   using System;
〰2:   using System.Threading;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Threading;
〰6:   
〰7:   public class AsyncCountdownEvent
〰8:   {
〰9:       // http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266930.aspx
‼10:      private readonly AsyncManualResetEvent m_amre = new();
〰11:      private int m_count;
〰12:  
〰13:      public AsyncCountdownEvent(int initialCount)
〰14:      {
‼15:          ArgumentOutOfRangeException.ThrowIfNegativeOrZero(initialCount, nameof(initialCount));
‼16:          m_count = initialCount;
‼17:      }
〰18:  
‼19:      public Task WaitAsync() { return m_amre.WaitAsync(); }
〰20:  
〰21:      public void Signal()
〰22:      {
‼23:          if (m_count <= 0)
‼24:              throw new InvalidOperationException();
〰25:  
‼26:          int newCount = Interlocked.Decrement(ref m_count);
‼27:          if (newCount == 0)
‼28:              m_amre.Set();
‼29:          else if (newCount < 0)
‼30:              throw new InvalidOperationException();
‼31:      }
〰32:  
〰33:      public Task SignalAndWait()
〰34:      {
‼35:          Signal();
‼36:          return WaitAsync();
〰37:      }
〰38:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Threading/AsyncCountdownEvent.cs

```CSharp
〰1:   using System;
〰2:   using System.Threading;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Threading;
〰6:   
〰7:   public class AsyncCountdownEvent
〰8:   {
〰9:       // http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266930.aspx
‼10:      private readonly AsyncManualResetEvent m_amre = new();
〰11:      private int m_count;
〰12:  
〰13:      public AsyncCountdownEvent(int initialCount)
〰14:      {
‼15:          ArgumentOutOfRangeException.ThrowIfNegativeOrZero(initialCount, nameof(initialCount));
‼16:          m_count = initialCount;
‼17:      }
〰18:  
‼19:      public Task WaitAsync() { return m_amre.WaitAsync(); }
〰20:  
〰21:      public void Signal()
〰22:      {
‼23:          if (m_count <= 0)
‼24:              throw new InvalidOperationException();
〰25:  
‼26:          int newCount = Interlocked.Decrement(ref m_count);
‼27:          if (newCount == 0)
‼28:              m_amre.Set();
‼29:          else if (newCount < 0)
‼30:              throw new InvalidOperationException();
‼31:      }
〰32:  
〰33:      public Task SignalAndWait()
〰34:      {
‼35:          Signal();
‼36:          return WaitAsync();
〰37:      }
〰38:  }
〰39:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

