using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Reflection
{
    public class ReflectionElementNodeBuilder
    {
        protected bool ExcludeNamespace { get; }
        protected bool ExcludeTypeDetails { get; }
        protected object Seed { get; }

        public ReflectionElementNodeBuilder(object seed, bool excludeNamespace = false, bool excludeTypeDetails = false)
        {
            Seed = seed;
            ExcludeNamespace = excludeNamespace;
            ExcludeTypeDetails = excludeTypeDetails;
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
        protected virtual IEnumerable<XName>? NamespacesSelector(object model) => Enumerable.Empty<XName>();

        protected virtual IEnumerable<(XName name, object child)>? ChildSelector(object model) =>
             IsValue(model) ? null : model switch
             {
                 null => null,
                 IEnumerable enumerable => from item in enumerable.Cast<object>()
                                           where item != null
                                           select (item.GetXmlElementName(ExcludeNamespace), item),
                 _ => from property in model.GetType().GetProperties() ?? Enumerable.Empty<PropertyInfo>()
                      where property.CanRead && AllowNavigate(model, property)
                      select (XName.Get(property.Name, ExcludeNamespace ? "" : model.GetXmlNamespace()), SafeRead(model, property))
             };

        protected virtual bool AllowNavigate(object model, PropertyInfo property) =>
            model switch
            {
                null => false,
                Type _ => false,
                _ => property.GetIndexParameters() switch
                {
                    ParameterInfo[] indexes when indexes.Length > 0 => false,
                    _ => true,
                }
            };

        protected virtual object? SafeRead(object model, PropertyInfo property)
        {
            try
            {
                return property.GetValue(model);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to read {property.Name}: {ex.Message}");
                return null;
            }
        }

        protected virtual IEnumerable<(XName name, string? value)>? AttributeSelector(object model) =>
            ExcludeTypeDetails switch
            {
                true => null,
                false => model switch
                {
                    null => null,
                    // Type type => new (XName name, string? value)[] {
                    //    (XName.Get("AssemblyQualifiedName"), type.AssemblyQualifiedName),
                    //    (XName.Get("Name"), type.Name),
                    //    (XName.Get("FullName"),type.FullName),
                    //    (XName.Get("Namespace"), type.Namespace),
                    //},
                    _ => new (XName name, string? value)[] {
                       (XName.Get("AssemblyQualifiedName"), model?.GetType()?.AssemblyQualifiedName),
                       (XName.Get("Name"), model?.GetType()?.Name),
                       (XName.Get("FullName"), model?.GetType()?.FullName),
                       (XName.Get("Namespace"), model?.GetType()?.Namespace),
                   }
                }
            };

        protected virtual string? ValueSelector(object model) =>
            IsValue(model) ? model switch
            {
                null => null,

                Type type => type.AssemblyQualifiedName,

                byte[] bytes => Convert.ToBase64String(bytes),
                IEnumerable<byte> bytes => Convert.ToBase64String(bytes.ToArray()),
                MemoryStream ms => Convert.ToBase64String(ms.ToArray()),
                Stream stream => Convert.ToBase64String(stream.AsBytes()),

                string @string => @string,
                char[] chars => new string(chars),
                IEnumerable<char> chars => new string(chars.ToArray()),
                _ => model.ToString()
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
