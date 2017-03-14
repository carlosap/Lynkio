using Newtonsoft.Json;
using System;
using System.IO;
namespace Lynkio.CoreFramework.Extensions
{
    public static class StreamExtensions
    {
        public static string ReadToEnd(this Stream stream) => new StreamReader(stream).ReadToEnd();
        public static T ReadFromJson<T>(this Stream stream) => JsonConvert.DeserializeObject<T>(stream.ReadToEnd());
        public static object ReadFromJson(this Stream stream, string messageType) => JsonConvert.DeserializeObject(stream.ReadToEnd(), Type.GetType(messageType));
    }
}
