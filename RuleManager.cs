using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NetBlocker
{
    public class RuleManager
    {
        private readonly FirewallManager _firewallManager;
        private readonly AppConfig _appConfig;

        public RuleManager(FirewallManager firewallManager, AppConfig appConfig)
        {
            _firewallManager = firewallManager;
            _appConfig = appConfig;
        }

        public void ImportRules(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                var rules = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                
                if (rules != null)
                {
                    foreach (var rule in rules)
                    {
                        _firewallManager.AddRule(rule.Key, rule.Value);
                        _appConfig.AddRule(rule.Key, rule.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"导入规则失败: {ex.Message}");
            }
        }

        public void ExportRules(string filePath)
        {
            try
            {
                var rules = _appConfig.GetAllRules();
                var json = JsonSerializer.Serialize(rules);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"导出规则失败: {ex.Message}");
            }
        }
    }
}