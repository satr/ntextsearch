using System;
using System.IO;
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

        protected override void PerformSearchIn(FileInfo fileInfo) {
            using (var reader = new StreamReader(fileInfo.OpenRead())) {
                //TODO - check for requested break (or reset)
                IComparable<string> comparer = GetComparer();
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    if (comparer.CompareTo(line) > 0){
                        Notify(fileInfo, TextSearchStatus.TextFoundInFile);
                        return;
                    }
                }
            }
            Notify(fileInfo, TextSearchStatus.TextNotFoundInFile);
        }

        private IComparable<string> GetComparer(){
            return MatchWholeWord
                ? new SearchWholeWordComparer(TargetText)
                : new SearchSubstringComparer(TargetText);
        }
    }
}
