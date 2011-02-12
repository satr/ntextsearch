using System;
using System.Collections.Generic;
using NTextSearch;

namespace NTextSearchTestPlugin{
    public class TestPlugin : ITextSearch {
        public event TextSearchEventHandler OnTextFound;

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

        public Queue<string> FilesToProcess { get; private set; }

        public void Shutdown(){
            
        }

        public void RegisterFileToProcess(string fileFullName){
            lock (_sync){
                if(!FilesToProcess.Contains(fileFullName))
                    FilesToProcess.Enqueue(fileFullName);
            }
        }

        public string PerformPositiveTestSearchInOneFile(){
            if (FilesToProcess.Count == 0)
                return null;
            var fileName = FilesToProcess.Dequeue();
            if (OnTextFound != null)
                OnTextFound(fileName);
            return fileName;
        }

        public string PerformNegativeTestSearchInOneFile(){
            if (FilesToProcess.Count == 0)
                return null;
            return FilesToProcess.Dequeue();
        }
    }
}