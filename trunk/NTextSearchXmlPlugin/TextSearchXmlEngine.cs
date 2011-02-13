using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NTextSearch;

namespace NTextSearchXmlPlugin {
    [TextSearchEngine]
    public class TextSearchXmlEngine : AbstractTextSearchPlugin {

        public override string FileExtention {
            get { return FileExtentions.XML; }
        }

        protected override string InnerTitle {
            get { return "XML files"; }
        }
    }
}