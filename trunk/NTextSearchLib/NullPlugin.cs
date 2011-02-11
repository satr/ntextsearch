namespace NTextSearch{
    internal class NullPlugin : ITextSearchPlugin{
        public string FileExtention{
            get { return string.Empty; }
        }

        public string SearchPattern{
            get { return "*.*"; }
        }
    }
}