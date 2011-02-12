using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTextSearch;

namespace NTextSearchTxtPlugin {
    [TextSearchEngine]
    public class TextSearchTxtEngine: ITextSearch {
        public event TextSearchEventHandler OnTextFound;

        public string FileExtention {
            get { return FileExtentions.TXT; }
        }

        public string SearchPattern{
            get { return string.Format("*.{0}", FileExtention); }
        }

        public void Shutdown(){
            
        }
    }
}
