using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NetBlocker
{
    public class AppConfig
    {
        private const string ConfigFile = "netblocker_config.json";
        private Dictionary<string, string> _rules = new Dictionary<string, string>();

        public AppConfig()
        {
            LoadConfig();
        }

        public void AddRule(string ruleName, string appPath)
        {
            if (!_rules.ContainsKey(ruleName))
            {
                _rules[ruleName] = appPath;
                SaveConfig();
            }
        }

        public void RemoveRule(string ruleName)
        {
            if (_rules.ContainsKey(ruleName))
            {
                _rules.Remove(ruleName);
                SaveConfig();
            }
        }

        public Dictionary<string, string> GetAllRules()
        {
            return new Dictionary<string, string>(_rules);
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigFile))
                {
                    var json = File.ReadAllText(ConfigFile);
                    _rules = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"加载配置失败: {ex.Message}");
            }
        }

        private void SaveConfig()
        {
            try
            {
                var json = JsonSerializer.Serialize(_rules);
                File.WriteAllText(ConfigFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"保存配置失败: {ex.Message}");
            }
        }
    }
}