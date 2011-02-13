using System;

namespace NTextSearchTxtPlugin{
    internal class SearchSubstringComparer : IComparable<string>{
        protected const int NEGATIVE_RESULT = -1;
        protected const int POSITIVE_RESULT = 1;
        protected readonly string _targetText;

        public SearchSubstringComparer(string targetText){
            _targetText = targetText;
        }

        public virtual int CompareTo(string other){
            return string.IsNullOrEmpty(other) || !other.Contains(_targetText) ? NEGATIVE_RESULT : POSITIVE_RESULT;
        }
    }
}