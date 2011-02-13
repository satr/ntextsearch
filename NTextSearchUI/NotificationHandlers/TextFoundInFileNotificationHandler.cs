namespace NTextSearch{
    internal class TextFoundInFileNotificationHandler : AbstractNotificationHandler{
        public TextFoundInFileNotificationHandler(ITextSearchPresenter presenter): base(presenter){
        }
        public override void Perform(TextSearchEventArg arg) {
            AddListItem("Text found", arg);
        }
    }
}