using System;
using System.IO;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit
{
    public static class TypeExtensions
    {
        public static Stream GetResourceStream(this Type classType, string filename) =>
             classType?.Assembly.GetManifestResourceStream($"{classType.Namespace}.{filename}");
        public static Task<string> GetResourceAsStringAsync(this Type context, string filename) =>
            context.GetResourceStream(filename).ReadAsStringAsync();
    }
}
