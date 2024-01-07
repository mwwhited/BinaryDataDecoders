using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.ToolKit.Collections.ObjectModel;

public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged
{
    protected IDictionary<TKey, TValue> Dictionary { get; } = new Dictionary<TKey, TValue>();

    #region Constructors
    public ObservableDictionary()
    {
    }
    public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
    {
        Dictionary = new Dictionary<TKey, TValue>(dictionary);
    }
    public ObservableDictionary(IEqualityComparer<TKey> comparer)
    {
        Dictionary = new Dictionary<TKey, TValue>(comparer);
    }
    public ObservableDictionary(int capacity)
    {
        Dictionary = new Dictionary<TKey, TValue>(capacity);
    }
    public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
    {
        Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
    }
    public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
    {
        Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
    }

    #endregion

    #region IDictionary<TKey,TValue> Members

    public void Add(TKey key, TValue value) => Insert(key, value, true);
    public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);
    public ICollection<TKey> Keys => Dictionary.Keys;
    public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);
    public ICollection<TValue> Values => Dictionary.Values;
    public bool Contains(KeyValuePair<TKey, TValue> item) => Dictionary.Contains(item);
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => Dictionary.CopyTo(array, arrayIndex);
    public int Count => Dictionary.Count;
    public bool IsReadOnly => Dictionary.IsReadOnly;
    public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);

    public bool Remove(TKey key)
    {
        if (key == null) throw new ArgumentNullException("key");

        TValue value;
        Dictionary.TryGetValue(key, out value);
        var removed = Dictionary.Remove(key);
        if (removed)
            //OnCollectionChanged(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value));
            OnCollectionChanged();

        return removed;
    }

    public TValue this[TKey key]
    {
        get => Dictionary[key];
        set => Insert(key, value, false);
    }

    #endregion

    #region ICollection<KeyValuePair<TKey,TValue>> Members

    public void Add(KeyValuePair<TKey, TValue> item) => Insert(item.Key, item.Value, true);

    public void Clear()
    {
        if (Dictionary.Count > 0)
        {
            Dictionary.Clear();
            OnCollectionChanged();
        }
    }

    #endregion

    #region IEnumerable<KeyValuePair<TKey,TValue>> Members

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Dictionary).GetEnumerator();

    #endregion

    #region INotifyCollectionChanged Members

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    #endregion

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    public void AddRange(IDictionary<TKey, TValue> items)
    {
        ArgumentNullException.ThrowIfNull(items, nameof(items));

        if (items.Count > 0)
        {
            if (items.Keys.Any((k) => Dictionary.ContainsKey(k)))
                throw new ArgumentException("An item with the same key has already been added.");
            else
                foreach (var item in items) Dictionary.Add(item);


            OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray());
        }
    }

    private void Insert(TKey key, TValue value, bool add)
    {
        if (key == null) throw new ArgumentNullException("key");

        TValue item;
        if (Dictionary.TryGetValue(key, out item))
        {
            if (add) throw new ArgumentException("An item with the same key has already been added.");
            if (Equals(item, value)) return;
            Dictionary[key] = value;

            OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));
        }
        else
        {
            Dictionary[key] = value;

            OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
        }
    }

    private const string IndexerName = "Item[]";

    private void OnPropertyChanged()
    {
        OnPropertyChanged(nameof(this.Count));
        OnPropertyChanged(IndexerName);
        OnPropertyChanged(nameof(this.Keys));
        OnPropertyChanged(nameof(this.Values));
    }

    protected virtual void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    private void OnCollectionChanged()
    {
        OnPropertyChanged();
        this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
    {
        OnPropertyChanged();
        this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem));
    }

    private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
    {
        OnPropertyChanged();
        this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
    }

    private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
    {
        OnPropertyChanged();
        this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems));
    }
}
