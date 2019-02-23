using IniParser;
using IniParser.Model;
using System;
using System.IO;

namespace SVN.Config.Ini
{
    public class Ini
    {
        public static IniData ReadFile(params string[] files)
        {
            var fidp = new FileIniDataParser();
            var data = new IniData();
            
            foreach (var file in files)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);

                if (!File.Exists(path))
                {
                    continue;
                }

                var tmp = fidp.ReadFile(path);
                data.Merge(tmp);
            }

            return data;
        }
    }
}