namespace NTextSearch{
    internal class TargetTextNotSpecifiedNotificationHandler : AbstractNotificationHandler{
        public TargetTextNotSpecifiedNotificationHandler(ITextSearchPresenter presenter): base(presenter){
        }

        public override void Perform(TextSearchEventArg arg){
            Presenter.ShowMessage("Text to search is not specified");
        }
    }
}