using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NTextSearch{
    public partial class NTextSearchView : Form, ITextSearchView {
        private const string INIT_FOLDER_NAME = @"C:\NSearchButtonTestFiles";
        private readonly FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
        private List<CheckBox> _fileAttributesControls;
        private bool _searchInProcess;
        private ITextSearchPresenter Presenter { get; set; }

        public NTextSearchView() {
            InitializeComponent();
            var folderName = GetInitFolderName();
            InitPresenter(folderName);
            InitFolderBrowser(folderName);
            InitFilePropertiesDate();
            InitFileAttributes();
            Bind();
            SetStatus(string.Empty);
        }

        #region Initializers

        private void InitPresenter(string folderName) {
            Presenter = new NTextSearchPresenter(this, folderName);
            Presenter.OnSearchEnabled += (src, args) => buttonSearch.Enabled = args.Enable;
            Presenter.OnAddListItem += Presenter_OnAddListItem;
        }

        private void Presenter_OnAddListItem(object sender, ListViewEventArgs e){
            AddListItem(e.ListViewItem);
        }

        private void AddListItem(ListViewItem listViewItem){
            if (InvokeRequired) {
                Invoke(new Action<ListViewItem>(AddListItem), new object[] { listViewItem });
                return;
            }
            listView.Items.Add(listViewItem);
        }

        private void InitFolderBrowser(string folderName) {
            _folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            _folderBrowserDialog.SelectedPath = folderName;
            SetFolderName();
        }

        private void InitFilePropertiesDate() {
            dateTimePickerFrom.Value = dateTimePickerTo.Value = DateTime.Now.Date;
        }

        private void InitFileAttributes() {
            _fileAttributesControls = new List<CheckBox>{
                                                            checkBoxFileAttributeArchive,
                                                            checkBoxFileAttributeReadOnly,
                                                            checkBoxFileAttributeHidden,
                                                            checkBoxFileAttributeSystem
                                                        };
            ClearFileProperties();
        }

        #endregion

        #region Bind event

        private void Bind() {
            toolStripButtonExit.Click += (s, e) => Presenter.Exit();
            toolStripButtonRefreshPlugins.Click += (s, e) => Presenter.RefreshPlugins();
            comboBoxPlugins.SelectedIndexChanged += (s, e) => SelectedPlugin();
            buttonRefreshPlugins.Click += (s, e) => Presenter.RefreshPlugins();
            buttonBrowseFolder.Click += (s, e) => SelectFolder();
            buttonSearch.Click += (s, e) => SearchButtonPressed();
            checkBoxRecursive.CheckedChanged += (s, e) => RefreshRecusiveSearch();
            buttonClearFileAttributes.Click += (s, e) => ClearFileProperties();
            checkBoxFileDateFromEnabled.CheckedChanged += (s, e) => RefreshFilePropertiesDate();
            checkBoxFileDateToEnabled.CheckedChanged += (s, e) => RefreshFilePropertiesDate();
            dateTimePickerFrom.ValueChanged += (s, e) => RefreshFilePropertiesDate();
            dateTimePickerTo.ValueChanged += (s, e) => RefreshFilePropertiesDate();
            checkBoxFileSizeMinEnabled.CheckedChanged += (s, e) => RefreshFilePropertiesSize();
            checkBoxFileSizeMaxEnabled.CheckedChanged += (s, e) => RefreshFilePropertiesSize();
            numericUpDownFileSizeMin.ValueChanged += (s, e) => RefreshFilePropertiesSize();
            numericUpDownFileSizeMax.ValueChanged += (s, e) => RefreshFilePropertiesSize();
            _fileAttributesControls.ForEach(cb => cb.CheckedChanged += (s,e)=>RefreshFileAttributes());
        }

        private void SearchButtonPressed(){
            if (_searchInProcess)
                Presenter.InterruptSearch();
            else
                Presenter.PerformSearch(textBoxTargetText.Text);
        }

        #endregion

        private void SelectedPlugin(){
            Presenter.SelectPlugin((ITextSearch) comboBoxPlugins.SelectedItem);
        }

        private void RefreshFileAttributes(){
            Presenter.SetFileAttributes(GetFileAttributeValue(checkBoxFileAttributeReadOnly),
                                        GetFileAttributeValue(checkBoxFileAttributeArchive),
                                        GetFileAttributeValue(checkBoxFileAttributeHidden),
                                        GetFileAttributeValue(checkBoxFileAttributeSystem));
        }

        private void RefreshFilePropertiesDate(){
            dateTimePickerFrom.Enabled = checkBoxFileDateFromEnabled.Checked;
            dateTimePickerTo.Enabled = checkBoxFileDateToEnabled.Checked;
            Presenter.SetFilePropertyDate(GetFilePropertyDateBy(checkBoxFileDateFromEnabled, dateTimePickerFrom),
                                          GetFilePropertyDateBy(checkBoxFileDateToEnabled, dateTimePickerTo));
        }

        private void RefreshFilePropertiesSize(){
            numericUpDownFileSizeMin.Enabled = checkBoxFileSizeMinEnabled.Checked;
            numericUpDownFileSizeMax.Enabled = checkBoxFileSizeMaxEnabled.Checked;
            Presenter.SetFilePropertySize(GetFilePropertySizeBy(checkBoxFileSizeMinEnabled, numericUpDownFileSizeMin),
                                          GetFilePropertySizeBy(checkBoxFileSizeMaxEnabled, numericUpDownFileSizeMax));
        }

        private void RefreshRecusiveSearch(){
            Presenter.Recusive = checkBoxRecursive.Checked;
        }

        protected override void OnLoad(EventArgs e){
            base.OnLoad(e);
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

        public void RefreshPluginProperties(List<PluginProperty> pluginProperties) {
            groupBoxPluginProperties.SuspendLayout();
            groupBoxPluginProperties.Controls.Clear();
            groupBoxPluginProperties.Controls.AddRange(PluginPropertiesAssembler.BuildControls(pluginProperties));
            groupBoxPluginProperties.ResumeLayout(true);
        }

        public void RefreshSearchState(bool inProcess){
            _searchInProcess = inProcess;
            buttonSearch.Text = inProcess ? "Cancel" : "Search";
        }

        private void SelectFolder(){
            if (_folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
                SetFolderName();
        }

        private void SetFolderName(){
            Presenter.SetFolderName(textBoxFolderName.Text = _folderBrowserDialog.SelectedPath);
        }

        private static bool? GetFileAttributeValue(CheckBox checkBox) {
            return checkBox.CheckState == CheckState.Indeterminate ? (bool?)null : checkBox.Checked;
        }

        private static DateTime? GetFilePropertyDateBy(CheckBox checkBox, DateTimePicker dateTimePicker) {
            return checkBox.Checked ? dateTimePicker.Value : (DateTime?)null;
        }

        private static long? GetFilePropertySizeBy(CheckBox checkBox, NumericUpDown numericUpDown) {
            return checkBox.Checked ? Convert.ToInt32(numericUpDown.Value * 1000000) : (long?)null; //means 1MB = 1.000.000 bytes
        }

        private void ClearFileProperties() {
            checkBoxFileDateFromEnabled.Checked = checkBoxFileDateToEnabled.Checked = false;
            checkBoxFileSizeMinEnabled.Checked = checkBoxFileSizeMaxEnabled.Checked = false;
            _fileAttributesControls.ForEach(cb => cb.CheckState = CheckState.Indeterminate);
        }

        private static string GetInitFolderName() {
            return Directory.Exists(INIT_FOLDER_NAME) ? INIT_FOLDER_NAME : @"C:\";
        }

    }
}