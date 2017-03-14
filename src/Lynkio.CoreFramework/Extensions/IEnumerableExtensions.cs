using System.Collections.Generic;
using System.IO;
namespace Lynkio.CoreFramework.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<string> LoadLinesFromFiles(this IEnumerable<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    var reader = new StreamReader(stream);
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }
        public static IEnumerable<string> GetWords(this IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                string[] words = line.Split(' ', ';', '(', ')', '{', '}', '.', ',');
                foreach (var word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                        yield return word;
                }
            }
        }

    }
}
