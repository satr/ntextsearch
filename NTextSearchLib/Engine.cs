using System.Collections.Generic;
using System.IO;

namespace NTextSearch {
    public class Engine {
        public Engine(){
            Plugins = new List<ITextSearch>();
        }

        private static FileInfo[] GetFilesInFolder(string folderPath, ITextSearch plugin){
            var directoryInfo = new DirectoryInfo(folderPath);
            return directoryInfo.Exists 
                    ? directoryInfo.GetFiles(plugin.SearchPattern) 
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
    }
}
