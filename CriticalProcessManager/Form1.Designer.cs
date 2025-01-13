
namespace CriticalProcessManager
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.processListView = new System.Windows.Forms.ListView();
            this.processNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processIDHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.attributesHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.criticalProcessToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.normalProcessToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.killToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.reloadButton = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.listViewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // processListView
            // 
            this.processListView.BackColor = System.Drawing.SystemColors.Info;
            this.processListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processNameHeader,
            this.processIDHeader,
            this.attributesHeader});
            this.processListView.ContextMenuStrip = this.listViewContextMenu;
            this.processListView.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.processListView.FullRowSelect = true;
            this.processListView.GridLines = true;
            this.processListView.HideSelection = false;
            this.processListView.Location = new System.Drawing.Point(13, 42);
            this.processListView.Margin = new System.Windows.Forms.Padding(4);
            this.processListView.Name = "processListView";
            this.processListView.Size = new System.Drawing.Size(363, 494);
            this.processListView.TabIndex = 3;
            this.processListView.UseCompatibleStateImageBehavior = false;
            this.processListView.View = System.Windows.Forms.View.Details;
            // 
            // processNameHeader
            // 
            this.processNameHeader.Text = "Process Name";
            this.processNameHeader.Width = 200;
            // 
            // processIDHeader
            // 
            this.processIDHeader.Text = "Process ID";
            this.processIDHeader.Width = 70;
            // 
            // attributesHeader
            // 
            this.attributesHeader.Text = "Attributes";
            this.attributesHeader.Width = 80;
            // 
            // listViewContextMenu
            // 
            this.listViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.criticalProcessToolStrip,
            this.normalProcessToolStrip,
            this.toolStripSeparator1,
            this.killToolStrip,
            this.toolStripSeparator2,
            this.reloadToolStrip,
            this.createToolStrip});
            this.listViewContextMenu.Name = "listViewContextMenu";
            this.listViewContextMenu.Size = new System.Drawing.Size(217, 126);
            // 
            // criticalProcessToolStrip
            // 
            this.criticalProcessToolStrip.Name = "criticalProcessToolStrip";
            this.criticalProcessToolStrip.Size = new System.Drawing.Size(216, 22);
            this.criticalProcessToolStrip.Text = "Set As Critical Process";
            this.criticalProcessToolStrip.Click += new System.EventHandler(this.criticalProcessToolStrip_Click);
            // 
            // normalProcessToolStrip
            // 
            this.normalProcessToolStrip.Name = "normalProcessToolStrip";
            this.normalProcessToolStrip.Size = new System.Drawing.Size(216, 22);
            this.normalProcessToolStrip.Text = "Set As Normal Process";
            this.normalProcessToolStrip.Click += new System.EventHandler(this.normalProcessToolStrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // killToolStrip
            // 
            this.killToolStrip.Name = "killToolStrip";
            this.killToolStrip.Size = new System.Drawing.Size(216, 22);
            this.killToolStrip.Text = "Kill Critical Process";
            this.killToolStrip.Click += new System.EventHandler(this.killToolStrip_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // reloadToolStrip
            // 
            this.reloadToolStrip.Name = "reloadToolStrip";
            this.reloadToolStrip.Size = new System.Drawing.Size(216, 22);
            this.reloadToolStrip.Text = "Reload Process List";
            this.reloadToolStrip.Click += new System.EventHandler(this.reloadToolStrip_Click);
            // 
            // createToolStrip
            // 
            this.createToolStrip.Name = "createToolStrip";
            this.createToolStrip.Size = new System.Drawing.Size(216, 22);
            this.createToolStrip.Text = "Create New Critical Process";
            this.createToolStrip.Click += new System.EventHandler(this.createToolStrip_Click);
            // 
            // filterComboBox
            // 
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "None",
            "Critical Process",
            "Normal Process"});
            this.filterComboBox.Location = new System.Drawing.Point(256, 12);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(121, 23);
            this.filterComboBox.TabIndex = 4;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // reloadButton
            // 
            this.reloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reloadButton.Location = new System.Drawing.Point(12, 12);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(135, 23);
            this.reloadButton.TabIndex = 5;
            this.reloadButton.Text = "Reload Process List";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(214, 16);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(36, 15);
            this.filterLabel.TabIndex = 6;
            this.filterLabel.Text = "Filter:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 549);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.processListView);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Critical Process Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.listViewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader processNameHeader;
        private System.Windows.Forms.ColumnHeader processIDHeader;
        private System.Windows.Forms.ColumnHeader attributesHeader;
        private System.Windows.Forms.ListView processListView;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem criticalProcessToolStrip;
        private System.Windows.Forms.ToolStripMenuItem normalProcessToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem killToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStrip;
        private System.Windows.Forms.ToolStripMenuItem createToolStrip;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Label filterLabel;
    }
}

