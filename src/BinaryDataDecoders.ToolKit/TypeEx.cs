using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinaryDataDecoders.ToolKit
{
    /// <summary>
    /// Extension methods for System.Object
    /// </summary>
    public static class TypeEx
    {
        /// <summary>
        /// Access stream for resource found in the same name space as the referenced object
        /// </summary>
        /// <param name="classType">object to use as locater</param>
        /// <param name="filename">name of resource</param>
        /// <returns>resource stream</returns>
        public static Stream GetResourceStream(this Type classType, string filename) =>
             classType.Assembly.GetManifestResourceStream($"{classType.Namespace}.{filename}");

        /// <summary>
        /// Access stream for resource found in the same name space as the referenced object 
        /// </summary>
        /// <param name="context">object to use as locater</param>
        /// <param name="filename">name of resource</param>
        /// <returns>string content of resource</returns>
        public static Task<string> GetResourceAsStringAsync(this Type context, string filename) =>
            context.GetResourceStream(filename).ReadAsStringAsync();

        /// <summary>
        /// Resolve XML Name space for referenced object.  
        /// </summary>
        /// <remarks>
        /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
        /// 
        /// <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
        /// </remarks>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetXmlNamespace(this Type type)
        {
            var ns = type.GetCustomAttribute<XmlRootAttribute>()?.Namespace;
            if (string.IsNullOrWhiteSpace(ns)) return $"clr:{string.Join(',', type.AssemblyQualifiedName.Split(',').Where(s => !s.Contains('=')))}";
            return ns;
        }

        /// <summary>
        /// Resolve XML Namespace for referenced object.  
        /// </summary>
        /// <remarks>
        /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
        /// 
        /// <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
        /// </remarks>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetXmlNamespaceForOutput(this Type type) =>
            type?.GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;
    }
}
