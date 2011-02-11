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
    }
}
