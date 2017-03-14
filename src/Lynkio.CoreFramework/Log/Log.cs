using Lynkio.CoreFramework.Extensions;
using System;
using System.Threading.Tasks;
using System.IO;
namespace Lynkio.CoreFramework
{
    public static class Log
    {
        public static Task Exception(string name, Exception exception) => Task.Run(async () =>
         {
             await Task.Run(async () =>
             {
                 var filePath = await GetFilePath(name, LogType.Exceptions);
                 var content = $"Name:{name}{Environment.NewLine}Exception: {exception.ToString()}";
                 File.WriteAllText(filePath, content);
             });
         });
        public static Task Error(string name, string strError) => Task.Run(async () =>
        {
            await Task.Run(async () =>
            {
                var filePath = await GetFilePath(name, LogType.Errors);
                var content = $"Name:{name}{Environment.NewLine}Error: {strError}";
                File.WriteAllText(filePath, content);
            });
        });
        public static Task Msg(string name, string strInformation) => Task.Run(async () =>
        {
            await Task.Run(async () =>
            {
                string filePath = await GetFilePath(name, LogType.Msgs);
                var content = $"Name:{name}{Environment.NewLine}Message: {strInformation}";
                File.WriteAllText(filePath, content);
            });
        });
        public static Task Warning(string name, string strWarningInfo) => Task.Run(async () =>
         {
             await Task.Run(async () =>
             {
                 var filePath = await GetFilePath(name, LogType.Warnings);
                 var content = $"Name:{name}{Environment.NewLine}Warning: {strWarningInfo}";
                 File.WriteAllText(filePath, content);
             });
         });
        private static Task<string> AddDatemeStringValues(string strName) => Task.Run(() => { return $"{strName}-{DateTime.Now:yyyy-MM-dd_hh-mm-ss-tt}"; });
        private static async Task<string> GetFilePath(string traceName, LogType traceType)
        {
            return await Task.Run(async () =>
            {
                var traceExtension = await GetFileExtension(traceType);
                var directoryPath = Path.Combine(Config.AppPath, "Logs", traceType.ToString());
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                traceName = traceName.ReplaceInvalidCharsForUnderscore();
                traceName = await AddDatemeStringValues(traceName);
                traceName = $"{traceName}{traceExtension}";
                var filePath = Path.Combine(directoryPath, traceName);
                return filePath;
            });
        }
        private static Task<string> GetFileExtension(LogType traceType)
        {
            return Task.Run(() =>
            {
                string traceExtension;
                switch (traceType)
                {
                    case LogType.Exceptions:
                        traceExtension = ".ex";
                        break;
                    case LogType.Errors:
                        traceExtension = ".err";
                        break;
                    case LogType.Msgs:
                        traceExtension = ".log";
                        break;
                    case LogType.Warnings:
                        traceExtension = ".warn";
                        break;
                    default:
                        traceExtension = ".unknown";
                        break;
                }
                return traceExtension;
            });
        }
    }
}
