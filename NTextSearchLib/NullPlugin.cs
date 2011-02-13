namespace NTextSearch{
    public class NullPlugin : AbstractTextSearchPlugin {
        public override string FileExtention {
            get { return string.Empty; }
        }

        public override string SearchPattern{
            get { return "*.*"; }
        }
   }
}