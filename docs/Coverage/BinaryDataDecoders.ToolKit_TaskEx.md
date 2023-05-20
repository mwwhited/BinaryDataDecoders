# BinaryDataDecoders.ToolKit.Threading.Tasks.TaskEx

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Threading.Tasks.TaskEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                        |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `69`                                                |
| Coverablelines  | `69`                                                |
| Totallines      | `136`                                               |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `8`                                                 |
| Branchcoverage  | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `8`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `RunSync`          |
| 1          | 0     | 100      | `RunSync`          |
| 1          | 0     | 100      | `ctor`             |
| 1          | 0     | 100      | `Send`             |
| 1          | 0     | 100      | `Post`             |
| 1          | 0     | 100      | `EndMessageLoop`   |
| 8          | 0     | 0        | `BeginMessageLoop` |
| 1          | 0     | 100      | `CreateCopy`       |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Threading/Tasks/TaskEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Threading;
〰4:   using System.Threading.Tasks;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Threading.Tasks
〰7:   {
〰8:       public static class TaskEx
〰9:       {
〰10:          // http://stackoverflow.com/questions/5095183/how-would-i-run-an-async-taskt-method-synchronously
〰11:          // http://stackoverflow.com/a/5097066/89586
〰12:  
〰13:          /// <summary>
〰14:          /// Execute's an async Task<T> method which has a void return value synchronously
〰15:          /// </summary>
〰16:          /// <param name="task">Task<T> method to execute</param>
〰17:          public static void RunSync(this Func<Task> task)
〰18:          {
‼19:              var oldContext = SynchronizationContext.Current;
‼20:              var synch = new ExclusiveSynchronizationContext();
‼21:              SynchronizationContext.SetSynchronizationContext(synch);
‼22:              synch.Post(async _ =>
‼23:              {
‼24:                  try
‼25:                  {
‼26:                      await task();
‼27:                  }
‼28:                  catch (Exception e)
‼29:                  {
‼30:                      synch.InnerException = e;
‼31:                      throw;
‼32:                  }
‼33:                  finally
‼34:                  {
‼35:                      synch.EndMessageLoop();
‼36:                  }
‼37:              }, null);
‼38:              synch.BeginMessageLoop();
〰39:  
‼40:              SynchronizationContext.SetSynchronizationContext(oldContext);
‼41:          }
〰42:  
〰43:          /// <summary>
〰44:          /// Execute's an async Task<T> method which has a T return type synchronously
〰45:          /// </summary>
〰46:          /// <typeparam name="T">Return Type</typeparam>
〰47:          /// <param name="task">Task<T> method to execute</param>
〰48:          /// <returns></returns>
〰49:          public static T RunSync<T>(this Func<Task<T>> task)
〰50:          {
‼51:              var oldContext = SynchronizationContext.Current;
‼52:              var synch = new ExclusiveSynchronizationContext();
‼53:              SynchronizationContext.SetSynchronizationContext(synch);
‼54:              T ret = default(T);
‼55:              synch.Post(async _ =>
‼56:              {
‼57:                  try
‼58:                  {
‼59:                      ret = await task();
‼60:                  }
‼61:                  catch (Exception e)
‼62:                  {
‼63:                      synch.InnerException = e;
‼64:                      throw;
‼65:                  }
‼66:                  finally
‼67:                  {
‼68:                      synch.EndMessageLoop();
‼69:                  }
‼70:              }, null);
‼71:              synch.BeginMessageLoop();
‼72:              SynchronizationContext.SetSynchronizationContext(oldContext);
‼73:              return ret;
〰74:          }
〰75:  
〰76:          private class ExclusiveSynchronizationContext : SynchronizationContext
〰77:          {
〰78:              private bool done;
〰79:              public Exception InnerException { get; set; }
‼80:              readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);
‼81:              readonly Queue<Tuple<SendOrPostCallback, object>> items =
‼82:                  new Queue<Tuple<SendOrPostCallback, object>>();
〰83:  
〰84:              public override void Send(SendOrPostCallback d, object state)
〰85:              {
‼86:                  throw new NotSupportedException("We cannot send to our same thread");
〰87:              }
〰88:  
〰89:              public override void Post(SendOrPostCallback d, object state)
〰90:              {
‼91:                  lock (items)
〰92:                  {
‼93:                      items.Enqueue(Tuple.Create(d, state));
‼94:                  }
‼95:                  workItemsWaiting.Set();
‼96:              }
〰97:  
〰98:              public void EndMessageLoop()
〰99:              {
‼100:                 Post(_ => done = true, null);
‼101:             }
〰102: 
〰103:             public void BeginMessageLoop()
〰104:             {
‼105:                 while (!done)
〰106:                 {
‼107:                     Tuple<SendOrPostCallback, object> task = null;
‼108:                     lock (items)
〰109:                     {
‼110:                         if (items.Count > 0)
〰111:                         {
‼112:                             task = items.Dequeue();
〰113:                         }
‼114:                     }
‼115:                     if (task != null)
〰116:                     {
‼117:                         task.Item1(task.Item2);
‼118:                         if (InnerException != null) // the method threw an exception
〰119:                         {
‼120:                             throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
〰121:                         }
〰122:                     }
〰123:                     else
〰124:                     {
‼125:                         workItemsWaiting.WaitOne();
〰126:                     }
〰127:                 }
‼128:             }
〰129: 
〰130:             public override SynchronizationContext CreateCopy()
〰131:             {
‼132:                 return this;
〰133:             }
〰134:         }
〰135:     }
〰136: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

