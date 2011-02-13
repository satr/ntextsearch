using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using NTextSearch;
/*
 This class is an optional implementation: does not require to inherid it, interface ISearchText is enough
 */
namespace NTextSearch{
    public abstract class AbstractTextSearchPlugin : ITextSearch{
        private string _targetText;
        private readonly object _sync = new object();
        private readonly Guid _matchWholeWordPropertyId;

        protected AbstractTextSearchPlugin(){
            Properties = new List<PluginProperty>();
            FilesToProcess = new Queue<string>();
            _matchWholeWordPropertyId = AddBooleanProperty(false, "Match whole word");
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

        public void PerformSearch(){
            if (FilesToProcess.Count == 0)
                return;
            var fileInfo = new FileInfo(FilesToProcess.Dequeue());
            if(!fileInfo.Exists){
                Notify(fileInfo, TextSearchStatus.FileNotFound);
                return;
            }
            PerformSearchIn(fileInfo);
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
            Notify(new FileInfo(fullFileName), textSearchStatus);
        }

        protected void Notify(FileSystemInfo fileInfo, TextSearchStatus textSearchStatus){
            Notify(fileInfo, textSearchStatus, string.Empty);
        }

        protected void Notify(FileSystemInfo fileInfo, TextSearchStatus textSearchStatus, string format, params object[] args){
            if (OnNotify != null)
                OnNotify(new TextSearchEventArg(fileInfo.FullName, textSearchStatus, format, args));
        }

        protected bool ValidateTextExistsIn(string value){
            if (string.IsNullOrEmpty(value))
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