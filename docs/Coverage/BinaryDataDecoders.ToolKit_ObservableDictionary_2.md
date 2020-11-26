# BinaryDataDecoders.ToolKit.Collections.ObjectModel.ObservableDictionary`2

## Summary

| Key             | Value                                                                       |
| :-------------- | :-------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.ObjectModel.ObservableDictionary`2` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                                |
| Coveredlines    | `0`                                                                         |
| Uncoveredlines  | `77`                                                                        |
| Coverablelines  | `77`                                                                        |
| Totallines      | `187`                                                                       |
| Linecoverage    | `0`                                                                         |
| Coveredbranches | `0`                                                                         |
| Totalbranches   | `32`                                                                        |
| Branchcoverage  | `0`                                                                         |

## Metrics

| Complexity | Lines | Branches | Name                                        |
| :--------- | :---- | :------- | :------------------------------------------ |
| 1          | 0     | 100      | `get_Dictionary`                            |
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
‼16:          public ObservableDictionary()
〰17:          {
‼18:          }
‼19:          public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
〰20:          {
‼21:              Dictionary = new Dictionary<TKey, TValue>(dictionary);
‼22:          }
‼23:          public ObservableDictionary(IEqualityComparer<TKey> comparer)
〰24:          {
‼25:              Dictionary = new Dictionary<TKey, TValue>(comparer);
‼26:          }
‼27:          public ObservableDictionary(int capacity)
〰28:          {
‼29:              Dictionary = new Dictionary<TKey, TValue>(capacity);
‼30:          }
‼31:          public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
〰32:          {
‼33:              Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
‼34:          }
‼35:          public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
〰36:          {
‼37:              Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
‼38:          }
〰39:          #endregion
〰40:  
〰41:          #region IDictionary<TKey,TValue> Members
〰42:  
‼43:          public void Add(TKey key, TValue value) => Insert(key, value, true);
‼44:          public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);
‼45:          public ICollection<TKey> Keys => Dictionary.Keys;
‼46:          public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);
‼47:          public ICollection<TValue> Values => Dictionary.Values;
‼48:          public bool Contains(KeyValuePair<TKey, TValue> item) => Dictionary.Contains(item);
‼49:          public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => Dictionary.CopyTo(array, arrayIndex);
‼50:          public int Count => Dictionary.Count;
‼51:          public bool IsReadOnly => Dictionary.IsReadOnly;
‼52:          public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);
〰53:  
〰54:          public bool Remove(TKey key)
〰55:          {
‼56:              if (key == null) throw new ArgumentNullException("key");
〰57:  
〰58:              TValue value;
‼59:              Dictionary.TryGetValue(key, out value);
‼60:              var removed = Dictionary.Remove(key);
‼61:              if (removed)
〰62:                  //OnCollectionChanged(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value));
‼63:                  OnCollectionChanged();
〰64:  
‼65:              return removed;
〰66:          }
〰67:  
〰68:          public TValue this[TKey key]
〰69:          {
‼70:              get => Dictionary[key];
‼71:              set => Insert(key, value, false);
〰72:          }
〰73:  
〰74:          #endregion
〰75:  
〰76:          #region ICollection<KeyValuePair<TKey,TValue>> Members
〰77:  
‼78:          public void Add(KeyValuePair<TKey, TValue> item) => Insert(item.Key, item.Value, true);
〰79:  
〰80:          public void Clear()
〰81:          {
‼82:              if (Dictionary.Count > 0)
〰83:              {
‼84:                  Dictionary.Clear();
‼85:                  OnCollectionChanged();
〰86:              }
‼87:          }
〰88:  
〰89:          #endregion
〰90:  
〰91:          #region IEnumerable<KeyValuePair<TKey,TValue>> Members
〰92:  
‼93:          public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();
〰94:  
〰95:          #endregion
〰96:  
〰97:          #region IEnumerable Members
〰98:  
‼99:          IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Dictionary).GetEnumerator();
〰100: 
〰101:         #endregion
〰102: 
〰103:         #region INotifyCollectionChanged Members
〰104: 
〰105:         public event NotifyCollectionChangedEventHandler CollectionChanged;
〰106: 
〰107:         #endregion
〰108: 
〰109:         #region INotifyPropertyChanged Members
〰110: 
〰111:         public event PropertyChangedEventHandler PropertyChanged;
〰112: 
〰113:         #endregion
〰114: 
〰115:         public void AddRange(IDictionary<TKey, TValue> items)
〰116:         {
‼117:             if (items == null) throw new ArgumentNullException("items");
〰118: 
‼119:             if (items.Count > 0)
〰120:             {
‼121:                 if (items.Keys.Any((k) => Dictionary.ContainsKey(k)))
‼122:                     throw new ArgumentException("An item with the same key has already been added.");
〰123:                 else
‼124:                     foreach (var item in items) Dictionary.Add(item);
〰125: 
〰126: 
‼127:                 OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray());
〰128:             }
‼129:         }
〰130: 
〰131:         private void Insert(TKey key, TValue value, bool add)
〰132:         {
‼133:             if (key == null) throw new ArgumentNullException("key");
〰134: 
〰135:             TValue item;
‼136:             if (Dictionary.TryGetValue(key, out item))
〰137:             {
‼138:                 if (add) throw new ArgumentException("An item with the same key has already been added.");
‼139:                 if (Equals(item, value)) return;
‼140:                 Dictionary[key] = value;
〰141: 
‼142:                 OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));
〰143:             }
〰144:             else
〰145:             {
‼146:                 Dictionary[key] = value;
〰147: 
‼148:                 OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
〰149:             }
‼150:         }
〰151: 
〰152:         private const string IndexerName = "Item[]";
〰153: 
〰154:         private void OnPropertyChanged()
〰155:         {
‼156:             OnPropertyChanged(nameof(this.Count));
‼157:             OnPropertyChanged(IndexerName);
‼158:             OnPropertyChanged(nameof(this.Keys));
‼159:             OnPropertyChanged(nameof(this.Values));
‼160:         }
〰161: 
‼162:         protected virtual void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
〰163:         private void OnCollectionChanged()
〰164:         {
‼165:             OnPropertyChanged();
‼166:             this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
‼167:         }
〰168: 
〰169:         private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
〰170:         {
‼171:             OnPropertyChanged();
‼172:             this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem));
‼173:         }
〰174: 
〰175:         private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
〰176:         {
‼177:             OnPropertyChanged();
‼178:             this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
‼179:         }
〰180: 
〰181:         private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
〰182:         {
‼183:             OnPropertyChanged();
‼184:             this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems));
‼185:         }
〰186:     }
〰187: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

