using System.Collections.Generic;

namespace NTextSearch{
    public interface ITextSearch{
        string FileExtention { get; }
        string SearchPattern { get; }
        string Title { get; }
        Queue<string> FilesToProcess { get; }
        string TargetText { get; set; }
        void Shutdown();
        event TextSearchEventHandler OnNotify;
        void RegisterFileToProcess(string fileFullName);
        void PerformSearch();
    }
}