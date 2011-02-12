using System;
using System.Collections.Generic;
using System.IO;
using NTextSearch;

namespace NTextSearchTestPlugin{
    [TextSearchEngine]
    public class TestPlugin : ITextSearch {
        public event TextSearchEventHandler OnNotify;

        private string _targetText;
        private readonly object _sync = new object();

        public TestPlugin()
            : this(FileExtentions.TST) {
        }

        public TestPlugin(string fileExtention){
            FileExtention = fileExtention;
            FilesToProcess = new Queue<string>();
        }

        public string FileExtention { get; private set; }

        public string SearchPattern{
            get { return string.Format("*.{0}", FileExtention); }
        }

        public string Title{
            get { return string.Format("Test plugin ({0})", SearchPattern); }
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
            using (var reader = new StreamReader(fileInfo.OpenRead())){
                //TODO - check for requested break (or reset)
                var textFromFile = reader.ReadToEnd();
                if(textFromFile.Contains(TargetText?? string.Empty))//TODO
                    Notify(fileInfo, TextSearchStatus.TextFoundInFile);
                else
                    Notify(fileInfo, TextSearchStatus.TextNotFoundInFile);
            }
            return fileInfo.FullName;
        }

        private void Notify(string fullFileName, TextSearchStatus textSearchStatus){
            Notify(new FileInfo(fullFileName), textSearchStatus);
        }

        private void Notify(FileSystemInfo fileInfo, TextSearchStatus textSearchStatus){
            if (OnNotify != null)
                OnNotify(new TextSearchEventArg(fileInfo.FullName, textSearchStatus));
        }
    }
}