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
            var assemblyFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            var pluginsFolder = Path.Combine(assemblyFolder, PLUGINS_SUBFOLDER_NAME);
            var pluginsDirectoryInfo = new DirectoryInfo(pluginsFolder);
            if (!pluginsDirectoryInfo.Exists)
                return;//TODO - log
            var fileInfos = GetFilesInFolder(pluginsDirectoryInfo.FullName, "*.dll");
            //TODO Assembly.Load()
        }
    }
}
