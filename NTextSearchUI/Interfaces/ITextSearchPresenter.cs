using System;

namespace NTextSearch{
    public interface ITextSearchPresenter{
        void Exit();
        void RefreshPlugins();
        void SelectPlugin(ITextSearch plugin);
        void SetFolderName(string folderName);
        bool Recusive { get; set; }
        void SetFilePropertyDate(DateTime? dateFrom, DateTime? dateTo);
        void SetFilePropertySize(long? minFileSize, long? maxFileSize);
        void SetFileAttributes(bool? isReadOnly, bool? isArchive, bool? isHidden, bool? isSystem);
        void PerformSearch(string text);
        event EventHandler<EnableStateEventArgs> OnSearchEnabled;
        void AddListItem(string status, string fileName);
        void AddListItem(string status, string fileName, string message);
        event EventHandler<ListViewEventArgs> OnAddListItem;
        void ShowMessage(string format, params object[] args);
        void InterruptSearch();
    }
}