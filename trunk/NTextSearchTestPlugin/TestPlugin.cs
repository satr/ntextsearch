using NTextSearch;

namespace NTextSearchTestPlugin{
    [TextSearchEngine]
    public class TestPlugin : ITextSearch {
        public TestPlugin(string fileExtention){
            FileExtention = fileExtention;
        }

        public string FileExtention { get; private set; }

        public string SearchPattern{
            get { return string.Format("*.{0}", FileExtention); }
        }
    }
}