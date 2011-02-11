using System;
using System.IO;

namespace NTextSearchTestSuite{
    internal class FSTestHelper: IDisposable{
        private DirectoryInfo _testFolder;
        private bool _disposed;
        private static readonly object _sync = new object();

        public static class FileExtention{
            public const string TXT = "txt";
            public const string MP3 = "mp3";
            public const string XML = "xml";
        }

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
            return CreateFile(folderPath, FileExtention.TXT);
        }

        public static TestFile CreateFileMp3(string folderPath) {
            return CreateFile(folderPath, FileExtention.MP3);
        }

        public static TestFile CreateFileXml(string folderPath) {
            return CreateFile(folderPath, FileExtention.XML);
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

        public DirectoryInfo CreateSubFolder(){
            return CreateSubFolder(_testFolder.FullName);
        }

        public DirectoryInfo CreateSubFolder(string folderName){
            var directoryInfo = new DirectoryInfo(Path.Combine(folderName, Guid.NewGuid().ToString()));
            directoryInfo.Create();
            return directoryInfo;
        }

        public void CleanTestFolder(){
            foreach (var directoryInfo in _testFolder.GetDirectories())
                directoryInfo.Delete(true);
            foreach (var fileInfo in _testFolder.GetFiles())
                fileInfo.Delete();
        }
    }
}