namespace NTextSearch{
    internal class ErrorNotificationHandler : AbstractNotificationHandler{
        public ErrorNotificationHandler(ITextSearchPresenter presenter): base(presenter){
        }

        public override void Perform(TextSearchEventArg arg){
            AddListItem("Error", arg);
        }
    }
}