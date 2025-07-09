using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        var ruleName = parts[0].Trim();
                        var appPath = parts[1].Trim();
                        
                        if (File.Exists(appPath))
                        {
                            _firewallManager.AddRule(ruleName, appPath);
                            _appConfig.AddRule(ruleName, appPath);
                        }
                    }
                }
                Console.WriteLine($"成功导入 {lines.Length} 条规则");
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
                var lines = rules.Select(r => $"{r.Key}|{r.Value}");
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"成功导出 {rules.Count} 条规则");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"导出规则失败: {ex.Message}");
            }
        }

        public bool ValidateRule(string appPath)
        {
            return File.Exists(appPath);
        }

        public List<string> FindApplications(string partialPath)
        {
            try
            {
                var dir = Path.GetDirectoryName(partialPath);
                var file = Path.GetFileName(partialPath);
                
                if (Directory.Exists(dir))
                {
                    return Directory.GetFiles(dir, $"{file}*")
                        .Where(p => p.EndsWith(".exe"))
                        .ToList();
                }
            }
            catch { }
            return new List<string>();
        }
    }
}