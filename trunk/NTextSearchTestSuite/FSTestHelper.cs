using System;
using System.IO;

namespace NTextSearchTestSuite{
    internal class FSTestHelper: IDisposable{
        private DirectoryInfo _testFolder;
        private bool _disposed;
        private static readonly object _sync = new object();

        public DirectoryInfo TestFolder{
            get { return _testFolder ?? (_testFolder = CreateTempFolder()); }
        }

        private static DirectoryInfo CreateTempFolder(){
            var tempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var directoryInfo = new DirectoryInfo(tempFolder);
            directoryInfo.Create();
            return directoryInfo;
        }

        public void Dispose(){
            if(!_disposed){
                lock (_sync){
                    if(_testFolder != null && _testFolder.Exists)
                        _testFolder.Delete(true);
                    _disposed = true;
                }
            }
        }

        public static TestFile CreateFileTxt(string folderPath) {
            return CreateFile(folderPath, "txt");
        }

        private static TestFile CreateFile(string folderPath, string extention) {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
            var fileInfo = new FileInfo(Path.Combine(folderPath, GetFileName(fileNameWithoutExtension, extention)));
            fileInfo.Create().Close();
            return new TestFile(fileInfo);
        }

        private static string GetFileName(string fileNameWithoutExtension, string extention) {
            return string.Format("{0}.{1}", fileNameWithoutExtension, extention);
        }

    }
}