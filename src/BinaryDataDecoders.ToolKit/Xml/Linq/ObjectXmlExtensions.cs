using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.Linq
{
    public static class ObjectXmlExtensions
    {
        // https://stackoverflow.com/a/2404984/89586

        private static readonly Type[] WriteTypes = new[] {
            typeof(DateTime), typeof(decimal), typeof(Guid), typeof(bool),
            typeof(DateTime?), typeof(decimal?), typeof(Guid?), typeof(bool?),
        };
        public static bool IsSimpleType(this Type type) => type.IsPrimitive || WriteTypes.Contains(type);

        private static XObject? ToXml(this PropertyInfo prop, object? input)
        {
            var name = XmlConvert.EncodeName(prop.Name);
            var val = prop.GetValue(input, null);
            if (val == null || val == DBNull.Value)
                return null;

            if (prop.PropertyType.IsSimpleType())
            {
                return new XAttribute(name, val);
            }

            return val.ToXml(name);
        }

        public static XElement? ToXml(this object input)
        {
            if (input == null) return null;

            var element = input as XElement;
            if (element != null)
                return element;

            var document = input as XDocument;
            if (document != null)
            {
                return XElement.Load(document.CreateReader());
            }

            return input.ToXml(null);
        }
        public static XElement? ToXml(this object input, string? element)
        {
            if (input == null)
                return null;

            if (string.IsNullOrEmpty(element))
                element = "object";
            element = XmlConvert.EncodeName(element);

            var type = input.GetType();


            var ret = new XElement(element);
            if (type.IsSimpleType())
            {
                ret.Add(input);
            }
            else
            {
                var ms = input as MemoryStream;
                if (ms != null)
                {
                    input = ms.ToArray();
                }
                if (input is Stream)
                {
                    throw new NotSupportedException();
                }

                var enumerable = input as IEnumerable;

                if (enumerable != null)
                {
                    if (input is IEnumerable<char> || input is char[])
                    {
                        input = new string(enumerable.Cast<char>().ToArray());
                    }
                    else if (input is IEnumerable<byte> || input is byte[])
                    {
                        input = Convert.ToBase64String(enumerable.Cast<byte>().ToArray());
                    }
                }
                if (input is string) // ensure strings are written as text 
                {
                    ret.Add(input);
                }
                else if (enumerable != null)
                {
                    var itemName = enumerable.GetType().GetElementType()?.Name ?? "<>f__AnonymousType1`";

                    if (itemName.StartsWith("<>f__AnonymousType1`"))
                    {
                        if (element.EndsWith("s"))
                        {
                            itemName = element.Substring(0, element.Length - 1);
                        }
                        else if (element.EndsWith("es"))
                        {
                            itemName = element.Substring(0, element.Length - 2);
                        }
                        else if (element == "object")
                        {
                            itemName = "item";
                        }
                        else
                        {
                            itemName = element;
                        }
                    }

                    var elements = from item in enumerable.Cast<object>()
                                   where item != null
                                   let itemType = item.GetType()
                                   select item.ToXml(itemName);

                    ret.Add(elements);
                    if (!ret.HasElements)
                        return null;
                }
                else
                {
                    var props = type.GetProperties();
                    var elements = from prop in props
                                   let value = prop.ToXml(input)
                                   where value != null
                                   select value;

                    ret.Add(elements);
                }
            }

            return ret;
        }
    }
}
