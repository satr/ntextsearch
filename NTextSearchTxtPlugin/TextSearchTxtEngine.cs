using NTextSearch;

namespace NTextSearchTxtPlugin {
    [TextSearchEngine]
    public class TextSearchTxtEngine : AbstractTextSearchPlugin {
        public override string FileExtention {
            get { return FileExtentions.TXT; }
        }

        protected override string InnerTitle{
            get { return "Text files"; }
        }
    }
}
