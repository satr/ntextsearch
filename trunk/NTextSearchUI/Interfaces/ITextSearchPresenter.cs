using System;

namespace NTextSearch{
    public interface ITextSearchPresenter{
        void Exit();
        void RefreshPlugins();
        void SelectPlugin(ITextSearch plugin);
        void PerformSearch(string text);
        event EventHandler<EnableStateEventArgs> OnSearchEnabled;
        void AddListItem(string status, string fileName);
        void AddListItem(string status, string fileName, string message);
        event EventHandler<ListViewEventArgs> OnAddListItem;
    }
}