using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTextSearch;

namespace NTextSearchXmlPlugin {
    [TextSearchEngine]
    public class TextSearchXmlEngine : ITextSearch {
        public event TextSearchEventHandler OnNotify;

        public string FileExtention {
            get { return FileExtentions.XML; }
        }

        public string SearchPattern {
            get { return string.Format("*.{0}", FileExtention); }
        }

        public string Title{
            get { return string.Format("XML files ({0})", SearchPattern); }
        }

        public void Shutdown(){
        }
    }
}