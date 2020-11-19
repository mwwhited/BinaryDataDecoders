using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit
{
    /// <summary>
    /// Extension methods for System.Object
    /// </summary>
    public static class ObjectEx
    {
        /// <summary>
        /// Access stream for resource found in the same name space as the referenced object
        /// </summary>
        /// <param name="context">object to use as locater</param>
        /// <param name="filename">name of resource</param>
        /// <returns>resource stream</returns>
        public static Stream? GetResourceStream(this object context, string filename) =>
            context.GetType().GetResourceStream(filename);

        /// <summary>
        /// Access stream for resource found in the same name space as the referenced object 
        /// </summary>
        /// <param name="context">object to use as locater</param>
        /// <param name="filename">name of resource</param>
        /// <returns>string content of resource</returns>
        public static Task<string?> GetResourceAsStringAsync(this object context, string filename) =>
            context.GetResourceStream(filename).ReadAsStringAsync();

        /// <summary>
        /// Resolve XML Name space for referenced object.  
        /// </summary>
        /// <remarks>
        /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
        /// 
        /// <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
        /// </remarks>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetXmlNamespace(this object obj) =>
            obj.GetType().GetXmlNamespace();

        /// <summary>
        /// Resolve XML Namespace for referenced object.  
        /// </summary>
        /// <remarks>
        /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
        /// 
        /// <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
        /// </remarks>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetXmlNamespaceForOutput(this object obj) =>
            obj.GetType().GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;


        public static XName GetXmlElementName(this object @object, bool excludeNamespace = false) =>
            @object.GetType().GetXmlElementName(excludeNamespace);

        public static XName GetXmlItemName(this IEnumerable enumerable, bool excludeNamespace) =>
            enumerable.GetXmlItemName(enumerable.GetXmlElementName(excludeNamespace));

        public static XName GetXmlItemName(this IEnumerable enumerable, XName? elementName = null)
        {
            var elementType = enumerable.GetType().GetElementType();
            var itemName = elementType?.Name;
            return XName.Get(itemName switch
            {
                _ when elementType?.IsAnonymousType() ?? false =>
                    elementName switch
                    {
                        _ when elementName?.LocalName.EndsWith("es") ?? false => elementName.LocalName.Substring(0, elementName.LocalName.Length - 2),
                        _ when elementName?.LocalName.EndsWith("s") ?? false => elementName.LocalName.Substring(0, elementName.LocalName.Length - 1),
                        _ when string.Equals(elementName?.LocalName, "object", System.StringComparison.InvariantCultureIgnoreCase) => null,
                        _ => null,
                    },
                _ => itemName
            } ?? "item", elementName?.NamespaceName ?? elementType?.GetXmlNamespace() ?? "");
        }
    }
}
