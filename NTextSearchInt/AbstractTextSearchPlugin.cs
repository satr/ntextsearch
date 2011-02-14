using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using NTextSearch;
/*
 This class is an optional implementation: does not require to inherid it, interface ISearchText is enough
 */
namespace NTextSearch{
    public abstract class AbstractTextSearchPlugin : ITextSearch{
        private string _targetText;
        private readonly object _sync = new object();
        private readonly Guid _matchWholeWordPropertyId;
        private readonly EventWaitHandle _searchPerformerGo = new AutoResetEvent(false);
        private bool _cancelationPending;
        private readonly Thread _searchPerformerThread;
        private bool _fileRegistrationCompleted;
        private int _processedFilesCount;

        protected AbstractTextSearchPlugin(){
            Properties = new List<PluginProperty>();
            FilesToProcess = new Queue<string>();
            _matchWholeWordPropertyId = AddBooleanProperty(false, "Match whole word");
            _searchPerformerThread = new Thread(PerformeSearchAsync);
            _searchPerformerThread.Start();
        }

        private void PerformeSearchAsync(){
            for (;;){
                WaitForSignal();
                for (;;){
                    ResetSignal();
                    if (_cancelationPending)
                        InProcess = _cancelationPending = false;
                    if (!InProcess)
                        break;
                    string fileName = null;
                    lock (_sync){
                        if (FilesToProcess.Count != 0)
                            fileName = FilesToProcess.Dequeue();
                    }
                    if (fileName != null){
                        PerformSearchIn(new FileInfo(fileName));
                        _processedFilesCount++;
                    }
                    else if (_fileRegistrationCompleted){
                        InProcess = _cancelationPending = false;
                        Notify(fileName, TextSearchStatus.SearchInFilesCompleted,
                               "{0} files were performed", _processedFilesCount);
                    }
                    if (!MultyThreadEnabled)
                        break;
                }
                if (!MultyThreadEnabled)
                    break;
            }
        }

        #region WaitHandler methods

        private void WaitForSignal(){
            if(MultyThreadEnabled)
                _searchPerformerGo.WaitOne();
        }

        private void SetSignal() {
            if (MultyThreadEnabled)
                _searchPerformerGo.Set();
            else
                PerformeSearchAsync();
        }

        private void ResetSignal() {
            if (MultyThreadEnabled)
                _searchPerformerGo.Reset();
        }


        #endregion

        protected virtual bool MultyThreadEnabled {
            get { return true; }
        }

        public virtual event TextSearchEventHandler OnNotify;

        protected bool MatchWholeWord{
            get{
                return (bool)GetProperty(_matchWholeWordPropertyId).Value;
            }
        }

        protected PluginProperty GetProperty(Guid propertyId){
            var pluginProperty = Properties.Find(pr => pr.Id == propertyId);
            if (pluginProperty == null)
                throw new InvalidOperationException(string.Format("Property not found by Id {0}", propertyId));
            return pluginProperty;
        }

        public abstract string FileExtention { get; }

        public bool InProcess { get; protected set; }

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
                Reset();
                _targetText = value;
            }
        }

        public void Reset(){
            lock (_sync)
                FilesToProcess.Clear();
            _processedFilesCount = 0;
            _cancelationPending = true;
            SetSignal();
        }

        public void FileRegistrationCompleted(){
            _fileRegistrationCompleted = true;
        }

        public void Shutdown(){
            Reset();
            _searchPerformerThread.Join(1000);
            try{
                _searchPerformerThread.Abort();
            }
            catch (ThreadAbortException){}
        }

        public void RegisterFileToProcess(string fileFullName){
            _fileRegistrationCompleted = false;
            lock (_sync){
                if (!FilesToProcess.Contains(fileFullName)){
                    FilesToProcess.Enqueue(fileFullName);
                    InProcess = true;
                    SetSignal();
                }
            }
            if(string.IsNullOrEmpty(TargetText))
                Notify(fileFullName, TextSearchStatus.TargetTextNotSpecified);
        }

        public List<PluginProperty> Properties{ get; private set;}

        protected virtual void PerformSearchIn(FileInfo fileInfo){
            using (var reader = new StreamReader(fileInfo.OpenRead())) {
                //TODO - check for requested break (or reset)
                var textFromFile = reader.ReadToEnd();
                if (ValidateTextExistsIn(textFromFile))//TODO
                    Notify(fileInfo, TextSearchStatus.TextFoundInFile);
                else
                    Notify(fileInfo, TextSearchStatus.TextNotFoundInFile);
            }
        }

        protected void Notify(string fullFileName, TextSearchStatus textSearchStatus){
            Notify(fullFileName, textSearchStatus, string.Empty);
        }

        protected void Notify(FileSystemInfo fileInfo, TextSearchStatus textSearchStatus, string format, params object[] args) {
            Notify(fileInfo.FullName, textSearchStatus, format, args);
        }

        protected void Notify(FileSystemInfo fileInfo, TextSearchStatus textSearchStatus){
            Notify(fileInfo.FullName, textSearchStatus, string.Empty);
        }

        protected void Notify(string fullFileName, TextSearchStatus textSearchStatus, string format, params object[] args) {
            if (OnNotify != null)
                OnNotify(new TextSearchEventArg(fullFileName?? string.Empty, textSearchStatus, format, args));
        }

        protected bool ValidateTextExistsIn(string value){
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(TargetText))
                return false;
            if ((value.Equals(TargetText))
                || (!MatchWholeWord && value.Contains(TargetText))) {//TODO - rework as strategy with comparers
                return true;
            }
            return false;
        }

        protected Guid AddBooleanProperty(bool value, string title){
            var pluginProperty = new PluginProperty(PluginPropertyType.Boolean, value, title);
            Properties.Add(pluginProperty);
            return pluginProperty.Id;
        }
    }
}