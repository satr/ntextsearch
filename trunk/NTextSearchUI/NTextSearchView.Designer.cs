namespace NTextSearch{
    partial class NTextSearchView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTextSearchView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefreshPlugins = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxPluginProperties = new System.Windows.Forms.GroupBox();
            this.panelPlugin = new System.Windows.Forms.Panel();
            this.groupBoxPlugins = new System.Windows.Forms.GroupBox();
            this.comboBoxPlugins = new System.Windows.Forms.ComboBox();
            this.buttonRefreshPlugins = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderState = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFileName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTag = new System.Windows.Forms.ColumnHeader();
            this.panelTargetText = new System.Windows.Forms.Panel();
            this.groupBoxTargetText = new System.Windows.Forms.GroupBox();
            this.textBoxTargetText = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxFolderName = new System.Windows.Forms.GroupBox();
            this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.panelFolderName = new System.Windows.Forms.Panel();
            this.textBoxFolderName = new System.Windows.Forms.TextBox();
            this.buttonBrowseFolder = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelPlugin.SuspendLayout();
            this.groupBoxPlugins.SuspendLayout();
            this.panelTargetText.SuspendLayout();
            this.groupBoxTargetText.SuspendLayout();
            this.groupBoxFolderName.SuspendLayout();
            this.panelFolderName.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExit,
            this.toolStripButtonRefreshPlugins});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(695, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExit.Image")));
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExit.Text = "Exit";
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // toolStripButtonRefreshPlugins
            // 
            this.toolStripButtonRefreshPlugins.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefreshPlugins.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefreshPlugins.Image")));
            this.toolStripButtonRefreshPlugins.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefreshPlugins.Name = "toolStripButtonRefreshPlugins";
            this.toolStripButtonRefreshPlugins.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefreshPlugins.Text = "Refresh plugins";
            this.toolStripButtonRefreshPlugins.Click += new System.EventHandler(this.toolStripButtonRefreshPlugins_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 385);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(695, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainerMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 124);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(695, 261);
            this.panelMain.TabIndex = 3;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxPluginProperties);
            this.splitContainerMain.Panel1.Controls.Add(this.panelPlugin);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.listView);
            this.splitContainerMain.Size = new System.Drawing.Size(695, 261);
            this.splitContainerMain.SplitterDistance = 231;
            this.splitContainerMain.TabIndex = 0;
            // 
            // groupBoxPluginProperties
            // 
            this.groupBoxPluginProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPluginProperties.Location = new System.Drawing.Point(0, 42);
            this.groupBoxPluginProperties.Name = "groupBoxPluginProperties";
            this.groupBoxPluginProperties.Size = new System.Drawing.Size(231, 219);
            this.groupBoxPluginProperties.TabIndex = 1;
            this.groupBoxPluginProperties.TabStop = false;
            this.groupBoxPluginProperties.Text = "Search conditions";
            // 
            // panelPlugin
            // 
            this.panelPlugin.Controls.Add(this.groupBoxPlugins);
            this.panelPlugin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlugin.Location = new System.Drawing.Point(0, 0);
            this.panelPlugin.Name = "panelPlugin";
            this.panelPlugin.Size = new System.Drawing.Size(231, 42);
            this.panelPlugin.TabIndex = 0;
            // 
            // groupBoxPlugins
            // 
            this.groupBoxPlugins.Controls.Add(this.comboBoxPlugins);
            this.groupBoxPlugins.Controls.Add(this.buttonRefreshPlugins);
            this.groupBoxPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlugins.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlugins.Name = "groupBoxPlugins";
            this.groupBoxPlugins.Size = new System.Drawing.Size(231, 42);
            this.groupBoxPlugins.TabIndex = 0;
            this.groupBoxPlugins.TabStop = false;
            this.groupBoxPlugins.Text = "File type";
            // 
            // comboBoxPlugins
            // 
            this.comboBoxPlugins.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlugins.FormattingEnabled = true;
            this.comboBoxPlugins.Location = new System.Drawing.Point(3, 16);
            this.comboBoxPlugins.Name = "comboBoxPlugins";
            this.comboBoxPlugins.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPlugins.TabIndex = 4;
            this.toolTip.SetToolTip(this.comboBoxPlugins, "Select file type");
            this.comboBoxPlugins.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlugins_SelectedIndexChanged);
            // 
            // buttonRefreshPlugins
            // 
            this.buttonRefreshPlugins.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRefreshPlugins.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefreshPlugins.Image")));
            this.buttonRefreshPlugins.Location = new System.Drawing.Point(203, 16);
            this.buttonRefreshPlugins.Name = "buttonRefreshPlugins";
            this.buttonRefreshPlugins.Size = new System.Drawing.Size(25, 23);
            this.buttonRefreshPlugins.TabIndex = 3;
            this.buttonRefreshPlugins.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.buttonRefreshPlugins, "Refresh plugins");
            this.buttonRefreshPlugins.UseVisualStyleBackColor = true;
            this.buttonRefreshPlugins.Click += new System.EventHandler(this.buttonRefreshPlugins_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderState,
            this.columnHeaderFileName,
            this.columnHeaderTag});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(460, 261);
            this.listView.TabIndex = 0;
            this.toolTip.SetToolTip(this.listView, "Move cursor above status to see details");
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderState
            // 
            this.columnHeaderState.Text = "State";
            this.columnHeaderState.Width = 120;
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "File name";
            this.columnHeaderFileName.Width = 300;
            // 
            // columnHeaderTag
            // 
            this.columnHeaderTag.Text = "";
            this.columnHeaderTag.Width = 20;
            // 
            // panelTargetText
            // 
            this.panelTargetText.Controls.Add(this.groupBoxFolderName);
            this.panelTargetText.Controls.Add(this.groupBoxTargetText);
            this.panelTargetText.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTargetText.Location = new System.Drawing.Point(0, 25);
            this.panelTargetText.Name = "panelTargetText";
            this.panelTargetText.Size = new System.Drawing.Size(695, 99);
            this.panelTargetText.TabIndex = 1;
            // 
            // groupBoxTargetText
            // 
            this.groupBoxTargetText.Controls.Add(this.textBoxTargetText);
            this.groupBoxTargetText.Controls.Add(this.buttonSearch);
            this.groupBoxTargetText.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTargetText.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTargetText.Name = "groupBoxTargetText";
            this.groupBoxTargetText.Size = new System.Drawing.Size(695, 41);
            this.groupBoxTargetText.TabIndex = 4;
            this.groupBoxTargetText.TabStop = false;
            this.groupBoxTargetText.Text = "Target text";
            // 
            // textBoxTargetText
            // 
            this.textBoxTargetText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTargetText.Location = new System.Drawing.Point(3, 16);
            this.textBoxTargetText.Name = "textBoxTargetText";
            this.textBoxTargetText.Size = new System.Drawing.Size(614, 20);
            this.textBoxTargetText.TabIndex = 7;
            this.toolTip.SetToolTip(this.textBoxTargetText, "Type text to search");
            // 
            // buttonSearch
            // 
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSearch.Location = new System.Drawing.Point(617, 16);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 22);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // groupBoxFolderName
            // 
            this.groupBoxFolderName.Controls.Add(this.checkBoxRecursive);
            this.groupBoxFolderName.Controls.Add(this.panelFolderName);
            this.groupBoxFolderName.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFolderName.Location = new System.Drawing.Point(0, 41);
            this.groupBoxFolderName.Name = "groupBoxFolderName";
            this.groupBoxFolderName.Size = new System.Drawing.Size(695, 60);
            this.groupBoxFolderName.TabIndex = 5;
            this.groupBoxFolderName.TabStop = false;
            this.groupBoxFolderName.Text = "Folder";
            // 
            // checkBoxRecursive
            // 
            this.checkBoxRecursive.AutoSize = true;
            this.checkBoxRecursive.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxRecursive.Location = new System.Drawing.Point(3, 38);
            this.checkBoxRecursive.Name = "checkBoxRecursive";
            this.checkBoxRecursive.Size = new System.Drawing.Size(689, 17);
            this.checkBoxRecursive.TabIndex = 1;
            this.checkBoxRecursive.Text = "Recursive";
            this.checkBoxRecursive.UseVisualStyleBackColor = true;
            // 
            // panelFolderName
            // 
            this.panelFolderName.Controls.Add(this.textBoxFolderName);
            this.panelFolderName.Controls.Add(this.buttonBrowseFolder);
            this.panelFolderName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFolderName.Location = new System.Drawing.Point(3, 16);
            this.panelFolderName.Name = "panelFolderName";
            this.panelFolderName.Size = new System.Drawing.Size(689, 22);
            this.panelFolderName.TabIndex = 0;
            // 
            // textBoxFolderName
            // 
            this.textBoxFolderName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFolderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFolderName.Location = new System.Drawing.Point(0, 0);
            this.textBoxFolderName.Name = "textBoxFolderName";
            this.textBoxFolderName.ReadOnly = true;
            this.textBoxFolderName.Size = new System.Drawing.Size(614, 20);
            this.textBoxFolderName.TabIndex = 1;
            // 
            // buttonBrowseFolder
            // 
            this.buttonBrowseFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonBrowseFolder.Location = new System.Drawing.Point(614, 0);
            this.buttonBrowseFolder.Name = "buttonBrowseFolder";
            this.buttonBrowseFolder.Size = new System.Drawing.Size(75, 22);
            this.buttonBrowseFolder.TabIndex = 0;
            this.buttonBrowseFolder.Text = "Browse";
            this.buttonBrowseFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseFolder.Click += new System.EventHandler(this.buttonBrowseFolder_Click);
            // 
            // NTextSearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 407);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelTargetText);
            this.Controls.Add(this.toolStrip1);
            this.Name = "NTextSearchView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NTextSearch";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.panelPlugin.ResumeLayout(false);
            this.groupBoxPlugins.ResumeLayout(false);
            this.panelTargetText.ResumeLayout(false);
            this.groupBoxTargetText.ResumeLayout(false);
            this.groupBoxTargetText.PerformLayout();
            this.groupBoxFolderName.ResumeLayout(false);
            this.groupBoxFolderName.PerformLayout();
            this.panelFolderName.ResumeLayout(false);
            this.panelFolderName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefreshPlugins;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelPlugin;
        private System.Windows.Forms.GroupBox groupBoxPluginProperties;
        private System.Windows.Forms.Panel panelTargetText;
        private System.Windows.Forms.GroupBox groupBoxTargetText;
        private System.Windows.Forms.TextBox textBoxTargetText;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBoxPlugins;
        private System.Windows.Forms.ComboBox comboBoxPlugins;
        private System.Windows.Forms.Button buttonRefreshPlugins;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderState;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderTag;
        private System.Windows.Forms.GroupBox groupBoxFolderName;
        private System.Windows.Forms.CheckBox checkBoxRecursive;
        private System.Windows.Forms.Panel panelFolderName;
        private System.Windows.Forms.TextBox textBoxFolderName;
        private System.Windows.Forms.Button buttonBrowseFolder;

    }
}