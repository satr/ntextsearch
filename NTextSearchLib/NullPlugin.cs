namespace NTextSearch{
    internal class NullPlugin : ITextSearch{
        public string FileExtention{
            get { return string.Empty; }
        }

        public string SearchPattern{
            get { return "*.*"; }
        }
    }
}