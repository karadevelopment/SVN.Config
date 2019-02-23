using IniParser;
using IniParser.Model;
using System;

namespace SVN.Config.Ini
{
    public static class Extensions
    {
        public static void WriteFile(this IniData param, string path)
        {
            var fidp = new FileIniDataParser();
            fidp.WriteFile(path, param);
        }

        public static T Get<T>(this IniData param, object section, object key)
        {
            if (param is null)
            {
                return default(T);
            }

            var k = param[section.ToString()];
            var v = k[key.ToString()];

            if (v is null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(v, typeof(T));
        }
    }
}