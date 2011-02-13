using System.Collections.Generic;
using System.IO;
using NTextSearch;
/*
 This class is an optional implementation: does not require to inherid it, interface ISearchText is enough
 */
namespace NTextSearch{
    public abstract class AbstractTextSearchPlugin : ITextSearch{
        private string _targetText;
        private readonly object _sync = new object();

        protected AbstractTextSearchPlugin(){
            FilesToProcess = new Queue<string>();
        }

        public virtual event TextSearchEventHandler OnNotify;
        
        public abstract string FileExtention { get;}

        public virtual string SearchPattern{
            get { return string.Format("*.{0}", FileExtention); }
        }

        public string Title{
            get { return string.Format("{0} ({1})", InnerTitle, SearchPattern); }
        }

        protected virtual string InnerTitle{
            get { return "Undefined plugin"; }
        }

        public Queue<string> FilesToProcess { get; private set; }

        public string TargetText{
            get { return _targetText; }
            set{
                if (_targetText == value)
                    return;
                _targetText = value;
                Reset();
            }
        }

        private void Reset(){
            //TODO request to reset/break
            FilesToProcess.Clear();
        }

        public void Shutdown(){
            
        }

        public void RegisterFileToProcess(string fileFullName){
            lock (_sync){
                if(!FilesToProcess.Contains(fileFullName))
                    FilesToProcess.Enqueue(fileFullName);
            }
            if(string.IsNullOrEmpty(TargetText))
                Notify(fileFullName, TextSearchStatus.TargetTextNotSpecified);
        }

        public string PerformSearch(){
            if (FilesToProcess.Count == 0)
                return null;
            var fileInfo = new FileInfo(FilesToProcess.Dequeue());
            if(!fileInfo.Exists){
                Notify(fileInfo, TextSearchStatus.FileNotFound);
                return fileInfo.FullName;
            }
            PerformSearchIn(fileInfo);
            return fileInfo.FullName;
        }

        protected virtual void PerformSearchIn(FileInfo fileInfo){
            using (var reader = new StreamReader(fileInfo.OpenRead())) {
                //TODO - check for requested break (or reset)
                var textFromFile = reader.ReadToEnd();
                if (textFromFile.Contains(TargetText ?? string.Empty))//TODO
                    Notify(fileInfo, TextSearchStatus.TextFoundInFile);
                else
                    Notify(fileInfo, TextSearchStatus.TextNotFoundInFile);
            }
        }

        protected void Notify(string fullFileName, TextSearchStatus textSearchStatus){
            Notify(new FileInfo(fullFileName), textSearchStatus);
        }

        protected void Notify(FileSystemInfo fileInfo, TextSearchStatus textSearchStatus){
            if (OnNotify != null)
                OnNotify(new TextSearchEventArg(fileInfo.FullName, textSearchStatus));
        }
    }
}