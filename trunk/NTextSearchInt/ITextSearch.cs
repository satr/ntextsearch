namespace NTextSearch{
    public interface ITextSearch{
        string FileExtention { get; }
        string SearchPattern { get; }
        void Shutdown();
        event TextSearchEventHandler OnTextFound;
    }
}