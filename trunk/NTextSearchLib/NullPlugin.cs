namespace NTextSearch{
    public class NullPlugin : AbstractTextSearchPlugin {
        
        protected override bool MultyThreadEnabled{
            get { return false; }
        }

        public override string FileExtention {
            get { return string.Empty; }
        }

        public override string SearchPattern{
            get { return "*.*"; }
        }
   }
}