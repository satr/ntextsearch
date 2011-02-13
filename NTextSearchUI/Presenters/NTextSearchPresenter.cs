using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace NTextSearch {
    public class NTextSearchPresenter : ITextSearchPresenter {
        public event EventHandler<EnableStateEventArgs> OnSearchEnabled;
        public event EventHandler<ListViewEventArgs> OnAddListItem;

        public void ShowMessage(string format, params object[] args){
            string message = string.Format(format, args);
            View.SetStatus(message);
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private readonly Engine _engine = new Engine();
        private readonly Dictionary<TextSearchStatus, AbstractNotificationHandler> _notificationHandlers;
        public ITextSearchView View { get; set; }

        public NTextSearchPresenter(ITextSearchView view, string folderName){
            View = view;
            FolderName = folderName;
            _notificationHandlers = InitTextSearchNotifyHandlers();
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

        public void Exit(){
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
            View.RefreshPluginProperties();
        }

        public string FolderName {set; get;}

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

        public DateTime? FilePropertiesDateTo {get; set;}

        private void Bind(ITextSearch plugin){
            plugin.OnNotify += plugin_OnNotify;
        }

        private void Unbind(ITextSearch plugin) {
            plugin.OnNotify -= plugin_OnNotify;
        }

        private void plugin_OnNotify(TextSearchEventArg args) {
            if (!_notificationHandlers.ContainsKey(args.TextSearchStatus)){
                Debug.Fail(string.Format("Notification status \"{0}\" is not supported", args.TextSearchStatus));
                return;
            }
            _notificationHandlers[args.TextSearchStatus].Perform(args);
        }

        public void PerformSearch(string text){
            View.ClearList();
            _engine.PerformSearch(FolderName, text);
        }

        public void AddListItem(string status, string fileName) {
            AddListItem(status, fileName, string.Empty);
        }

        public void AddListItem(string status, string fileName, string message){
            if (OnAddListItem == null) 
                return;
            var listViewItem = new ListViewItem(new[]{status, fileName});
            listViewItem.ToolTipText = message;
            OnAddListItem(this, new ListViewEventArgs(listViewItem));
        }
    }
}
