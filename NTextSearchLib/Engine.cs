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
            var assemblyFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            var pluginsFolder = Path.Combine(assemblyFolder, PLUGINS_SUBFOLDER_NAME);
            var pluginsDirectoryInfo = new DirectoryInfo(pluginsFolder);
            if (!pluginsDirectoryInfo.Exists)
                return;//TODO - log
            try{
                var fileInfos = GetFilesInFolder(pluginsDirectoryInfo.FullName, "*.dll");
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
                        Console.WriteLine(ex);
                        continue;//TODO - log
                    }
                }
            }
            catch (Exception ex){
                Console.WriteLine(ex);//TODO - log
            }
        }
    }
}
