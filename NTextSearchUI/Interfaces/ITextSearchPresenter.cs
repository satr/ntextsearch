using System;

namespace NTextSearch{
    public interface ITextSearchPresenter{
        void Exit();
        void RefreshPlugins();
        void SelectPlugin(ITextSearch plugin);
        string FolderName { get; set; }
        bool Recusive { get; set; }
        void PerformSearch(string text);
        event EventHandler<EnableStateEventArgs> OnSearchEnabled;
        void AddListItem(string status, string fileName);
        void AddListItem(string status, string fileName, string message);
        event EventHandler<ListViewEventArgs> OnAddListItem;
        void ShowMessage(string format, params object[] args);
    }
}