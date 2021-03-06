﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NTextSearch {
    public class Engine {
        const string PLUGINS_SUBFOLDER_NAME = "plugins";
        private FileAttributes _fileAttributes;
        private DateTime? _filePropertyDateFrom;
        private DateTime? _filePropertyDateTo;
        private long? _filePropertySizeMin;
        private long? _filePropertySizeMax;
        private bool _inProcess;
        private bool _cancellationPending;
        public event EventHandler OnFileFound;

        public Engine() {
            Plugins = new List<ITextSearch>();
        }

        private FileInfo[] GetFilesInFolder(string folderPath, ITextSearch plugin){
            return GetFilesInFolder(folderPath, plugin.SearchPattern);
        }

        private FileInfo[] GetFilesInFolder(string folderPath, string searchPattern){
            var directoryInfo = new DirectoryInfo(folderPath);
            if (!directoryInfo.Exists) 
                return new FileInfo[0];
            var validFiles = new List<FileInfo>();
            try{
                var fileInfos = directoryInfo.GetFiles(searchPattern);
                foreach (var fileInfo in fileInfos){
                    var attributes = fileInfo.Attributes;
                    if (ValidateFileAttribute(_fileAttributes.ReadOnly, System.IO.FileAttributes.ReadOnly, attributes)
                        && ValidateFileAttribute(_fileAttributes.Archive, System.IO.FileAttributes.Archive, attributes)
                        && ValidateFileAttribute(_fileAttributes.Hidden, System.IO.FileAttributes.Hidden, attributes)
                        && ValidateFileAttribute(_fileAttributes.System, System.IO.FileAttributes.System, attributes)
                        && ValidateFilePropertyDate(fileInfo)
                        && ValidateFilePropertySize(fileInfo)){
                        validFiles.Add(fileInfo);
                        NotifyFileFound();
                    }
                }
            }
            catch (Exception ex){
                LogError("File access", ex.Message);
            }
            return validFiles.ToArray();
        }

        private void NotifyFileFound(){
            if (OnFileFound != null)
                OnFileFound(this, EventArgs.Empty);
        }

        private bool ValidateFilePropertyDate(FileSystemInfo fileInfo){
            bool conditionFromIsValid = (!_filePropertyDateFrom.HasValue || _filePropertyDateFrom.Value <= fileInfo.CreationTime);
            bool conditionToIsValid = (!_filePropertyDateTo.HasValue || _filePropertyDateTo.Value >= fileInfo.CreationTime);
            return conditionFromIsValid && conditionToIsValid;
        }

        private bool ValidateFilePropertySize(FileInfo fileInfo) {
            bool conditionFromIsValid = (!_filePropertySizeMin.HasValue || _filePropertySizeMin.Value <= fileInfo.Length);
            bool conditionToIsValid = (!_filePropertySizeMax.HasValue || _filePropertySizeMax.Value >= fileInfo.Length);
            return conditionFromIsValid && conditionToIsValid;
        }

        private static bool ValidateFileAttribute(bool? conditionValue, System.IO.FileAttributes attribute, System.IO.FileAttributes attributes){
            bool hasAttribute = (attributes & attribute) > 0;
            return !conditionValue.HasValue || !(conditionValue.Value ^ hasAttribute);
        }

        public FileInfo[]   GetFilesInFolder(string folderPath, bool recursive, ITextSearch plugin){
            if (plugin == null)
                plugin = new NullPlugin();
            if (_cancellationPending){
                plugin.Reset();
                return new FileInfo[0];
            }
            var filesInFolder = GetFilesInFolder(folderPath, plugin);
            filesInFolder.ToList().ForEach(fi => plugin.RegisterFileToProcess(fi.FullName));
            if(!recursive)
                return filesInFolder;
            var fileInfoList = new List<FileInfo>(filesInFolder);
            try{
                string[] directories = Directory.GetDirectories(folderPath);
                foreach (var directoryPath in directories)
                    fileInfoList.AddRange(GetFilesInFolder(directoryPath, true, plugin));
            }
            catch (Exception ex){
                LogError("File access problem", ex.Message);
            }
            return fileInfoList.ToArray();
        }

        public List<ITextSearch> Plugins { get; private set; }

        public void RegisterPlugin(ITextSearch plugin){
            Plugins.Add(plugin);
        }

        public void LoadPlugins(){
            Plugins.ForEach(plugin => plugin.Shutdown());
            Plugins.Clear();
            DirectoryInfo pluginsFolder = PluginsFolder;
            if (!pluginsFolder.Exists) {
                LogWarning("No plugins found", pluginsFolder.FullName);
                return;
            }
            var fileInfos = GetFilesInFolder(pluginsFolder.FullName, "*.dll");
            foreach (var fileInfo in fileInfos){
                try{
                    Assembly assembly = Assembly.LoadFrom(fileInfo.FullName);
                    Type[] types = assembly.GetTypes();
                    foreach (var type in types){
                        var attributes = type.GetCustomAttributes(false).ToList();
                        if(!attributes.Exists(at => at is TextSearchEngineAttribute))
                            continue;
                        var plugin = Activator.CreateInstance(type) as ITextSearch;
                        if(plugin == null)
                            continue;
                        Plugins.Add(plugin);
                    }
                }
                catch (BadImageFormatException ex){
                    LogWarning(string.Format("{0} file is not a plugin", fileInfo.Name), ex.Message);
                    continue;
                }
                catch (MissingMethodException ex){
                    LogWarning(string.Format("{0} assembly is not a valid plugin", fileInfo.Name), ex.Message);
                    continue;
                }
                catch (Exception ex) {
                    LogError("Load Plugins", ex.Message);
                }
            }
        }

        private static DirectoryInfo PluginsFolder{
            get{
                var assemblyFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
                var pluginsFolder = Path.Combine(assemblyFolder, PLUGINS_SUBFOLDER_NAME);
                return new DirectoryInfo(pluginsFolder);
            }
        }

        public ITextSearch CurrentPlugin { get; set; }

        private static void LogError(string message, string detailMessageFormat, params object[] args) {
            LogMessage("ERROR", message, detailMessageFormat, args);
        }

        private static void LogWarning(string message, string detailMessageFormat, params object[] args) {
            LogMessage("WARNING", message, detailMessageFormat, args);
        }

        private static void LogMessage(string messageType, string message, string detailMessageFormat, object[] args){
            var detailMessage = string.Format(detailMessageFormat, args);
            Console.WriteLine(string.Format("{0}: {1}; DETAILS: {2}", messageType, message, detailMessage));//TODO
        }

        public void PerformSearch(string folderName, string text){
            if (!ValidateSearchAvailable(text))
                return;
            _inProcess = true;
            _cancellationPending = false;
            CurrentPlugin.TargetText = text;
            GetFilesInFolder(folderName, Recursive, CurrentPlugin);
            CurrentPlugin.FileRegistrationCompleted();
            _inProcess = false;
        }

        public bool Recursive { get; set; }

        private bool ValidateSearchAvailable(string text){
            var errorMessage = "Text search is is not available";
            if (CurrentPlugin == null){
                LogError(errorMessage, "File type (supported by plugins) is not specified");
                return false;
            }
            if (string.IsNullOrEmpty(text)){
                LogError(errorMessage, "Text to search is not specified");
                return false;
            }
            return true;
        }

        public void SetFileAttributes(bool? isReadOnly, bool? isArchive, bool? isHidden, bool? isSystem){
            _fileAttributes = new FileAttributes(isReadOnly, isArchive, isHidden, isSystem);
        }

        public void SetFilePropertyDate(DateTime? dateFrom, DateTime? dateTo){
            _filePropertyDateFrom = dateFrom;
            _filePropertyDateTo = dateTo;
        }

        public void SetFilePropertySize(long? fileSizeMin, long? fileSizeMax) {
            _filePropertySizeMin = fileSizeMin;
            _filePropertySizeMax = fileSizeMax;
        }

        #region Inner classes and structs

        private struct FileAttributes {
            public readonly bool? ReadOnly;
            public readonly bool? Archive;
            public readonly bool? Hidden;
            public readonly bool? System;

            public FileAttributes(bool? isReadOnly, bool? isArchive, bool? isHidden, bool? isSystem) {
                ReadOnly = isReadOnly;
                Archive = isArchive;
                Hidden = isHidden;
                System = isSystem;
            }
        }
        #endregion

        public void CancelSearch(){
            if(_inProcess)
                _cancellationPending = true;
        }
    }
}
