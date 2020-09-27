using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit
{
    public static class TypeEx
    {
        public static Stream GetResourceStream(this Type classType, string filename) =>
             classType?.Assembly.GetManifestResourceStream($"{classType.Namespace}.{filename}");

        public static Task<string> GetResourceAsStringAsync(this Type context, string filename) =>
            context.GetResourceStream(filename).ReadAsStringAsync();

        public static string GetXmlNamespace(this Type type) =>
            type == null ? null :
            $"clr:{string.Join(',', type.AssemblyQualifiedName.Split(',').Where(s => !s.Contains('=')))}";
    }
}
