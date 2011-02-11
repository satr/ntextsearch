namespace NTextSearch{
    public interface ITextSearchPlugin{
        string FileExtention { get; }
        string SearchPattern { get; }
    }
}