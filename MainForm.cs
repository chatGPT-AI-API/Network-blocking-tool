using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace NetBlocker
{
    public partial class MainForm : Form
    {
        private readonly FirewallManager _firewallManager;
        private readonly AppConfig _appConfig;
        private readonly RuleManager _ruleManager;

        public MainForm()
        {
            InitializeComponent();
            
            _firewallManager = new FirewallManager();
            _appConfig = new AppConfig();
            _ruleManager = new RuleManager(_firewallManager, _appConfig);
            
            LoadRules();
        }

        private void LoadRules()
        {
            rulesListView.Items.Clear();
            foreach (var rule in _appConfig.GetAllRules())
            {
                rulesListView.Items.Add(new ListViewItem(new[] { rule.Key, rule.Value }));
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddRuleDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _firewallManager.AddRule(dialog.RuleName, dialog.AppPath);
                    _appConfig.AddRule(dialog.RuleName, dialog.AppPath);
                    LoadRules();
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (rulesListView.SelectedItems.Count > 0)
            {
                var ruleName = rulesListView.SelectedItems[0].Text;
                _firewallManager.RemoveRule(ruleName);
                _appConfig.RemoveRule(ruleName);
                LoadRules();
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "规则文件|*.rules|所有文件|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _ruleManager.ImportRules(dialog.FileName);
                    LoadRules();
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "规则文件|*.rules|所有文件|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _ruleManager.ExportRules(dialog.FileName);
                }
            }
        }
    }
}