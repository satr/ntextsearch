using System.Linq;
using System.Text.RegularExpressions;

namespace NTextSearchTxtPlugin{
    internal class SearchWholeWordComparer : SearchSubstringComparer {
        public SearchWholeWordComparer(string targetText): base(targetText){
        }

        public override int CompareTo(string other){
            if (base.CompareTo(other) < 0)
                return -1;
            string[] lines = Regex.Split(other, @"[^\w]+");
            return lines.ToList().Exists(line => line == _targetText)? POSITIVE_RESULT: NEGATIVE_RESULT;
        }
    }
}