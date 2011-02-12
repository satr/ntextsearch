using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTextSearch {
    public class NTextSearchPresenter : ITextSearchPresenter {
        public event EventHandler<EnableStateEventArgs> OnSearchEnabled;
        private readonly Engine _engine;
        public ITextSearchView View { get; set; }

        public NTextSearchPresenter(ITextSearchView view){
            View = view;
            _engine = new Engine();
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
            _engine.CurrentPlugin = plugin;
            if(OnSearchEnabled != null)
                OnSearchEnabled(this, new EnableStateEventArgs(_engine.CurrentPlugin != null));
        }

        public void PerformSearch(string text){
            _engine.PerformSearch(text);
        }
    }

    public class EnableStateEventArgs: EventArgs{
        public bool Enable { get; set; }

        public EnableStateEventArgs(bool enable){
            Enable = enable;
        }
    }
}
