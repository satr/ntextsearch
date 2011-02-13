using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NTextSearch {
    public class Engine {
        const string PLUGINS_SUBFOLDER_NAME = "plugins";
        public Engine() {
            Plugins = new List<ITextSearch>();
        }

        private static FileInfo[] GetFilesInFolder(string folderPath, ITextSearch plugin){
            return GetFilesInFolder(folderPath, plugin.SearchPattern);
        }

        private static FileInfo[] GetFilesInFolder(string folderPath, string searchPattern){
            var directoryInfo = new DirectoryInfo(folderPath);
            return directoryInfo.Exists 
                       ? directoryInfo.GetFiles(searchPattern) 
                       : new FileInfo[0];
        }

        public FileInfo[] GetFilesInFolder(string folderPath, bool recursive, ITextSearch plugin){
            if (plugin == null)
                plugin = new NullPlugin();
            var filesInFolder = GetFilesInFolder(folderPath, plugin);
            if(!recursive)
                return filesInFolder;
            var fileInfoList = new List<FileInfo>(filesInFolder);
            foreach (var directoryInfo in new DirectoryInfo(folderPath).GetDirectories())
                fileInfoList.AddRange(GetFilesInFolder(directoryInfo.FullName, true, plugin));
            return fileInfoList.ToArray();
        }

        public List<ITextSearch> Plugins { get; private set; }

        public void RegisterPlugin(ITextSearch plugin){
            Plugins.Add(plugin);
        }

        public void LoadPlugins(){
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
            CurrentPlugin.TargetText = text;
            foreach (var fileInfo in GetFilesInFolder(folderName, Recursive, CurrentPlugin)){
                CurrentPlugin.RegisterFileToProcess(fileInfo.FullName);
                CurrentPlugin.PerformSearch();
            }
            //TODO - notify about search process completion
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
    }
}
