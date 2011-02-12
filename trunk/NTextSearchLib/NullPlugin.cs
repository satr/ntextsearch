namespace NTextSearch{
    internal class NullPlugin : ITextSearch{
        public event TextSearchEventHandler OnNotify;
        public string FileExtention {
            get { return string.Empty; }
        }

        public string SearchPattern{
            get { return "*.*"; }
        }

        public void Shutdown(){
        }
    }
}