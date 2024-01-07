using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BinaryDataDecoders.ToolKit;

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
         classType.Assembly.GetManifestResourceStream($"{classType.Namespace}.{filename}") ??
         classType.Assembly.GetManifestResourceStream(
             classType.Assembly.GetManifestResourceNames()
                               .FirstOrDefault(f => f.EndsWith($".{filename}"))
             );

    /// <summary>
    /// Access stream for resource found in the same name space as the referenced object 
    /// </summary>
    /// <param name="context">object to use as locater</param>
    /// <param name="filename">name of resource</param>
    /// <returns>string content of resource</returns>
    public static async Task<string> GetResourceAsStringAsync(this Type context, string filename) =>
        (await context.GetResourceStream(filename).ReadAsStringAsync()) ?? "";

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
        var ns = type.GetCustomAttribute<XmlRootAttribute>(true)?.Namespace;
        if (string.IsNullOrWhiteSpace(ns))
        {
            if (type.IsAnonymousType()) return "";
            return $"clr:{string.Join(',', type.AssemblyQualifiedName.Split(',').Where(s => !s.Contains('=')))}";
        }
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

    private static readonly Type[] _simpleTypes = new[] {
        typeof(decimal), typeof(decimal?),
        typeof(Guid),typeof(Guid?),
        typeof(bool), typeof(bool?),
        typeof(DateTime), typeof(DateTime?),
        typeof(DateTimeOffset),typeof(DateTimeOffset?),
        typeof(TimeSpan),typeof(TimeSpan?),
    };
    /// <summary>
    /// check if type is "simple" .. primitive or [decimal, datetime, bool]
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsSimpleType(this Type type) => type.IsPrimitive || _simpleTypes.Contains(type);

    public static bool IsAnonymousType(this Type type) =>
        type?.Name switch
        {
            null => false,
            string name when name.StartsWith("<>f__AnonymousType") || name.StartsWith("VB$AnonymousType_") => true,
            _ => false
        };

    public static XName GetXmlElementName(this Type type, bool excludeNamespace = false)
    {
        var objectName = type.Name;
        if (objectName.StartsWith("<>f__AnonymousType")) objectName = "object";

        return XName.Get(XmlConvert.EncodeName(objectName), excludeNamespace ? "" : type.GetXmlNamespace());
    }
}
