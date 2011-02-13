using System;
using System.Linq;
using System.IO;
using System.Text;
using NTextSearch;

namespace NTextSearchTestSuite{
    public class FSHelper: IDisposable{
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

        public static TestFile CreateFileTst(string folderPath){
            return CreateFileTst(folderPath, string.Empty);
        }

        public static TestFile CreateFileTst(string folderPath, string testText) {
            return CreateFile(folderPath, FileExtentions.TEST, testText, Encoding.ASCII.EncodingName);
        }

        public static TestFile CreateFileTxt(string folderPath) {
            return CreateFile(folderPath, FileExtentions.TXT, string.Empty, Encoding.ASCII.EncodingName);
        }

        public static TestFile CreateFileMp3(string folderPath) {
            return CreateFile(folderPath, FileExtentions.MP3, string.Empty, Encoding.ASCII.EncodingName);
        }

        public static TestFile CreateFileXml(string folderPath) {
            return CreateFile(folderPath, FileExtentions.XML, string.Empty, Encoding.ASCII.EncodingName);
        }

        private static TestFile CreateFile(string folderPath, string extention, string testText, string encodingName) {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
            var fileInfo = new FileInfo(Path.Combine(folderPath, GetFileName(fileNameWithoutExtension, extention)));
            using (var fileStream = fileInfo.Create()){
                var bytes = Encoding.GetEncoding(encodingName).GetBytes(testText);//TODO - add encoding
                fileStream.Write(bytes, 0, bytes.Length);
            }
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