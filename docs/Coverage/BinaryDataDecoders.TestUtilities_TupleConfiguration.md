# BinaryDataDecoders.TestUtilities.Configuration.TupleConfiguration

## Summary

| Key             | Value                                                               |
| :-------------- | :------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.TestUtilities.Configuration.TupleConfiguration` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                                  |
| Coveredlines    | `0`                                                                 |
| Uncoveredlines  | `42`                                                                |
| Coverablelines  | `42`                                                                |
| Totallines      | `90`                                                                |
| Linecoverage    | `0`                                                                 |
| Coveredbranches | `0`                                                                 |
| Totalbranches   | `10`                                                                |
| Branchcoverage  | `0`                                                                 |

## Metrics

| Complexity | Lines | Branches | Name                        |
| :--------- | :---- | :------- | :-------------------------- |
| 4          | 0     | 0        | `ctor`                      |
| 1          | 0     | 100      | `get_Key`                   |
| 1          | 0     | 100      | `get_Path`                  |
| 1          | 0     | 100      | `get_Value`                 |
| 1          | 0     | 100      | `ctor`                      |
| 2          | 0     | 0        | `get_Item`                  |
| 2          | 0     | 0        | `set_Item`                  |
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
〰7:   namespace BinaryDataDecoders.TestUtilities.Configuration
〰8:   {
〰9:       public class TupleConfiguration : IConfiguration, IConfigurationSection
〰10:      {
‼11:          private readonly IDictionary<string, string> _store = new Dictionary<string, string>();
〰12:  
‼13:          public string? Key { get; }
‼14:          public string? Path { get; }
‼15:          public string? Value { get; set; }
〰16:  
〰17:          public TupleConfiguration(params (string key, string value)[] settings)
‼18:              : this(settings.AsEnumerable())
〰19:          {
‼20:          }
〰21:  
‼22:          public TupleConfiguration(IEnumerable<(string key, string value)> settings, string? key = null, string? path = null)
〰23:          {
‼24:              if (settings.Count() == 1)
〰25:              {
‼26:                  var first = settings.FirstOrDefault();
‼27:                  Value = first.value;
‼28:                  Key = first.key;
‼29:                  Path = string.Join(":", new[] { path, key }.Where(i => !string.IsNullOrWhiteSpace(i)));
〰30:              }
〰31:              else
〰32:              {
‼33:                  Key = key;
‼34:                  Path = string.Join(":", new[] { path, key }.Where(i => !string.IsNullOrWhiteSpace(i)));
〰35:              }
‼36:              foreach (var setting in settings)
〰37:              {
‼38:                  this[setting.key] = setting.value;
〰39:              }
‼40:          }
〰41:  
〰42:          public string? this[string key]
〰43:          {
‼44:              get { return _store.TryGetValue(key, out var value) ? value : null; }
〰45:              set
〰46:              {
‼47:                  if (_store.ContainsKey(key))
〰48:                  {
‼49:                      _store[key] = value;
〰50:                  }
〰51:                  else
〰52:                  {
‼53:                      _store.Add(key, value);
〰54:                  }
‼55:              }
〰56:          }
‼57:          public IChangeToken GetReloadToken() => new ChangeToken();
〰58:  
〰59:  
〰60:          public IEnumerable<IConfigurationSection> GetChildren()
〰61:          {
‼62:              var values = from k in _store.Keys
‼63:                           let p = k.Split(new char[] { ':' }, 2)
‼64:                           group new
‼65:                           {
‼66:                               key = p.ElementAtOrDefault(1),
‼67:                               value = _store[k],
‼68:                           } by p.ElementAtOrDefault(0);
〰69:  
‼70:              foreach (var value in values)
‼71:                  yield return new TupleConfiguration(
‼72:                      settings: value.Select(i => (i.key, i.value)),
‼73:                      key: value.Key,
‼74:                      path: this.Path
‼75:                      );
‼76:          }
〰77:  
〰78:          public IConfigurationSection GetSection(string key) =>
‼79:               GetChildren().FirstOrDefault(i => i.Key == key);
〰80:  
〰81:          internal class ChangeToken : IChangeToken, IDisposable
〰82:          {
‼83:              public bool HasChanged => false;
‼84:              public bool ActiveChangeCallbacks => false;
‼85:              public void Dispose() { }
‼86:              public IDisposable RegisterChangeCallback(Action<object> callback, object state) => this;
〰87:          }
〰88:  
〰89:      }
〰90:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

