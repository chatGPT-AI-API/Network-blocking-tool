namespace NetBlocker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rulesListView = new System.Windows.Forms.ListView();
            this.ruleNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.appPathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // rulesListView
            this.rulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ruleNameColumn,
            this.appPathColumn});
            this.rulesListView.FullRowSelect = true;
            this.rulesListView.GridLines = true;
            this.rulesListView.Location = new System.Drawing.Point(12, 12);
            this.rulesListView.Name = "rulesListView";
            this.rulesListView.Size = new System.Drawing.Size(560, 300);
            this.rulesListView.TabIndex = 0;
            this.rulesListView.UseCompatibleStateImageBehavior = false;
            this.rulesListView.View = System.Windows.Forms.View.Details;
            
            // ruleNameColumn
            this.ruleNameColumn.Text = "规则名称";
            this.ruleNameColumn.Width = 150;
            
            // appPathColumn
            this.appPathColumn.Text = "应用路径";
            this.appPathColumn.Width = 380;
            
            // addButton
            this.addButton.Location = new System.Drawing.Point(12, 318);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 30);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "添加规则";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            
            // removeButton
            this.removeButton.Location = new System.Drawing.Point(118, 318);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(100, 30);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "删除规则";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            
            // importButton
            this.importButton.Location = new System.Drawing.Point(362, 318);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(100, 30);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "导入规则";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            
            // exportButton
            this.exportButton.Location = new System.Drawing.Point(472, 318);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 30);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "导出规则";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.rulesListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网络阻断工具";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListView rulesListView;
        private System.Windows.Forms.ColumnHeader ruleNameColumn;
        private System.Windows.Forms.ColumnHeader appPathColumn;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
    }
}