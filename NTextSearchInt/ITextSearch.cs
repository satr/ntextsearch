namespace NTextSearch{
    public interface ITextSearch{
        string FileExtention { get; }
        string SearchPattern { get; }
        string Title { get; }
        void Shutdown();
        event TextSearchEventHandler OnNotify;
    }
}