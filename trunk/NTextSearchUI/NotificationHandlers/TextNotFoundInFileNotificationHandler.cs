namespace NTextSearch{
    internal class TextNotFoundInFileNotificationHandler : AbstractNotificationHandler{
        public TextNotFoundInFileNotificationHandler(ITextSearchPresenter presenter): base(presenter){
        }
        public override void Perform(TextSearchEventArg arg) {
            AddListItem("Text not found", arg);
        }
    }
}