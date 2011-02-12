using System;

namespace NTextSearch{
    public class TextSearchEventArg: EventArgs{
        public TextSearchEventArg(string fullFileName, TextSearchStatus textSearchStatus)
        : this(fullFileName, textSearchStatus, string.Empty){
        }

        public TextSearchEventArg(string fullFileName, TextSearchStatus textSearchStatus, string format, params object[] args){
            FullFileName = fullFileName;
            TextSearchStatus = textSearchStatus;
            Message = string.Format(format, args);
        }

        public string FullFileName { get; set; }
        public TextSearchStatus TextSearchStatus { get; private set; }

        public string Message { get; private set; }
    }
}