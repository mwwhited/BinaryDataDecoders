using System.IO;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit
{
    public static class ObjectEx
    {
        public static Stream GetResourceStream(this object context, string filename) =>
            context?.GetType().GetResourceStream(filename);

        public static Task<string> GetResourceAsStringAsync(this object context, string filename) =>
            context.GetResourceStream(filename).ReadAsStringAsync();

        public static string GetXmlNamespace(this object obj) =>
            obj?.GetType().GetXmlNamespace();

        //public static async Task<T> GetResourceFromJsonAsync<T>(this object context, string filename, JsonSerializerSettings settings = null)
        //{
        //    var json = await context.GetResourceAsStringAsync(filename);
        //    if (string.IsNullOrWhiteSpace(json))
        //        return default;
        //    return JsonConvert.DeserializeObject<T>(json, settings);
        //}
    }
}
