﻿# BinaryDataDecoders.ToolKit.Threading.AsyncLock

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.AsyncLock` |
| Assembly        | `BinaryDataDecoders.ToolKit`                     |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `14`                                             |
| Coverablelines  | `14`                                             |
| Totallines      | `42`                                             |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `4`                                              |
| Branchcoverage  | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `ctor`      |
| 2          | 0     | 0        | `LockAsync` |
| 1          | 0     | 100      | `ctor`      |
| 2          | 0     | 0        | `Dispose`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Threading/AsyncLock.cs

```CSharp
〰1:   using System;
〰2:   using System.Threading;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Threading
〰6:   {
〰7:       public class AsyncLock
〰8:       {
〰9:           // http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10266988.aspx
〰10:          private readonly AsyncSemaphore m_semaphore;
〰11:          private readonly Task<Releaser> m_releaser;
〰12:  
‼13:          public AsyncLock()
〰14:          {
‼15:              m_semaphore = new AsyncSemaphore(1);
‼16:              m_releaser = Task.FromResult(new Releaser(this));
‼17:          }
〰18:  
〰19:          public Task<Releaser> LockAsync()
〰20:          {
‼21:              var wait = m_semaphore.WaitAsync();
‼22:              return wait.IsCompleted ?
‼23:                  m_releaser :
‼24:                  wait.ContinueWith((_, state) => new Releaser((AsyncLock)state),
‼25:                      this, CancellationToken.None,
‼26:                      TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
〰27:          }
〰28:  
〰29:          public struct Releaser : IDisposable
〰30:          {
〰31:              private readonly AsyncLock m_toRelease;
〰32:  
‼33:              internal Releaser(AsyncLock toRelease) { m_toRelease = toRelease; }
〰34:  
〰35:              public void Dispose()
〰36:              {
‼37:                  if (m_toRelease != null)
‼38:                      m_toRelease.m_semaphore.Release();
‼39:              }
〰40:          }
〰41:      }
〰42:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

