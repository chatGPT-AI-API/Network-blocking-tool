using System;
using System.Diagnostics;

namespace NetBlocker
{
    public class FirewallManager
    {
        public void AddRule(string ruleName, string applicationPath)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = $"advfirewall firewall add rule name=\"{ruleName}\" dir=out program=\"{applicationPath}\" action=block";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
                
                Console.WriteLine($"已添加规则: {ruleName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"添加规则失败: {ex.Message}");
            }
        }

        public void RemoveRule(string ruleName)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = $"advfirewall firewall delete rule name=\"{ruleName}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
                
                Console.WriteLine($"已删除规则: {ruleName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"删除规则失败: {ex.Message}");
            }
        }

        public void ListRules()
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = "advfirewall firewall show rule name=all";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                
                var output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                
                Console.WriteLine("当前防火墙规则:");
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取规则列表失败: {ex.Message}");
            }
        }
    }
}