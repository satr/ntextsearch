namespace NTextSearch{
    internal class SearchInFilesCompletedNotificationHandler : AbstractNotificationHandler{
        public SearchInFilesCompletedNotificationHandler(ITextSearchPresenter presenter): base(presenter){
        }

        public override void Perform(TextSearchEventArg arg){
            Presenter.ShowMessage("Search in files completed");
        }
    }
}