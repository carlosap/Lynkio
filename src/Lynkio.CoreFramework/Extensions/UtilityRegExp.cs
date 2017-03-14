namespace Lynkio.CoreFramework.Extensions.RegExp
{
    public static class RegExpExtensions
    {
        public static string JsonNullRegEx = "[\"][a-zA-Z0-9_]*[\"]:null[ ]*[,]?";
        public static string JsonNullWithSpaceRegEx = "[\"][a-zA-Z0-9_]*[\"]: null[ ]*[,]?";
        public static string JsonNullArrayRegEx = "\\[( *null *,? *)*]";
        public static string ValidEmailRegEx = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
    }
}

