using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lynkio.CoreFramework.Extensions.RegExp;
namespace Lynkio.CoreFramework.Extensions
{
    public static class StringExtensions
    {
        public static void EncryptFile(string filePath, byte[] encryptedBytes) => File.WriteAllBytes(filePath, encryptedBytes);
        public static string ReplaceInvalidCharsForUnderscore(this string strvalue) => Path.GetInvalidFileNameChars().Aggregate(ClearInvalidHttpChars(strvalue), (current, c) => current.Replace(c, '_'));
        public static string ClearInvalidHttpChars(this string strvalue) => strvalue.Replace("http", "").Replace("https", "").Replace(":", "").Replace("//", "").Replace("www.", "");
        public static T DeserializeObject<T>(this string json) => JsonConvert.DeserializeObject<T>(json);
        public static string SerializeObject<T>(this T obj) => JsonConvert.SerializeObject(obj);
        public static string ToCamelCase(this string value) => char.ToLowerInvariant(value[0]) + value.Substring(1);
        public static string FormatWith(this string formatString, params object[] args) => args == null || args.Length == 0 ? formatString : string.Format(formatString, args);
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        public static bool IsNullOrWhitespace(this string value) => string.IsNullOrWhiteSpace(value);
        public static string FirstCharToLower(this string value) => char.ToLowerInvariant(value[0]) + value.Substring(1);
        public static string ExtractString(string source,
            string beginDelim,
            string endDelim,
            bool caseSensitive = false,
            bool allowMissingEndDelimiter = false,
            bool returnDelimiters = false)
        {
            int at1, at2;

            if (string.IsNullOrEmpty(source))
                return string.Empty;

            if (caseSensitive)
            {
                at1 = source.IndexOf(beginDelim, StringComparison.Ordinal);
                if (at1 == -1)
                    return string.Empty;

                at2 = !returnDelimiters
                    ? source.IndexOf(endDelim, at1 + beginDelim.Length, StringComparison.Ordinal)
                    : source.IndexOf(endDelim, at1, StringComparison.Ordinal);
            }
            else
            {
                at1 = source.IndexOf(beginDelim, 0, source.Length, StringComparison.OrdinalIgnoreCase);
                if (at1 == -1)
                    return string.Empty;

                at2 = !returnDelimiters
                    ? source.IndexOf(endDelim, at1 + beginDelim.Length, StringComparison.OrdinalIgnoreCase)
                    : source.IndexOf(endDelim, at1, StringComparison.OrdinalIgnoreCase);
            }
            if (allowMissingEndDelimiter && at2 == -1)
                return source.Substring(at1 + beginDelim.Length);

            if (at1 <= -1 || at2 <= 1) return string.Empty;
            return !returnDelimiters
                ? source.Substring(at1 + beginDelim.Length, at2 - at1 - beginDelim.Length)
                : source.Substring(at1, at2 - at1 + endDelim.Length);
        }
        public static IEnumerable<string> GetFileNames(this string path, string pattern, SearchOption options = SearchOption.AllDirectories)
        {
            foreach (var fileName in Directory.EnumerateFiles(path, pattern))
                yield return fileName;
        }
        public static IEnumerable<string> LoadLines(this string filepath)
        {
                using (FileStream stream = File.OpenRead(filepath))
                {
                    var reader = new StreamReader(stream);
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                        yield return line;
                }         
        }
        public static async Task<T> LoadAsTypeAsync<T>(this string filePath)
        {
            return await Task.Run(() =>
            {
                var json = File.ReadAllText(filePath);
                var obj = json.DeserializeObject<dynamic>();
                return obj;
            });
        }
        public static async Task<List<T>> LoadAsListTypeAsync<T>(this string filePath)
        {
            return await Task.Run(() =>
            {
                var json = File.ReadAllText(filePath);
                var obj = JsonConvert.DeserializeObject<List<T>>(json);
                return obj;
            });
        } 
        public static bool IsValidEmail(this string email)
        {          
            return Regex.IsMatch(email, RegExpExtensions.ValidEmailRegEx, RegexOptions.IgnoreCase);
        }
        public static bool IsNumber(this string numString)
        {
            long number1;
            return long.TryParse(numString, out number1);
        }
        public static object ReadFromJson(this string json, string messageType)
        {
            var type = Type.GetType(messageType);
            return JsonConvert.DeserializeObject(json, type);
        }
        public static string RemoveJsonNulls(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
            var regex = new Regex(RegExpExtensions.JsonNullRegEx);
            var data = regex.Replace(str, string.Empty);
            regex = new Regex(RegExpExtensions.JsonNullWithSpaceRegEx);
            data = regex.Replace(data, string.Empty);
            regex = new Regex(RegExpExtensions.JsonNullArrayRegEx);
            return regex.Replace(data, "[]");
        }
        public static int? TryParseInt(this string strInput)
        {
            int intString;
            var isParsed = int.TryParse(strInput, out intString);
            if (isParsed)
            {
                return intString;
            }
            return null;

        }
        public static decimal? TryParseDecimal(this string strInput)
        {
            decimal intString;
            var isParsed = decimal.TryParse(strInput, out intString);
            if (isParsed)
            {
                return intString;
            }
            return null;
        }

    }
}



