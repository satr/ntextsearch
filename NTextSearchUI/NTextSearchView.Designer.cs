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
            this.groupBoxPlugins = new System.Windows.Forms.GroupBox();
            this.comboBoxPlugins = new System.Windows.Forms.ComboBox();
            this.buttonRefreshPlugins = new System.Windows.Forms.Button();
            this.panelFileProperties = new System.Windows.Forms.Panel();
            this.groupBoxFileAttributes = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFileAttributes = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxFileAttributeArchive = new System.Windows.Forms.CheckBox();
            this.checkBoxFileAttributeSystem = new System.Windows.Forms.CheckBox();
            this.checkBoxFileAttributeReadOnly = new System.Windows.Forms.CheckBox();
            this.checkBoxFileAttributeHidden = new System.Windows.Forms.CheckBox();
            this.buttonClearFileAttributes = new System.Windows.Forms.Button();
            this.groupBoxFileDate = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFileDate = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.checkBoxFileDateFromEnabled = new System.Windows.Forms.CheckBox();
            this.checkBoxFileDateToEnabled = new System.Windows.Forms.CheckBox();
            this.buttonFileDateClear = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderState = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFileName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTag = new System.Windows.Forms.ColumnHeader();
            this.panelTargetText = new System.Windows.Forms.Panel();
            this.groupBoxFolderName = new System.Windows.Forms.GroupBox();
            this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.panelFolderName = new System.Windows.Forms.Panel();
            this.textBoxFolderName = new System.Windows.Forms.TextBox();
            this.buttonBrowseFolder = new System.Windows.Forms.Button();
            this.groupBoxTargetText = new System.Windows.Forms.GroupBox();
            this.textBoxTargetText = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxPlugins.SuspendLayout();
            this.panelFileProperties.SuspendLayout();
            this.groupBoxFileAttributes.SuspendLayout();
            this.tableLayoutPanelFileAttributes.SuspendLayout();
            this.groupBoxFileDate.SuspendLayout();
            this.tableLayoutPanelFileDate.SuspendLayout();
            this.panelTargetText.SuspendLayout();
            this.groupBoxFolderName.SuspendLayout();
            this.panelFolderName.SuspendLayout();
            this.groupBoxTargetText.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExit,
            this.toolStripButtonRefreshPlugins});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(795, 25);
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
            // 
            // toolStripButtonRefreshPlugins
            // 
            this.toolStripButtonRefreshPlugins.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefreshPlugins.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefreshPlugins.Image")));
            this.toolStripButtonRefreshPlugins.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefreshPlugins.Name = "toolStripButtonRefreshPlugins";
            this.toolStripButtonRefreshPlugins.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefreshPlugins.Text = "Refresh plugins";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 432);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(795, 22);
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
            this.panelMain.Location = new System.Drawing.Point(0, 128);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(795, 304);
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
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxPlugins);
            this.splitContainerMain.Panel1.Controls.Add(this.panelFileProperties);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.listView);
            this.splitContainerMain.Size = new System.Drawing.Size(795, 304);
            this.splitContainerMain.SplitterDistance = 334;
            this.splitContainerMain.TabIndex = 0;
            // 
            // groupBoxPluginProperties
            // 
            this.groupBoxPluginProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPluginProperties.Location = new System.Drawing.Point(0, 139);
            this.groupBoxPluginProperties.Name = "groupBoxPluginProperties";
            this.groupBoxPluginProperties.Size = new System.Drawing.Size(334, 165);
            this.groupBoxPluginProperties.TabIndex = 10;
            this.groupBoxPluginProperties.TabStop = false;
            this.groupBoxPluginProperties.Text = "Search conditions";
            // 
            // groupBoxPlugins
            // 
            this.groupBoxPlugins.Controls.Add(this.comboBoxPlugins);
            this.groupBoxPlugins.Controls.Add(this.buttonRefreshPlugins);
            this.groupBoxPlugins.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPlugins.Location = new System.Drawing.Point(0, 97);
            this.groupBoxPlugins.Name = "groupBoxPlugins";
            this.groupBoxPlugins.Size = new System.Drawing.Size(334, 42);
            this.groupBoxPlugins.TabIndex = 9;
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
            this.comboBoxPlugins.Size = new System.Drawing.Size(303, 21);
            this.comboBoxPlugins.TabIndex = 4;
            this.toolTip.SetToolTip(this.comboBoxPlugins, "Select file type");
            // 
            // buttonRefreshPlugins
            // 
            this.buttonRefreshPlugins.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRefreshPlugins.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefreshPlugins.Image")));
            this.buttonRefreshPlugins.Location = new System.Drawing.Point(306, 16);
            this.buttonRefreshPlugins.Name = "buttonRefreshPlugins";
            this.buttonRefreshPlugins.Size = new System.Drawing.Size(25, 23);
            this.buttonRefreshPlugins.TabIndex = 3;
            this.buttonRefreshPlugins.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.buttonRefreshPlugins, "Refresh plugins");
            this.buttonRefreshPlugins.UseVisualStyleBackColor = true;
            // 
            // panelFileProperties
            // 
            this.panelFileProperties.Controls.Add(this.groupBoxFileAttributes);
            this.panelFileProperties.Controls.Add(this.groupBoxFileDate);
            this.panelFileProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileProperties.Location = new System.Drawing.Point(0, 0);
            this.panelFileProperties.Name = "panelFileProperties";
            this.panelFileProperties.Size = new System.Drawing.Size(334, 97);
            this.panelFileProperties.TabIndex = 0;
            // 
            // groupBoxFileAttributes
            // 
            this.groupBoxFileAttributes.Controls.Add(this.tableLayoutPanelFileAttributes);
            this.groupBoxFileAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFileAttributes.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFileAttributes.Name = "groupBoxFileAttributes";
            this.groupBoxFileAttributes.Size = new System.Drawing.Size(172, 97);
            this.groupBoxFileAttributes.TabIndex = 8;
            this.groupBoxFileAttributes.TabStop = false;
            this.groupBoxFileAttributes.Text = "File attributes";
            // 
            // tableLayoutPanelFileAttributes
            // 
            this.tableLayoutPanelFileAttributes.ColumnCount = 2;
            this.tableLayoutPanelFileAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanelFileAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanelFileAttributes.Controls.Add(this.checkBoxFileAttributeArchive, 0, 1);
            this.tableLayoutPanelFileAttributes.Controls.Add(this.checkBoxFileAttributeSystem, 1, 1);
            this.tableLayoutPanelFileAttributes.Controls.Add(this.checkBoxFileAttributeReadOnly, 0, 0);
            this.tableLayoutPanelFileAttributes.Controls.Add(this.checkBoxFileAttributeHidden, 1, 0);
            this.tableLayoutPanelFileAttributes.Controls.Add(this.buttonClearFileAttributes, 0, 2);
            this.tableLayoutPanelFileAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFileAttributes.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelFileAttributes.Name = "tableLayoutPanelFileAttributes";
            this.tableLayoutPanelFileAttributes.RowCount = 3;
            this.tableLayoutPanelFileAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelFileAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelFileAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelFileAttributes.Size = new System.Drawing.Size(166, 78);
            this.tableLayoutPanelFileAttributes.TabIndex = 4;
            // 
            // checkBoxFileAttributeArchive
            // 
            this.checkBoxFileAttributeArchive.AutoSize = true;
            this.checkBoxFileAttributeArchive.Checked = true;
            this.checkBoxFileAttributeArchive.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBoxFileAttributeArchive.Location = new System.Drawing.Point(3, 29);
            this.checkBoxFileAttributeArchive.Name = "checkBoxFileAttributeArchive";
            this.checkBoxFileAttributeArchive.Size = new System.Drawing.Size(62, 17);
            this.checkBoxFileAttributeArchive.TabIndex = 1;
            this.checkBoxFileAttributeArchive.Text = "Archive";
            this.checkBoxFileAttributeArchive.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileAttributeSystem
            // 
            this.checkBoxFileAttributeSystem.AutoSize = true;
            this.checkBoxFileAttributeSystem.Checked = true;
            this.checkBoxFileAttributeSystem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBoxFileAttributeSystem.Location = new System.Drawing.Point(86, 29);
            this.checkBoxFileAttributeSystem.Name = "checkBoxFileAttributeSystem";
            this.checkBoxFileAttributeSystem.Size = new System.Drawing.Size(60, 17);
            this.checkBoxFileAttributeSystem.TabIndex = 3;
            this.checkBoxFileAttributeSystem.Text = "System";
            this.checkBoxFileAttributeSystem.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileAttributeReadOnly
            // 
            this.checkBoxFileAttributeReadOnly.AutoSize = true;
            this.checkBoxFileAttributeReadOnly.Checked = true;
            this.checkBoxFileAttributeReadOnly.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBoxFileAttributeReadOnly.Location = new System.Drawing.Point(3, 3);
            this.checkBoxFileAttributeReadOnly.Name = "checkBoxFileAttributeReadOnly";
            this.checkBoxFileAttributeReadOnly.Size = new System.Drawing.Size(74, 17);
            this.checkBoxFileAttributeReadOnly.TabIndex = 0;
            this.checkBoxFileAttributeReadOnly.Text = "Read only";
            this.checkBoxFileAttributeReadOnly.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileAttributeHidden
            // 
            this.checkBoxFileAttributeHidden.AutoSize = true;
            this.checkBoxFileAttributeHidden.Checked = true;
            this.checkBoxFileAttributeHidden.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBoxFileAttributeHidden.Location = new System.Drawing.Point(86, 3);
            this.checkBoxFileAttributeHidden.Name = "checkBoxFileAttributeHidden";
            this.checkBoxFileAttributeHidden.Size = new System.Drawing.Size(60, 17);
            this.checkBoxFileAttributeHidden.TabIndex = 2;
            this.checkBoxFileAttributeHidden.Text = "Hidden";
            this.checkBoxFileAttributeHidden.UseVisualStyleBackColor = true;
            // 
            // buttonClearFileAttributes
            // 
            this.buttonClearFileAttributes.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClearFileAttributes.Location = new System.Drawing.Point(41, 55);
            this.buttonClearFileAttributes.Name = "buttonClearFileAttributes";
            this.buttonClearFileAttributes.Size = new System.Drawing.Size(39, 20);
            this.buttonClearFileAttributes.TabIndex = 4;
            this.buttonClearFileAttributes.Text = "Clear";
            this.buttonClearFileAttributes.UseVisualStyleBackColor = true;
            // 
            // groupBoxFileDate
            // 
            this.groupBoxFileDate.Controls.Add(this.tableLayoutPanelFileDate);
            this.groupBoxFileDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxFileDate.Location = new System.Drawing.Point(172, 0);
            this.groupBoxFileDate.Name = "groupBoxFileDate";
            this.groupBoxFileDate.Size = new System.Drawing.Size(162, 97);
            this.groupBoxFileDate.TabIndex = 7;
            this.groupBoxFileDate.TabStop = false;
            this.groupBoxFileDate.Text = "File date";
            // 
            // tableLayoutPanelFileDate
            // 
            this.tableLayoutPanelFileDate.ColumnCount = 3;
            this.tableLayoutPanelFileDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelFileDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFileDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanelFileDate.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelFileDate.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelFileDate.Controls.Add(this.dateTimePickerFrom, 1, 0);
            this.tableLayoutPanelFileDate.Controls.Add(this.dateTimePickerTo, 1, 1);
            this.tableLayoutPanelFileDate.Controls.Add(this.checkBoxFileDateFromEnabled, 2, 0);
            this.tableLayoutPanelFileDate.Controls.Add(this.checkBoxFileDateToEnabled, 2, 1);
            this.tableLayoutPanelFileDate.Controls.Add(this.buttonFileDateClear, 1, 2);
            this.tableLayoutPanelFileDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFileDate.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelFileDate.Name = "tableLayoutPanelFileDate";
            this.tableLayoutPanelFileDate.RowCount = 3;
            this.tableLayoutPanelFileDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelFileDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelFileDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelFileDate.Size = new System.Drawing.Size(156, 78);
            this.tableLayoutPanelFileDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateTimePickerFrom.Enabled = false;
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(43, 3);
            this.dateTimePickerFrom.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(78, 20);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateTimePickerTo.Enabled = false;
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(43, 28);
            this.dateTimePickerTo.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(78, 20);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // checkBoxFileDateFromEnabled
            // 
            this.checkBoxFileDateFromEnabled.AutoSize = true;
            this.checkBoxFileDateFromEnabled.Location = new System.Drawing.Point(127, 3);
            this.checkBoxFileDateFromEnabled.Name = "checkBoxFileDateFromEnabled";
            this.checkBoxFileDateFromEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFileDateFromEnabled.TabIndex = 4;
            this.checkBoxFileDateFromEnabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileDateToEnabled
            // 
            this.checkBoxFileDateToEnabled.AutoSize = true;
            this.checkBoxFileDateToEnabled.Location = new System.Drawing.Point(127, 28);
            this.checkBoxFileDateToEnabled.Name = "checkBoxFileDateToEnabled";
            this.checkBoxFileDateToEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFileDateToEnabled.TabIndex = 5;
            this.checkBoxFileDateToEnabled.UseVisualStyleBackColor = true;
            // 
            // buttonFileDateClear
            // 
            this.buttonFileDateClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonFileDateClear.Location = new System.Drawing.Point(43, 54);
            this.buttonFileDateClear.Name = "buttonFileDateClear";
            this.buttonFileDateClear.Size = new System.Drawing.Size(39, 21);
            this.buttonFileDateClear.TabIndex = 6;
            this.buttonFileDateClear.Text = "Clear";
            this.buttonFileDateClear.UseVisualStyleBackColor = true;
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
            this.listView.Size = new System.Drawing.Size(457, 304);
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
            this.panelTargetText.Size = new System.Drawing.Size(795, 103);
            this.panelTargetText.TabIndex = 1;
            // 
            // groupBoxFolderName
            // 
            this.groupBoxFolderName.Controls.Add(this.checkBoxRecursive);
            this.groupBoxFolderName.Controls.Add(this.panelFolderName);
            this.groupBoxFolderName.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFolderName.Location = new System.Drawing.Point(0, 41);
            this.groupBoxFolderName.Name = "groupBoxFolderName";
            this.groupBoxFolderName.Size = new System.Drawing.Size(795, 60);
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
            this.checkBoxRecursive.Size = new System.Drawing.Size(789, 17);
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
            this.panelFolderName.Size = new System.Drawing.Size(789, 22);
            this.panelFolderName.TabIndex = 0;
            // 
            // textBoxFolderName
            // 
            this.textBoxFolderName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFolderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFolderName.Location = new System.Drawing.Point(0, 0);
            this.textBoxFolderName.Name = "textBoxFolderName";
            this.textBoxFolderName.ReadOnly = true;
            this.textBoxFolderName.Size = new System.Drawing.Size(714, 20);
            this.textBoxFolderName.TabIndex = 1;
            // 
            // buttonBrowseFolder
            // 
            this.buttonBrowseFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonBrowseFolder.Location = new System.Drawing.Point(714, 0);
            this.buttonBrowseFolder.Name = "buttonBrowseFolder";
            this.buttonBrowseFolder.Size = new System.Drawing.Size(75, 22);
            this.buttonBrowseFolder.TabIndex = 0;
            this.buttonBrowseFolder.Text = "Browse";
            this.buttonBrowseFolder.UseVisualStyleBackColor = true;
            // 
            // groupBoxTargetText
            // 
            this.groupBoxTargetText.Controls.Add(this.textBoxTargetText);
            this.groupBoxTargetText.Controls.Add(this.buttonSearch);
            this.groupBoxTargetText.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTargetText.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTargetText.Name = "groupBoxTargetText";
            this.groupBoxTargetText.Size = new System.Drawing.Size(795, 41);
            this.groupBoxTargetText.TabIndex = 4;
            this.groupBoxTargetText.TabStop = false;
            this.groupBoxTargetText.Text = "Target text";
            // 
            // textBoxTargetText
            // 
            this.textBoxTargetText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTargetText.Location = new System.Drawing.Point(3, 16);
            this.textBoxTargetText.Name = "textBoxTargetText";
            this.textBoxTargetText.Size = new System.Drawing.Size(714, 20);
            this.textBoxTargetText.TabIndex = 7;
            this.toolTip.SetToolTip(this.textBoxTargetText, "Type text to search");
            // 
            // buttonSearch
            // 
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(717, 16);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 22);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // NTextSearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 454);
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
            this.groupBoxPlugins.ResumeLayout(false);
            this.panelFileProperties.ResumeLayout(false);
            this.groupBoxFileAttributes.ResumeLayout(false);
            this.tableLayoutPanelFileAttributes.ResumeLayout(false);
            this.tableLayoutPanelFileAttributes.PerformLayout();
            this.groupBoxFileDate.ResumeLayout(false);
            this.tableLayoutPanelFileDate.ResumeLayout(false);
            this.tableLayoutPanelFileDate.PerformLayout();
            this.panelTargetText.ResumeLayout(false);
            this.groupBoxFolderName.ResumeLayout(false);
            this.groupBoxFolderName.PerformLayout();
            this.panelFolderName.ResumeLayout(false);
            this.panelFolderName.PerformLayout();
            this.groupBoxTargetText.ResumeLayout(false);
            this.groupBoxTargetText.PerformLayout();
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
        private System.Windows.Forms.Panel panelTargetText;
        private System.Windows.Forms.GroupBox groupBoxTargetText;
        private System.Windows.Forms.TextBox textBoxTargetText;
        private System.Windows.Forms.Button buttonSearch;
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
        private System.Windows.Forms.GroupBox groupBoxPluginProperties;
        private System.Windows.Forms.GroupBox groupBoxPlugins;
        private System.Windows.Forms.ComboBox comboBoxPlugins;
        private System.Windows.Forms.Button buttonRefreshPlugins;
        private System.Windows.Forms.Panel panelFileProperties;
        private System.Windows.Forms.GroupBox groupBoxFileAttributes;
        private System.Windows.Forms.CheckBox checkBoxFileAttributeSystem;
        private System.Windows.Forms.CheckBox checkBoxFileAttributeHidden;
        private System.Windows.Forms.CheckBox checkBoxFileAttributeArchive;
        private System.Windows.Forms.CheckBox checkBoxFileAttributeReadOnly;
        private System.Windows.Forms.GroupBox groupBoxFileDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFileDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFileAttributes;
        private System.Windows.Forms.CheckBox checkBoxFileDateFromEnabled;
        private System.Windows.Forms.CheckBox checkBoxFileDateToEnabled;
        private System.Windows.Forms.Button buttonClearFileAttributes;
        private System.Windows.Forms.Button buttonFileDateClear;

    }
}