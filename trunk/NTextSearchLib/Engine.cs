using System.Collections.Generic;
using System.IO;

namespace NTextSearch {
    public class Engine {
        public Engine(){
            Plugins = new List<ITextSearchPlugin>();
        }

        private static FileInfo[] GetFilesInFolder(string folderPath, ITextSearchPlugin plugin){
            var directoryInfo = new DirectoryInfo(folderPath);
            return directoryInfo.Exists 
                    ? directoryInfo.GetFiles(plugin.SearchPattern) 
                    : new FileInfo[0];
        }

        public FileInfo[] GetFilesInFolder(string folderPath, bool recursive, ITextSearchPlugin plugin){
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

        public List<ITextSearchPlugin> Plugins { get; private set; }

        public void RegisterPlugin(ITextSearchPlugin plugin){
            Plugins.Add(plugin);
        }
    }
}
