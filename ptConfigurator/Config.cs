using System.Collections.Generic;
using System.IO;

namespace ptConfigurator
{
    static class Config
    {
        private static string SettingsFilePath()
        {
            string strPath = System.Environment.GetEnvironmentVariable("APPDATA");
            if (!strPath.EndsWith("\\")) strPath += "\\";
            strPath += "ptConfigurator\\";
            if (!Directory.Exists(strPath))
                Directory.CreateDirectory(strPath);
            return strPath + "settings.txt";
        }

        public static void SaveSetting(string key, string value)
        {
            try
            {
                string path = SettingsFilePath();
                Dictionary<string, string> settings = LoadAllSettings();
                settings[key] = value;

                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    foreach (var kvp in settings)
                        sw.WriteLine(kvp.Key + "=" + kvp.Value);
                }
            }
            catch { }
        }

        public static string LoadSetting(string key, string defaultValue = "")
        {
            try
            {
                Dictionary<string, string> settings = LoadAllSettings();
                if (settings.ContainsKey(key))
                    return settings[key];
            }
            catch { }
            return defaultValue;
        }

        private static Dictionary<string, string> LoadAllSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            string path = SettingsFilePath();
            if (!File.Exists(path)) return settings;

            foreach (string line in File.ReadAllLines(path))
            {
                int idx = line.IndexOf('=');
                if (idx > 0)
                    settings[line.Substring(0, idx).Trim()] = line.Substring(idx + 1).Trim();
            }
            return settings;
        }
    }
}
