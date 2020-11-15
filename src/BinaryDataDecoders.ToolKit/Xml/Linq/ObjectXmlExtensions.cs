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
        public static XElement? AsXElement(this object input) =>
            input switch
            {
                null => null,
                XElement element => element,
                XDocument document => XElement.Load(document.CreateReader()),
                _ => ReflectObjectXml(input)
            };

        private static XObject? ReflectPropertyXml(PropertyInfo prop, object? input, XName parentName)
        {
            var name = XmlConvert.EncodeName(prop.Name);
            var val = prop.GetValue(input, null);
            if (val == null || val == DBNull.Value)
                return null;

            if (prop.PropertyType.IsSimpleType())
            {
                return new XAttribute(name, val);
            }

            return ReflectObjectXml(val, XName.Get(name, parentName?.NamespaceName ?? ""));
        }

        private static XElement? ReflectObjectXml(object input, XName? elementName = null)
        {
            if (input == null)
                return null;

            if (elementName == null) elementName = input.GetXmlElementName();

            var type = input.GetType();


            var ret = new XElement(elementName);
            if (type.IsSimpleType())
            {
                ret.Add(input);
            }
            else
            {
                if (input is MemoryStream ms)
                {
                    input = ms.ToArray();
                }
                if (input is Stream stream)
                {
                    using var newMs = new MemoryStream();
                    stream.CopyTo(newMs);
                    input = newMs.ToArray();
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
                    var itemName = enumerable.GetXmlItemName(elementName);

                    var elements = from item in enumerable.Cast<object>()
                                   where item != null
                                   let itemType = item.GetType()
                                   select ReflectObjectXml(item, itemName);

                    ret.Add(elements);
                    if (!ret.HasElements)
                        return null;
                }
                else
                {
                    var props = type.GetProperties();
                    var elements = from prop in props
                                   let value = ReflectPropertyXml(prop, input, elementName)
                                   where value != null
                                   select value;

                    ret.Add(elements);
                }
            }

            return ret;
        }
    }
}
