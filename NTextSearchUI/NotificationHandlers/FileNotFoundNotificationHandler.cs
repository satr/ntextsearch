namespace NTextSearch{
    internal class FileNotFoundNotificationHandler : AbstractNotificationHandler{
        public FileNotFoundNotificationHandler(ITextSearchPresenter presenter): base(presenter){
        }
        public override void Perform(TextSearchEventArg arg) {
            AddListItem("File not found", arg);
        }
    }
}