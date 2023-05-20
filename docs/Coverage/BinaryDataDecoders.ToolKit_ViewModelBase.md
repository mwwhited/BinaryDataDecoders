# BinaryDataDecoders.ToolKit.ComponentModel.ViewModelBase

## Summary

| Key             | Value                                                     |
| :-------------- | :-------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.ComponentModel.ViewModelBase` |
| Assembly        | `BinaryDataDecoders.ToolKit`                              |
| Coveredlines    | `0`                                                       |
| Uncoveredlines  | `10`                                                      |
| Coverablelines  | `10`                                                      |
| Totallines      | `38`                                                      |
| Linecoverage    | `0`                                                       |
| Coveredbranches | `0`                                                       |
| Totalbranches   | `4`                                                       |
| Branchcoverage  | `0`                                                       |
| Coveredmethods  | `0`                                                       |
| Totalmethods    | `3`                                                       |
| Methodcoverage  | `0`                                                       |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `ctor`              |
| 2          | 0     | 0        | `DispatchWork`      |
| 2          | 0     | 0        | `OnPropertyChanged` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/ComponentModel/ViewModelBase.cs

```CSharp
〰1:   using System;
〰2:   using System.ComponentModel;
〰3:   using System.Runtime.CompilerServices;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.ComponentModel
〰6:   {
〰7:       public abstract class ViewModelBase : INotifyPropertyChanged
〰8:       {
〰9:           /*
〰10:          * WeakEventManager
〰11:  	        * http://www.codeproject.com/Articles/786606/WeakEventManager-for-WinRT
〰12:  	        * http://reedcopsey.com/2009/08/06/preventing-event-based-memory-leaks-weakeventmanager/
〰13:  	        * https://msdn.microsoft.com/en-us/library/system.windows.weakeventmanager.aspx
〰14:  	        * http://www.jonathanantoine.com/2011/09/19/wpf-4-5-part-2-improved-weakeventmanager/
〰15:  	    */
〰16:          protected ViewModelBase(Action<Action> dispatched)
〰17:          {
〰18:              this.Dispatched = dispatched;
‼19:          }
〰20:          public Action<Action> Dispatched { get; }
〰21:          public void DispatchWork(Action work)
〰22:          {
‼23:              if (this.Dispatched == null)
‼24:                  work();
〰25:              else
‼26:                  this.Dispatched(work);
‼27:          }
〰28:  
〰29:          public event PropertyChangedEventHandler PropertyChanged;
〰30:          protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
〰31:          {
‼32:              this.DispatchWork(() =>
‼33:              {
‼34:                  this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
‼35:              });
‼36:          }
〰37:      }
〰38:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

