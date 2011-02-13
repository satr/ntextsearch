using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTextSearch {
    public class NTextSearchPresenter : ITextSearchPresenter {
        public event EventHandler<EnableStateEventArgs> OnSearchEnabled;
        public event EventHandler<ListViewEventArgs> OnAddListItem;

        private readonly Engine _engine;
        private readonly Dictionary<TextSearchStatus, AbstractNotificationHandler> _notificationHandlers;
        private string folderName;
        public ITextSearchView View { get; set; }

        public NTextSearchPresenter(ITextSearchView view){
            View = view;
            _engine = new Engine();
            _notificationHandlers = InitTextSearchNotifyHandlers();
        }

        private Dictionary<TextSearchStatus, AbstractNotificationHandler> InitTextSearchNotifyHandlers() {
            var handlers = new Dictionary<TextSearchStatus, AbstractNotificationHandler>();
            handlers.Add(TextSearchStatus.Error, new ErrorNotificationHandler(this));
            return handlers;
        }

        private void AddErrorItem(TextSearchStatus status){
            
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
        }

        private void Bind(ITextSearch plugin){
            plugin.OnNotify += plugin_OnNotify;
        }

        private void Unbind(ITextSearch plugin) {
            plugin.OnNotify -= plugin_OnNotify;
        }

        private void plugin_OnNotify(TextSearchEventArg args) {
            if (_notificationHandlers.ContainsKey(args.TextSearchStatus))
                return;
            _notificationHandlers[args.TextSearchStatus].Perform(args);
        }

        public void PerformSearch(string text){
            _engine.PerformSearch(folderName, text);
        }

        public void AddListItem(string status, string fileName) {
            AddListItem(status, fileName, string.Empty);
        }

        public void AddListItem(string status, string fileName, string message){
            if (OnAddListItem == null) 
                return;
            var listViewItem = new ListViewItem(new[]{status, fileName});
            listViewItem.ToolTipText = message;
            listViewItem.SubItems[0].BackColor = Color.Red;
            OnAddListItem(this, new ListViewEventArgs(listViewItem));
        }
    }
}
