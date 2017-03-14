using System.IO;
using Newtonsoft.Json;
namespace Lynkio.CoreFramework.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetMessageType(this object obj) => obj.GetType().AssemblyQualifiedName;
        public static string ToJsonString(this object obj) => JsonConvert.SerializeObject(obj);
        public static object LoadFileAsType(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            return obj;
        }

        public static string SerializeToJson(this object arg, bool checknull = false)
        {
            if (checknull)
            {
                return JsonConvert.SerializeObject(arg, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }).RemoveJsonNulls();
            }
            return JsonConvert.SerializeObject(arg);
        }
    }
}
