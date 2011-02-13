using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NTextSearch{
    public partial class NTextSearchView : Form, ITextSearchView {
        private const string INIT_FOLDER_NAME = @"C:\NSearchButtonTestFiles";
        private readonly FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();

        public NTextSearchView() {
            InitializeComponent();
            InitPresenter();
            InitFolderBrowser();
            SetStatus(string.Empty);
            buttonSearch.Enabled = false;
            checkBoxRecursive.Checked = Presenter.Recusive;
            Bind();
        }

        private void Bind(){
            toolStripButtonExit.Click += toolStripButtonExit_Click;
            toolStripButtonRefreshPlugins.Click += toolStripButtonRefreshPlugins_Click;
            comboBoxPlugins.SelectedIndexChanged += comboBoxPlugins_SelectedIndexChanged;
            buttonRefreshPlugins.Click += buttonRefreshPlugins_Click;
            buttonBrowseFolder.Click += buttonBrowseFolder_Click;
            buttonSearch.Click += buttonSearch_Click;
            checkBoxRecursive.CheckedChanged += checkBoxRecursive_CheckedChanged;
        }

        private void checkBoxRecursive_CheckedChanged(object sender, EventArgs e) {
            Presenter.Recusive = ((CheckBox)sender).Checked;
        }

        private void InitFolderBrowser(){
            _folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            _folderBrowserDialog.SelectedPath = Presenter.FolderName;
            SetFolderName();
        }

        private void InitPresenter(){
            Presenter = new NTextSearchPresenter(this, INIT_FOLDER_NAME);
            Presenter.OnSearchEnabled += (src, args) => buttonSearch.Enabled = args.Enable;
            Presenter.OnAddListItem += (src, args) => listView.Items.Add(args.ListViewItem);
        }

        private ITextSearchPresenter Presenter { get; set; }

        protected override void OnLoad(EventArgs e){
            base.OnLoad(e);
            Presenter.RefreshPlugins();
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e) {
            Presenter.Exit();
        }

        private void toolStripButtonRefreshPlugins_Click(object sender, EventArgs e) {
            Presenter.RefreshPlugins();
        }

        private void buttonRefreshPlugins_Click(object sender, EventArgs e) {
            Presenter.RefreshPlugins();
        }

        public void RefreshPlugins(List<ITextSearch> plugins){
            comboBoxPlugins.SuspendLayout();
            comboBoxPlugins.DataSource = null;
            comboBoxPlugins.DataSource = plugins;
            comboBoxPlugins.DisplayMember = "Title";
            comboBoxPlugins.ResumeLayout(true);
            if (plugins.Count > 0)
                comboBoxPlugins.SelectedIndex = 0;
        }

        public void SetStatus(string message){
            toolStripStatusLabel.Text = message;
        }

        public void ClearList(){
            listView.Items.Clear();
        }

        private void buttonSearch_Click(object sender, EventArgs e) {
            Presenter.PerformSearch(textBoxTargetText.Text);
        }

        private void comboBoxPlugins_SelectedIndexChanged(object sender, EventArgs e) {
            Presenter.SelectPlugin((ITextSearch) comboBoxPlugins.SelectedItem);
        }

        private void buttonBrowseFolder_Click(object sender, EventArgs e){
            if (_folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                return;
            SetFolderName();
        }

        private void SetFolderName(){
            var folderName  = textBoxFolderName.Text = _folderBrowserDialog.SelectedPath;
            Presenter.FolderName = folderName;
        }
    }
}