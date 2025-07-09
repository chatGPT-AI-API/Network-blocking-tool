using System;
using System.Windows.Forms;

namespace NetBlocker
{
    public partial class AddRuleDialog : Form
    {
        public string RuleName => nameTextBox.Text;
        public string AppPath => pathTextBox.Text;

        public AddRuleDialog()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "应用程序|*.exe|所有文件|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pathTextBox.Text = dialog.FileName;
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RuleName))
            {
                MessageBox.Show("请输入规则名称");
                return;
            }

            if (string.IsNullOrWhiteSpace(AppPath))
            {
                MessageBox.Show("请选择应用程序路径");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}