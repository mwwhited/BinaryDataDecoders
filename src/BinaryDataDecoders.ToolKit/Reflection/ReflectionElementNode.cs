using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Reflection
{
    public class ReflectionElementNode
    {
        protected bool ExcludeNamespace { get; }
        protected object Seed { get; }
		
        public ReflectionElementNode(object seed, bool excludeNamespace = false)
        {
            ExcludeNamespace = excludeNamespace;
            Seed = seed;
        }

        public INode Build() =>
            new ExtensibleElementNode(
                 Seed.GetXmlElementName(ExcludeNamespace),
                 Seed,
                 o => ValueSelector(o),
                 o => AttributeSelector(o),
                 o => ChildSelector(o),
                 o => NamespacesSelector(o),
                 o => PreserveWhitespace(o)
                 );

        protected virtual bool PreserveWhitespace(object obj) => true;
        protected virtual IEnumerable<XName>? NamespacesSelector(object arg) => Enumerable.Empty<XName>();

        protected virtual IEnumerable<(XName name, object child)>? ChildSelector(object arg) =>
             IsValue(arg) ? null : arg switch
             {
                 IEnumerable enumerable => from item in enumerable.Cast<object>()
                                           where item != null
                                           select (item.GetXmlElementName(ExcludeNamespace), item),
                 _ => from property in arg.GetType().GetProperties() ?? Enumerable.Empty<PropertyInfo>()
                      where property.CanRead
                      select (XName.Get(property.Name, ExcludeNamespace ? "" : arg.GetXmlNamespace()), SafeRead(arg, property))
             };

        protected virtual object? SafeRead(object arg, PropertyInfo property)
        {
            try
            {
                return property.GetValue(arg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to read {property.Name}: {ex.Message}");
                return null;
            }
        }

        protected virtual IEnumerable<(XName name, string? value)>? AttributeSelector(object arg) =>
           new (XName name, string? value)[] {
               (XName.Get("AssemblyQualifiedName"), arg?.GetType()?.AssemblyQualifiedName),
               (XName.Get("Name"), arg?.GetType()?.Name),
               (XName.Get("FullName"), arg?.GetType()?.FullName),
               (XName.Get("Namespace"), arg?.GetType()?.Namespace),
           };

        protected virtual string? ValueSelector(object arg) =>
            IsValue(arg) ? arg switch
            {
                string @string => @string,
                byte[] bytes => Convert.ToBase64String(bytes),
                IEnumerable<byte> bytes => Convert.ToBase64String(bytes.ToArray()),
                MemoryStream ms => Convert.ToBase64String(ms.ToArray()),
                Stream stream => Convert.ToBase64String(stream.AsBytes()),
                char[] chars => new string(chars),
                IEnumerable<char> chars => new string(chars.ToArray()),
                _ => arg.ToString()
            } : null;

        protected virtual bool IsValue(object input) =>
            input switch
            {
                null => false,
                _ when input.GetType().IsSimpleType() => true,
                byte[] _ => true,
                IEnumerable<byte> _ => true,
                char[] _ => true,
                IEnumerable<char> _ => true,
                Stream _ => true,
                _ => false
            };
    }
}
