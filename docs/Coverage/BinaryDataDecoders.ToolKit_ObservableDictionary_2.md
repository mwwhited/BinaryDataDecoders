# BinaryDataDecoders.ToolKit.Collections.ObjectModel.ObservableDictionary`2

## Summary

| Key             | Value                                                                       |
| :-------------- | :-------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.ObjectModel.ObservableDictionary`2` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                                |
| Coveredlines    | `0`                                                                         |
| Uncoveredlines  | `142`                                                                       |
| Coverablelines  | `142`                                                                       |
| Totallines      | `375`                                                                       |
| Linecoverage    | `0`                                                                         |
| Coveredbranches | `0`                                                                         |
| Totalbranches   | `60`                                                                        |
| Branchcoverage  | `0`                                                                         |
| Coveredmethods  | `0`                                                                         |
| Totalmethods    | `62`                                                                        |
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
| 6          | 0     | 0        | `AddRange`                                  |
| 8          | 0     | 0        | `Insert`                                    |
| 1          | 0     | 100      | `OnPropertyChanged`                         |
| 2          | 0     | 0        | `OnPropertyChanged`                         |
| 2          | 0     | 0        | `OnCollectionChanged`                       |
| 2          | 0     | 0        | `OnCollectionChanged`                       |
| 2          | 0     | 0        | `OnCollectionChanged`                       |
| 2          | 0     | 0        | `OnCollectionChanged`                       |
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
| 6          | 0     | 0        | `AddRange`                                  |
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
〰9:   namespace BinaryDataDecoders.ToolKit.Collections.ObjectModel;
〰10:  
〰11:  public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged
〰12:  {
‼13:      protected IDictionary<TKey, TValue> Dictionary { get; } = new Dictionary<TKey, TValue>();
〰14:  
〰15:      #region Constructors
〰16:      public ObservableDictionary()
〰17:      {
‼18:      }
〰19:      public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
〰20:      {
‼21:          Dictionary = new Dictionary<TKey, TValue>(dictionary);
‼22:      }
〰23:      public ObservableDictionary(IEqualityComparer<TKey> comparer)
〰24:      {
‼25:          Dictionary = new Dictionary<TKey, TValue>(comparer);
‼26:      }
〰27:      public ObservableDictionary(int capacity)
〰28:      {
‼29:          Dictionary = new Dictionary<TKey, TValue>(capacity);
‼30:      }
〰31:      public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
〰32:      {
‼33:          Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
‼34:      }
〰35:      public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
〰36:      {
‼37:          Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
‼38:      }
〰39:  
〰40:      #endregion
〰41:  
〰42:      #region IDictionary<TKey,TValue> Members
〰43:  
‼44:      public void Add(TKey key, TValue value) => Insert(key, value, true);
‼45:      public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);
‼46:      public ICollection<TKey> Keys => Dictionary.Keys;
‼47:      public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);
‼48:      public ICollection<TValue> Values => Dictionary.Values;
‼49:      public bool Contains(KeyValuePair<TKey, TValue> item) => Dictionary.Contains(item);
‼50:      public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => Dictionary.CopyTo(array, arrayIndex);
‼51:      public int Count => Dictionary.Count;
‼52:      public bool IsReadOnly => Dictionary.IsReadOnly;
‼53:      public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);
〰54:  
〰55:      public bool Remove(TKey key)
〰56:      {
‼57:          if (key == null) throw new ArgumentNullException(nameof(key));
〰58:  
〰59:          TValue value;
‼60:          Dictionary.TryGetValue(key, out value);
‼61:          var removed = Dictionary.Remove(key);
‼62:          if (removed)
〰63:              //OnCollectionChanged(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value));
‼64:              OnCollectionChanged();
〰65:  
‼66:          return removed;
〰67:      }
〰68:  
〰69:      public TValue this[TKey key]
〰70:      {
‼71:          get => Dictionary[key];
‼72:          set => Insert(key, value, false);
〰73:      }
〰74:  
〰75:      #endregion
〰76:  
〰77:      #region ICollection<KeyValuePair<TKey,TValue>> Members
〰78:  
‼79:      public void Add(KeyValuePair<TKey, TValue> item) => Insert(item.Key, item.Value, true);
〰80:  
〰81:      public void Clear()
〰82:      {
‼83:          if (Dictionary.Count > 0)
〰84:          {
‼85:              Dictionary.Clear();
‼86:              OnCollectionChanged();
〰87:          }
‼88:      }
〰89:  
〰90:      #endregion
〰91:  
〰92:      #region IEnumerable<KeyValuePair<TKey,TValue>> Members
〰93:  
‼94:      public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();
〰95:  
〰96:      #endregion
〰97:  
〰98:      #region IEnumerable Members
〰99:  
‼100:     IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Dictionary).GetEnumerator();
〰101: 
〰102:     #endregion
〰103: 
〰104:     #region INotifyCollectionChanged Members
〰105: 
〰106:     public event NotifyCollectionChangedEventHandler? CollectionChanged;
〰107: 
〰108:     #endregion
〰109: 
〰110:     #region INotifyPropertyChanged Members
〰111: 
〰112:     public event PropertyChangedEventHandler? PropertyChanged;
〰113: 
〰114:     #endregion
〰115: 
〰116:     public void AddRange(IDictionary<TKey, TValue> items)
〰117:     {
‼118:         ArgumentNullException.ThrowIfNull(items, nameof(items));
〰119: 
‼120:         if (items.Count > 0)
〰121:         {
‼122:             if (items.Keys.Any((k) => Dictionary.ContainsKey(k)))
‼123:                 throw new ArgumentException("An item with the same key has already been added.");
〰124:             else
‼125:                 foreach (var item in items) Dictionary.Add(item);
〰126: 
〰127: 
‼128:             OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray());
〰129:         }
‼130:     }
〰131: 
〰132:     private void Insert(TKey key, TValue value, bool add)
〰133:     {
‼134:         if (key == null) throw new ArgumentNullException(nameof(key));
〰135: 
〰136:         TValue item;
‼137:         if (Dictionary.TryGetValue(key, out item))
〰138:         {
‼139:             if (add) throw new ArgumentException("An item with the same key has already been added.");
‼140:             if (Equals(item, value)) return;
‼141:             Dictionary[key] = value;
〰142: 
‼143:             OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));
〰144:         }
〰145:         else
〰146:         {
‼147:             Dictionary[key] = value;
〰148: 
‼149:             OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
〰150:         }
‼151:     }
〰152: 
〰153:     private const string IndexerName = "Item[]";
〰154: 
〰155:     private void OnPropertyChanged()
〰156:     {
‼157:         OnPropertyChanged(nameof(this.Count));
‼158:         OnPropertyChanged(IndexerName);
‼159:         OnPropertyChanged(nameof(this.Keys));
‼160:         OnPropertyChanged(nameof(this.Values));
‼161:     }
〰162: 
‼163:     protected virtual void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
〰164:     private void OnCollectionChanged()
〰165:     {
‼166:         OnPropertyChanged();
‼167:         this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
‼168:     }
〰169: 
〰170:     private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
〰171:     {
‼172:         OnPropertyChanged();
‼173:         this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem));
‼174:     }
〰175: 
〰176:     private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
〰177:     {
‼178:         OnPropertyChanged();
‼179:         this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
‼180:     }
〰181: 
〰182:     private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
〰183:     {
‼184:         OnPropertyChanged();
‼185:         this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems));
‼186:     }
〰187: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Collections/ObjectModel/ObservableDictionary.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections;
〰3:   using System.Collections.Generic;
〰4:   using System.Collections.Specialized;
〰5:   using System.ComponentModel;
〰6:   using System.Linq;
〰7:   using System.Text;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Collections.ObjectModel;
〰10:  
〰11:  public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged
〰12:  {
‼13:      protected IDictionary<TKey, TValue> Dictionary { get; } = new Dictionary<TKey, TValue>();
〰14:  
〰15:      #region Constructors
〰16:      public ObservableDictionary()
〰17:      {
‼18:      }
〰19:      public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
〰20:      {
‼21:          Dictionary = new Dictionary<TKey, TValue>(dictionary);
‼22:      }
〰23:      public ObservableDictionary(IEqualityComparer<TKey> comparer)
〰24:      {
‼25:          Dictionary = new Dictionary<TKey, TValue>(comparer);
‼26:      }
〰27:      public ObservableDictionary(int capacity)
〰28:      {
‼29:          Dictionary = new Dictionary<TKey, TValue>(capacity);
‼30:      }
〰31:      public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
〰32:      {
‼33:          Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
‼34:      }
〰35:      public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
〰36:      {
‼37:          Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
‼38:      }
〰39:  
〰40:      #endregion
〰41:  
〰42:      #region IDictionary<TKey,TValue> Members
〰43:  
‼44:      public void Add(TKey key, TValue value) => Insert(key, value, true);
‼45:      public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);
‼46:      public ICollection<TKey> Keys => Dictionary.Keys;
‼47:      public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);
‼48:      public ICollection<TValue> Values => Dictionary.Values;
‼49:      public bool Contains(KeyValuePair<TKey, TValue> item) => Dictionary.Contains(item);
‼50:      public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => Dictionary.CopyTo(array, arrayIndex);
‼51:      public int Count => Dictionary.Count;
‼52:      public bool IsReadOnly => Dictionary.IsReadOnly;
‼53:      public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);
〰54:  
〰55:      public bool Remove(TKey key)
〰56:      {
‼57:          if (key == null) throw new ArgumentNullException(nameof(key));
〰58:  
〰59:          TValue value;
‼60:          Dictionary.TryGetValue(key, out value);
‼61:          var removed = Dictionary.Remove(key);
‼62:          if (removed)
〰63:              //OnCollectionChanged(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value));
‼64:              OnCollectionChanged();
〰65:  
‼66:          return removed;
〰67:      }
〰68:  
〰69:      public TValue this[TKey key]
〰70:      {
‼71:          get => Dictionary[key];
‼72:          set => Insert(key, value, false);
〰73:      }
〰74:  
〰75:      #endregion
〰76:  
〰77:      #region ICollection<KeyValuePair<TKey,TValue>> Members
〰78:  
‼79:      public void Add(KeyValuePair<TKey, TValue> item) => Insert(item.Key, item.Value, true);
〰80:  
〰81:      public void Clear()
〰82:      {
‼83:          if (Dictionary.Count > 0)
〰84:          {
‼85:              Dictionary.Clear();
‼86:              OnCollectionChanged();
〰87:          }
‼88:      }
〰89:  
〰90:      #endregion
〰91:  
〰92:      #region IEnumerable<KeyValuePair<TKey,TValue>> Members
〰93:  
‼94:      public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();
〰95:  
〰96:      #endregion
〰97:  
〰98:      #region IEnumerable Members
〰99:  
‼100:     IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Dictionary).GetEnumerator();
〰101: 
〰102:     #endregion
〰103: 
〰104:     #region INotifyCollectionChanged Members
〰105: 
〰106:     public event NotifyCollectionChangedEventHandler? CollectionChanged;
〰107: 
〰108:     #endregion
〰109: 
〰110:     #region INotifyPropertyChanged Members
〰111: 
〰112:     public event PropertyChangedEventHandler? PropertyChanged;
〰113: 
〰114:     #endregion
〰115: 
〰116:     public void AddRange(IDictionary<TKey, TValue> items)
〰117:     {
‼118:         ArgumentNullException.ThrowIfNull(items, nameof(items));
〰119: 
‼120:         if (items.Count > 0)
〰121:         {
‼122:             if (items.Keys.Any((k) => Dictionary.ContainsKey(k)))
‼123:                 throw new ArgumentException("An item with the same key has already been added.");
〰124:             else
‼125:                 foreach (var item in items) Dictionary.Add(item);
〰126: 
〰127: 
‼128:             OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray());
〰129:         }
‼130:     }
〰131: 
〰132:     private void Insert(TKey key, TValue value, bool add)
〰133:     {
‼134:         if (key == null) throw new ArgumentNullException(nameof(key));
〰135: 
〰136:         TValue item;
‼137:         if (Dictionary.TryGetValue(key, out item))
〰138:         {
‼139:             if (add) throw new ArgumentException("An item with the same key has already been added.");
‼140:             if (Equals(item, value)) return;
‼141:             Dictionary[key] = value;
〰142: 
‼143:             OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));
〰144:         }
〰145:         else
〰146:         {
‼147:             Dictionary[key] = value;
〰148: 
‼149:             OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
〰150:         }
‼151:     }
〰152: 
〰153:     private const string IndexerName = "Item[]";
〰154: 
〰155:     private void OnPropertyChanged()
〰156:     {
‼157:         OnPropertyChanged(nameof(this.Count));
‼158:         OnPropertyChanged(IndexerName);
‼159:         OnPropertyChanged(nameof(this.Keys));
‼160:         OnPropertyChanged(nameof(this.Values));
‼161:     }
〰162: 
‼163:     protected virtual void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
〰164:     private void OnCollectionChanged()
〰165:     {
‼166:         OnPropertyChanged();
‼167:         this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
‼168:     }
〰169: 
〰170:     private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
〰171:     {
‼172:         OnPropertyChanged();
‼173:         this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem));
‼174:     }
〰175: 
〰176:     private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
〰177:     {
‼178:         OnPropertyChanged();
‼179:         this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
‼180:     }
〰181: 
〰182:     private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
〰183:     {
‼184:         OnPropertyChanged();
‼185:         this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems));
‼186:     }
〰187: }
〰188: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

