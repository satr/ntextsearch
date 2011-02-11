using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NTextSearchLib {
    public class Engine {
        public FileInfo[] GetFilesInFolder(string folderPath){
            var directoryInfo = new DirectoryInfo(folderPath);
            return directoryInfo.Exists ? directoryInfo.GetFiles() : new FileInfo[0];
        }

        public FileInfo[] GetFilesInFolder(string folderPath, bool recursive){
            var filesInFolder = GetFilesInFolder(folderPath);
            if(!recursive)
                return filesInFolder;
            var fileInfoList = new List<FileInfo>(filesInFolder);
            foreach (var directoryInfo in new DirectoryInfo(folderPath).GetDirectories())
                fileInfoList.AddRange(GetFilesInFolder(directoryInfo.FullName, true));
            return fileInfoList.ToArray();
        }
    }
}
