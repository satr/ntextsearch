using NTextSearch;

namespace NTextSearchTestSuite{
    internal class MockPlugin : ITextSearchPlugin{
        public MockPlugin(string fileExtention){
            FileExtention = fileExtention;
        }

        public string FileExtention { get; private set; }

        public string SearchPattern{
            get { return string.Format("*.{0}", FileExtention); }
        }
    }
}