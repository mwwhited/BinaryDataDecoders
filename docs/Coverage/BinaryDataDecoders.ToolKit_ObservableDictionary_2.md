# BinaryDataDecoders.ToolKit.Collections.ObjectModel.ObservableDictionary`2

## Summary

| Key             | Value                                                                       |
| :-------------- | :-------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.ObjectModel.ObservableDictionary`2` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                                |
| Coveredlines    | `0`                                                                         |
| Uncoveredlines  | `71`                                                                        |
| Coverablelines  | `71`                                                                        |
| Totallines      | `190`                                                                       |
| Linecoverage    | `0`                                                                         |
| Coveredbranches | `0`                                                                         |
| Totalbranches   | `32`                                                                        |
| Branchcoverage  | `0`                                                                         |
| Coveredmethods  | `0`                                                                         |
| Totalmethods    | `31`                                                                        |
| Methodcoverage  | `0`                                                                         |

## Metrics

| Complexity | Lines | Branches | Name                                        |
| :--------- | :---- | :------- | :------------------------------------------ |
| 1          | 0     | 100      | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 1          | 0     | 100      | `Add`                                       |
| 1          | 0     | 100      | `ContainsKey`                               |
| 1          | 0     | 100      | `get_Keys`                                  |
| 1          | 0     | 100      | `TryGetValue`                               |
| 1          | 0     | 100      | `get_Values`                                |
| 1          | 0     | 100      | `Contains`                                  |
| 1          | 0     | 100      | `CopyTo`                                    |
| 1          | 0     | 100      | `get_Count`                                 |
| 1          | 0     | 100      | `get_IsReadOnly`                            |
| 1          | 0     | 100      | `Remove`                                    |
| 4          | 0     | 0        | `Remove`                                    |
| 1          | 0     | 100      | `get_Item`                                  |
| 1          | 0     | 100      | `set_Item`                                  |
| 1          | 0     | 100      | `Add`                                       |
| 2          | 0     | 0        | `Clear`                                     |
| 1          | 0     | 100      | `GetEnumerator`                             |
| 1          | 0     | 100      | `SystemCollectionsIEnumerableGetEnumerator` |
| 8          | 0     | 0        | `AddRange`                                  |
| 8          | 0     | 0        | `Insert`                                    |
| 1          | 0     | 100      | `OnPropertyChanged`                         |
| 2          | 0     | 0        | `OnPropertyChanged`                         |
| 2          | 0     | 0        | `OnCollectionChanged`                       |
| 2          | 0     | 0        | `OnCollectionChanged`                       |
| 2          | 0     | 0        | `OnCollectionChanged`                       |
| 2          | 0     | 0        | `OnCollectionChanged`                       |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Collections/ObjectModel/ObservableDictionary.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections;
〰3:   using System.Collections.Generic;
〰4:   using System.Collections.Specialized;
〰5:   using System.ComponentModel;
〰6:   using System.Linq;
〰7:   using System.Text;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Collections.ObjectModel
〰10:  {
〰11:      public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged
〰12:      {
‼13:          protected IDictionary<TKey, TValue> Dictionary { get; } = new Dictionary<TKey, TValue>();
〰14:  
〰15:          #region Constructors
〰16:  #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
〰17:          public ObservableDictionary()
〰18:          {
‼19:          }
〰20:          public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
〰21:          {
‼22:              Dictionary = new Dictionary<TKey, TValue>(dictionary);
‼23:          }
〰24:          public ObservableDictionary(IEqualityComparer<TKey> comparer)
〰25:          {
‼26:              Dictionary = new Dictionary<TKey, TValue>(comparer);
‼27:          }
〰28:          public ObservableDictionary(int capacity)
〰29:          {
‼30:              Dictionary = new Dictionary<TKey, TValue>(capacity);
‼31:          }
〰32:          public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
〰33:          {
‼34:              Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
‼35:          }
〰36:          public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
〰37:          {
‼38:              Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
‼39:          }
〰40:  
〰41:  #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
〰42:          #endregion
〰43:  
〰44:          #region IDictionary<TKey,TValue> Members
〰45:  
‼46:          public void Add(TKey key, TValue value) => Insert(key, value, true);
‼47:          public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);
‼48:          public ICollection<TKey> Keys => Dictionary.Keys;
‼49:          public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);
‼50:          public ICollection<TValue> Values => Dictionary.Values;
‼51:          public bool Contains(KeyValuePair<TKey, TValue> item) => Dictionary.Contains(item);
‼52:          public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => Dictionary.CopyTo(array, arrayIndex);
‼53:          public int Count => Dictionary.Count;
‼54:          public bool IsReadOnly => Dictionary.IsReadOnly;
‼55:          public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);
〰56:  
〰57:          public bool Remove(TKey key)
〰58:          {
‼59:              if (key == null) throw new ArgumentNullException("key");
〰60:  
〰61:              TValue value;
‼62:              Dictionary.TryGetValue(key, out value);
‼63:              var removed = Dictionary.Remove(key);
‼64:              if (removed)
〰65:                  //OnCollectionChanged(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value));
‼66:                  OnCollectionChanged();
〰67:  
‼68:              return removed;
〰69:          }
〰70:  
〰71:          public TValue this[TKey key]
〰72:          {
‼73:              get => Dictionary[key];
‼74:              set => Insert(key, value, false);
〰75:          }
〰76:  
〰77:          #endregion
〰78:  
〰79:          #region ICollection<KeyValuePair<TKey,TValue>> Members
〰80:  
‼81:          public void Add(KeyValuePair<TKey, TValue> item) => Insert(item.Key, item.Value, true);
〰82:  
〰83:          public void Clear()
〰84:          {
‼85:              if (Dictionary.Count > 0)
〰86:              {
‼87:                  Dictionary.Clear();
‼88:                  OnCollectionChanged();
〰89:              }
‼90:          }
〰91:  
〰92:          #endregion
〰93:  
〰94:          #region IEnumerable<KeyValuePair<TKey,TValue>> Members
〰95:  
‼96:          public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();
〰97:  
〰98:          #endregion
〰99:  
〰100:         #region IEnumerable Members
〰101: 
‼102:         IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Dictionary).GetEnumerator();
〰103: 
〰104:         #endregion
〰105: 
〰106:         #region INotifyCollectionChanged Members
〰107: 
〰108:         public event NotifyCollectionChangedEventHandler CollectionChanged;
〰109: 
〰110:         #endregion
〰111: 
〰112:         #region INotifyPropertyChanged Members
〰113: 
〰114:         public event PropertyChangedEventHandler PropertyChanged;
〰115: 
〰116:         #endregion
〰117: 
〰118:         public void AddRange(IDictionary<TKey, TValue> items)
〰119:         {
‼120:             if (items == null) throw new ArgumentNullException("items");
〰121: 
‼122:             if (items.Count > 0)
〰123:             {
‼124:                 if (items.Keys.Any((k) => Dictionary.ContainsKey(k)))
‼125:                     throw new ArgumentException("An item with the same key has already been added.");
〰126:                 else
‼127:                     foreach (var item in items) Dictionary.Add(item);
〰128: 
〰129: 
‼130:                 OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray());
〰131:             }
‼132:         }
〰133: 
〰134:         private void Insert(TKey key, TValue value, bool add)
〰135:         {
‼136:             if (key == null) throw new ArgumentNullException("key");
〰137: 
〰138:             TValue item;
‼139:             if (Dictionary.TryGetValue(key, out item))
〰140:             {
‼141:                 if (add) throw new ArgumentException("An item with the same key has already been added.");
‼142:                 if (Equals(item, value)) return;
‼143:                 Dictionary[key] = value;
〰144: 
‼145:                 OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));
〰146:             }
〰147:             else
〰148:             {
‼149:                 Dictionary[key] = value;
〰150: 
‼151:                 OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
〰152:             }
‼153:         }
〰154: 
〰155:         private const string IndexerName = "Item[]";
〰156: 
〰157:         private void OnPropertyChanged()
〰158:         {
‼159:             OnPropertyChanged(nameof(this.Count));
‼160:             OnPropertyChanged(IndexerName);
‼161:             OnPropertyChanged(nameof(this.Keys));
‼162:             OnPropertyChanged(nameof(this.Values));
‼163:         }
〰164: 
‼165:         protected virtual void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
〰166:         private void OnCollectionChanged()
〰167:         {
‼168:             OnPropertyChanged();
‼169:             this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
‼170:         }
〰171: 
〰172:         private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
〰173:         {
‼174:             OnPropertyChanged();
‼175:             this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem));
‼176:         }
〰177: 
〰178:         private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
〰179:         {
‼180:             OnPropertyChanged();
‼181:             this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
‼182:         }
〰183: 
〰184:         private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
〰185:         {
‼186:             OnPropertyChanged();
‼187:             this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems));
‼188:         }
〰189:     }
〰190: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

