namespace NTextSearch{
    internal class WarningNotificationHandler : AbstractNotificationHandler{
        public WarningNotificationHandler(ITextSearchPresenter presenter): base(presenter){
        }

        public override void Perform(TextSearchEventArg arg) {
            AddListItem("Warning", arg);
        }
    }
}