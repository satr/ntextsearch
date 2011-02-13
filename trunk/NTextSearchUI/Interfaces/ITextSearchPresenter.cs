using System;

namespace NTextSearch{
    public interface ITextSearchPresenter{
        void Exit();
        void RefreshPlugins();
        void SelectPlugin(ITextSearch plugin);
        string FolderName { get; set; }
        bool Recusive { get; set; }
        void SetFilePropertyDate(DateTime? dateFrom, DateTime? dateTo);
        void SetFileAttributes(bool? isReadOnly, bool? isArchive, bool? isHidden, bool? isSystem);
        DateTime? FilePropertiesDateTo { get; set; }
        void PerformSearch(string text);
        event EventHandler<EnableStateEventArgs> OnSearchEnabled;
        void AddListItem(string status, string fileName);
        void AddListItem(string status, string fileName, string message);
        event EventHandler<ListViewEventArgs> OnAddListItem;
        void ShowMessage(string format, params object[] args);
    }
}