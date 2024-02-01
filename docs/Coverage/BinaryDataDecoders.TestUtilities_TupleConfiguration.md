# BinaryDataDecoders.TestUtilities.Configuration.TupleConfiguration

## Summary

| Key             | Value                                                               |
| :-------------- | :------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.TestUtilities.Configuration.TupleConfiguration` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                                  |
| Coveredlines    | `0`                                                                 |
| Uncoveredlines  | `80`                                                                |
| Coverablelines  | `80`                                                                |
| Totallines      | `185`                                                               |
| Linecoverage    | `0`                                                                 |
| Coveredbranches | `0`                                                                 |
| Totalbranches   | `26`                                                                |
| Branchcoverage  | `0`                                                                 |
| Coveredmethods  | `0`                                                                 |
| Totalmethods    | `22`                                                                |
| Methodcoverage  | `0`                                                                 |

## Metrics

| Complexity | Lines | Branches | Name                        |
| :--------- | :---- | :------- | :-------------------------- |
| 3          | 0     | 0        | `ctor`                      |
| 1          | 0     | 100      | `ctor`                      |
| 2          | 0     | 0        | `get_Item`                  |
| 6          | 0     | 0        | `set_Item`                  |
| 1          | 0     | 100      | `GetReloadToken`            |
| 2          | 0     | 0        | `GetChildren`               |
| 1          | 0     | 100      | `GetSection`                |
| 1          | 0     | 100      | `get_HasChanged`            |
| 1          | 0     | 100      | `get_ActiveChangeCallbacks` |
| 1          | 0     | 100      | `Dispose`                   |
| 1          | 0     | 100      | `RegisterChangeCallback`    |
| 3          | 0     | 0        | `ctor`                      |
| 1          | 0     | 100      | `ctor`                      |
| 2          | 0     | 0        | `get_Item`                  |
| 6          | 0     | 0        | `set_Item`                  |
| 1          | 0     | 100      | `GetReloadToken`            |
| 2          | 0     | 0        | `GetChildren`               |
| 1          | 0     | 100      | `GetSection`                |
| 1          | 0     | 100      | `get_HasChanged`            |
| 1          | 0     | 100      | `get_ActiveChangeCallbacks` |
| 1          | 0     | 100      | `Dispose`                   |
| 1          | 0     | 100      | `RegisterChangeCallback`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/Configuration/TupleConfiguration.cs

```CSharp
〰1:   using Microsoft.Extensions.Configuration;
〰2:   using Microsoft.Extensions.Primitives;
〰3:   using System;
〰4:   using System.Collections.Generic;
〰5:   using System.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.TestUtilities.Configuration;
〰8:   
〰9:   public class TupleConfiguration : IConfiguration, IConfigurationSection
〰10:  {
‼11:      private readonly IDictionary<string, string> _store = new Dictionary<string, string>();
〰12:  
〰13:      public string? Key { get; }
〰14:      public string? Path { get; }
〰15:      public string? Value { get; set; }
〰16:  
〰17:      public TupleConfiguration(params (string key, string value)[] settings)
‼18:          : this(settings.AsEnumerable())
〰19:      {
‼20:      }
〰21:  
〰22:      public TupleConfiguration(IEnumerable<(string key, string value)> settings, string? key = null, string? path = null)
〰23:      {
‼24:          if (settings.Count() == 1)
〰25:          {
‼26:              var first = settings.FirstOrDefault();
‼27:              Value = first.value;
‼28:              Key = first.key;
‼29:              Path = string.Join(":", new[] { path, key }.Where(i => !string.IsNullOrWhiteSpace(i)));
〰30:          }
〰31:          else
〰32:          {
〰33:              Key = key;
‼34:              Path = string.Join(":", new[] { path, key }.Where(i => !string.IsNullOrWhiteSpace(i)));
〰35:          }
‼36:          foreach (var setting in settings)
〰37:          {
‼38:              this[setting.key] = setting.value;
〰39:          }
‼40:      }
〰41:  
〰42:      public string? this[string key]
〰43:      {
‼44:          get { return _store.TryGetValue(key, out var value) ? value : null; }
〰45:          set
〰46:          {
‼47:              if (_store.ContainsKey(key))
〰48:              {
‼49:                  if (value == null)
‼50:                      _store.Remove(key);
〰51:                  else
‼52:                      _store[key] = value;
〰53:              }
‼54:              else if (value != null)
〰55:              {
‼56:                  _store.Add(key, value);
〰57:              }
‼58:          }
〰59:      }
‼60:      public IChangeToken GetReloadToken() => new ChangeToken();
〰61:  
〰62:  
〰63:      public IEnumerable<IConfigurationSection> GetChildren()
〰64:      {
‼65:          var values = from k in _store.Keys
‼66:                       let p = k.Split([':'], 2)
‼67:                       group new
‼68:                       {
‼69:                           key = p.ElementAtOrDefault(1),
‼70:                           value = _store[k],
‼71:                       } by p.ElementAtOrDefault(0);
〰72:  
‼73:          foreach (var value in values)
‼74:              yield return new TupleConfiguration(
‼75:                  settings: value.Select(i => (i.key, i.value)),
‼76:                  key: value.Key,
‼77:                  path: this.Path
‼78:                  );
‼79:      }
〰80:  
〰81:      public IConfigurationSection GetSection(string key) =>
‼82:           GetChildren().FirstOrDefault(i => i.Key == key);
〰83:  
〰84:      internal class ChangeToken : IChangeToken, IDisposable
〰85:      {
‼86:          public bool HasChanged => false;
‼87:          public bool ActiveChangeCallbacks => false;
‼88:          public void Dispose() { }
‼89:          public IDisposable RegisterChangeCallback(Action<object> callback, object state) => this;
〰90:      }
〰91:  
〰92:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.TestUtilities/Configuration/TupleConfiguration.cs

```CSharp
〰1:   using Microsoft.Extensions.Configuration;
〰2:   using Microsoft.Extensions.Primitives;
〰3:   using System;
〰4:   using System.Collections.Generic;
〰5:   using System.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.TestUtilities.Configuration;
〰8:   
〰9:   public class TupleConfiguration : IConfiguration, IConfigurationSection
〰10:  {
‼11:      private readonly IDictionary<string, string> _store = new Dictionary<string, string>();
〰12:  
〰13:      public string? Key { get; }
〰14:      public string? Path { get; }
〰15:      public string? Value { get; set; }
〰16:  
〰17:      public TupleConfiguration(params (string key, string value)[] settings)
‼18:          : this(settings.AsEnumerable())
〰19:      {
‼20:      }
〰21:  
〰22:      public TupleConfiguration(IEnumerable<(string key, string value)> settings, string? key = null, string? path = null)
〰23:      {
‼24:          if (settings.Count() == 1)
〰25:          {
‼26:              var first = settings.FirstOrDefault();
‼27:              Value = first.value;
‼28:              Key = first.key;
‼29:              Path = string.Join(":", new[] { path, key }.Where(i => !string.IsNullOrWhiteSpace(i)));
〰30:          }
〰31:          else
〰32:          {
〰33:              Key = key;
‼34:              Path = string.Join(":", new[] { path, key }.Where(i => !string.IsNullOrWhiteSpace(i)));
〰35:          }
‼36:          foreach (var setting in settings)
〰37:          {
‼38:              this[setting.key] = setting.value;
〰39:          }
‼40:      }
〰41:  
〰42:      public string? this[string key]
〰43:      {
‼44:          get { return _store.TryGetValue(key, out var value) ? value : null; }
〰45:          set
〰46:          {
‼47:              if (_store.ContainsKey(key))
〰48:              {
‼49:                  if (value == null)
‼50:                      _store.Remove(key);
〰51:                  else
‼52:                      _store[key] = value;
〰53:              }
‼54:              else if (value != null)
〰55:              {
‼56:                  _store.Add(key, value);
〰57:              }
‼58:          }
〰59:      }
‼60:      public IChangeToken GetReloadToken() => new ChangeToken();
〰61:  
〰62:  
〰63:      public IEnumerable<IConfigurationSection> GetChildren()
〰64:      {
‼65:          var values = from k in _store.Keys
‼66:                       let p = k.Split([':'], 2)
‼67:                       group new
‼68:                       {
‼69:                           key = p.ElementAtOrDefault(1),
‼70:                           value = _store[k],
‼71:                       } by p.ElementAtOrDefault(0);
〰72:  
‼73:          foreach (var value in values)
‼74:              yield return new TupleConfiguration(
‼75:                  settings: value.Select(i => (i.key, i.value)),
‼76:                  key: value.Key,
‼77:                  path: this.Path
‼78:                  );
‼79:      }
〰80:  
〰81:      public IConfigurationSection GetSection(string key) =>
‼82:           GetChildren().FirstOrDefault(i => i.Key == key);
〰83:  
〰84:      internal class ChangeToken : IChangeToken, IDisposable
〰85:      {
‼86:          public bool HasChanged => false;
‼87:          public bool ActiveChangeCallbacks => false;
‼88:          public void Dispose() { }
‼89:          public IDisposable RegisterChangeCallback(Action<object> callback, object state) => this;
〰90:      }
〰91:  
〰92:  }
〰93:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

