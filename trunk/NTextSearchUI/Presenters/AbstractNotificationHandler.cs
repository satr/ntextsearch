namespace NTextSearch{
    internal abstract class AbstractNotificationHandler{
        protected ITextSearchPresenter Presenter { get; set; }

        protected AbstractNotificationHandler(ITextSearchPresenter presenter){
            Presenter = presenter;
        }

        public abstract void Perform(TextSearchEventArg arg);
    }
}