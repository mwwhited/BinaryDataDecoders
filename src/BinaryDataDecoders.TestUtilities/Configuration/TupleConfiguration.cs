using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.TestUtilities.Configuration
{
    public class TupleConfiguration : IConfiguration, IConfigurationSection
    {
        private readonly IDictionary<string, string> _store = new Dictionary<string, string>();

        public string? Key { get; }
        public string? Path { get; }
        public string? Value { get; set; }

        public TupleConfiguration(params (string key, string value)[] settings)
            : this(settings.AsEnumerable())
        {
        }

        public TupleConfiguration(IEnumerable<(string key, string value)> settings, string? key = null, string? path = null)
        {
            if (settings.Count() == 1)
            {
                var first = settings.FirstOrDefault();
                Value = first.value;
                Key = first.key;
                Path = string.Join(":", new[] { path, key }.Where(i => !string.IsNullOrWhiteSpace(i)));
            }
            else
            {
                Key = key;
                Path = string.Join(":", new[] { path, key }.Where(i => !string.IsNullOrWhiteSpace(i)));
            }
            foreach (var setting in settings)
            {
                this[setting.key] = setting.value;
            }
        }

        public string? this[string key]
        {
            get { return _store.TryGetValue(key, out var value) ? value : null; }
            set
            {
                if (_store.ContainsKey(key))
                {
                    if (value == null)
                        _store.Remove(key);
                    else
                        _store[key] = value;
                }
                else if (value != null)
                {
                    _store.Add(key, value);
                }
            }
        }
        public IChangeToken GetReloadToken() => new ChangeToken();


        public IEnumerable<IConfigurationSection> GetChildren()
        {
            var values = from k in _store.Keys
                         let p = k.Split(new char[] { ':' }, 2)
                         group new
                         {
                             key = p.ElementAtOrDefault(1),
                             value = _store[k],
                         } by p.ElementAtOrDefault(0);

            foreach (var value in values)
                yield return new TupleConfiguration(
                    settings: value.Select(i => (i.key, i.value)),
                    key: value.Key,
                    path: this.Path
                    );
        }

        public IConfigurationSection GetSection(string key) =>
             GetChildren().FirstOrDefault(i => i.Key == key);

        internal class ChangeToken : IChangeToken, IDisposable
        {
            public bool HasChanged => false;
            public bool ActiveChangeCallbacks => false;
            public void Dispose() { }
            public IDisposable RegisterChangeCallback(Action<object> callback, object state) => this;
        }

    }
}
