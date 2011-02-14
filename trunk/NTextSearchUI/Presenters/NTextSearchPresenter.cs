using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace NTextSearch {
    public class NTextSearchPresenter : ITextSearchPresenter {
        #region Events

        public event EventHandler<EnableStateEventArgs> OnSearchEnabled;
        public event EventHandler<ListViewEventArgs> OnAddListItem;

        #endregion

        #region Fields

        private readonly Engine _engine;
        private readonly Dictionary<TextSearchStatus, AbstractNotificationHandler> _notificationHandlers;
        private readonly BackgroundWorker _searchEngineWorker;
        private int _foundFilesCount;
        private string _folderName;
        private readonly Queue<TextSearchEventArg> _statusesQueue = new Queue<TextSearchEventArg>();
        private readonly EventWaitHandle _statusPerformerGo = new AutoResetEvent(false);
        private readonly object _statusPerformerSync = new object();
        private readonly Thread _statusPerformerThread;

        #endregion

        public NTextSearchPresenter(ITextSearchView view, string folderName){
            View = view;
            SetFolderName(folderName);
            _notificationHandlers = InitTextSearchNotifyHandlers();
            _engine = InitEngine();
            _searchEngineWorker = InitSearchEngineWorker();
            _statusPerformerThread = InitSearchTextStatusPerformer();
        }

        public ITextSearchView View { get; set; }

        #region Initializers

        private Thread InitSearchTextStatusPerformer(){
            var statusPerformerThread = new Thread(PerformeSearchTextStatus);
            return statusPerformerThread;
        }

        private Dictionary<TextSearchStatus, AbstractNotificationHandler> InitTextSearchNotifyHandlers() {
            var handlers = new Dictionary<TextSearchStatus, AbstractNotificationHandler>();
            handlers.Add(TextSearchStatus.Error, new ErrorNotificationHandler(this));
            handlers.Add(TextSearchStatus.Warning, new WarningNotificationHandler(this));
            handlers.Add(TextSearchStatus.TextFoundInFile, new TextFoundInFileNotificationHandler(this));
            handlers.Add(TextSearchStatus.TextNotFoundInFile, new TextNotFoundInFileNotificationHandler(this));
            handlers.Add(TextSearchStatus.FileNotFound, new FileNotFoundNotificationHandler(this));
            handlers.Add(TextSearchStatus.TargetTextNotSpecified, new TargetTextNotSpecifiedNotificationHandler(this));
            return handlers;
        }

        private BackgroundWorker InitSearchEngineWorker() {
            var worker = new BackgroundWorker{
                                                 WorkerSupportsCancellation = true,
                                                 WorkerReportsProgress = true,
                                             };
            worker.DoWork += PerformSearchAsync;
            worker.ProgressChanged += SearchEngineWorkerProgressChanged;
            worker.RunWorkerCompleted += SearchEngineWorkerCompletedSearch;
            return worker;
        }

        private Engine InitEngine(){
            var engine = new Engine();
            engine.OnFileFound += engine_OnFileFound;
            return engine;
        }

        #endregion

        #region StatusPerformer methods

        private void PerformeSearchTextStatus() {
            while (true) {
                _statusPerformerGo.WaitOne();
                TextSearchEventArg textSearchEventArg = null;
                lock (_statusPerformerSync) {
                    if (_statusesQueue.Count > 0)
                        textSearchEventArg = _statusesQueue.Dequeue();
                }
                if (textSearchEventArg != null) {
                    if (!_notificationHandlers.ContainsKey(textSearchEventArg.TextSearchStatus))
                        throw new InvalidOperationException(string.Format("Notification status \"{0}\" is not supported", textSearchEventArg.TextSearchStatus));
                    _notificationHandlers[textSearchEventArg.TextSearchStatus].Perform(textSearchEventArg);
                }
            }
        }

        #endregion

        #region ITestSearchPresenter methods

        public void PerformSearch(string text) {
            View.RefreshSearchState(true);
            View.ClearList();
            _statusPerformerThread.Start();
            _searchEngineWorker.RunWorkerAsync(text);
        }

        public void InterruptSearch() {
            _searchEngineWorker.CancelAsync();
        }

        public void AddListItem(string status, string fileName) {
            
            AddListItem(status, fileName, string.Empty);
        }

        public void AddListItem(string status, string fileName, string message) {
            if (OnAddListItem == null)
                return;
            var listViewItem = new ListViewItem(new[] { status, fileName });
            listViewItem.ToolTipText = message;
            OnAddListItem(this, new ListViewEventArgs(listViewItem));
        }

        public void Exit() {
            var dialogResult = MessageBox.Show("Do you really want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
                View.Close();
        }

        public void RefreshPlugins(){
            _engine.LoadPlugins();
            View.RefreshPlugins(_engine.Plugins);
        }

        public void SelectPlugin(ITextSearch plugin){
            if (_engine.CurrentPlugin != null)
                Unbind(_engine.CurrentPlugin);
            _engine.CurrentPlugin = plugin;
            if (_engine.CurrentPlugin != null)
                Bind(_engine.CurrentPlugin);
            if (OnSearchEnabled != null)
                OnSearchEnabled(this, new EnableStateEventArgs(_engine.CurrentPlugin != null));
            View.RefreshPluginProperties(_engine.CurrentPlugin.Properties);
        }

        public void SetFolderName(string folderName){
            _folderName = folderName;
        }

        public void ShowMessage(string format, params object[] args) {
            string message = string.Format(format, args);
            View.SetStatus(message);
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        #endregion

        #region Set engine file search conditions

        public bool Recusive{
            get { return _engine.Recursive; }
            set { _engine.Recursive = value; }
        }

        public void SetFileAttributes(bool? isReadOnly, bool? isArchive, bool? isHidden, bool? isSystem){
            _engine.SetFileAttributes(isReadOnly, isArchive, isHidden, isSystem);
        }

        public void SetFilePropertyDate(DateTime? dateFrom, DateTime? dateTo){
            _engine.SetFilePropertyDate(dateFrom, dateTo);
        }

        public void SetFilePropertySize(long? minFileSize, long? maxFileSize){
            _engine.SetFilePropertySize(minFileSize, maxFileSize);
        }


        #endregion

        #region Plugin notifications

        private void Bind(ITextSearch plugin){
            plugin.OnNotify += plugin_OnNotify;
        }

        private void Unbind(ITextSearch plugin) {
            plugin.OnNotify -= plugin_OnNotify;
        }

        private void plugin_OnNotify(TextSearchEventArg args) {
            lock(_statusPerformerSync)
                _statusesQueue.Enqueue(args);
            _statusPerformerGo.Set();
        }

        #endregion

        #region BackgroundWorker methods

        private void PerformSearchAsync(object sender, DoWorkEventArgs e) {
            _foundFilesCount = 0;
            _engine.PerformSearch(_folderName, (string)e.Argument);
        }

        private void engine_OnFileFound(object sender, EventArgs e) {
            _searchEngineWorker.ReportProgress(++_foundFilesCount);
        }

        private void SearchEngineWorkerProgressChanged(object sender, ProgressChangedEventArgs e) {
            View.SetStatus(string.Format("Search files: {0} found", e.ProgressPercentage));
        }

        private void SearchEngineWorkerCompletedSearch(object sender, RunWorkerCompletedEventArgs e) {
            View.RefreshSearchState(false);
            View.SetStatus("Search completed");
            _statusPerformerThread.Join(1000);
            _statusPerformerThread.Abort();
        }

        #endregion
    }
}
