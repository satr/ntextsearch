using System;
using NTextSearch;

namespace NTextSearchTestPlugin{
    [TextSearchEngine]
    public class TestPlugin : AbstractTextSearchPlugin {
        private readonly string _fileExtention;

        public TestPlugin()
            : this(FileExtentions.TEST) {
        }

        public TestPlugin(string fileExtention){
            _fileExtention = fileExtention;
        }

        protected override bool MultyThreadEnabled{
            get { return false; }
        }

        public override string FileExtention {
            get { return _fileExtention; }
        }
    }
}