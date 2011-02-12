namespace NTextSearch{
    public class NullPlugin : ITextSearch{
        public event TextSearchEventHandler OnNotify;
        public string FileExtention {
            get { return string.Empty; }
        }

        public string SearchPattern{
            get { return "*.*"; }
        }

        public string Title{
            get { return string.Empty; }
        }

        public void Shutdown(){
        }
    }
}