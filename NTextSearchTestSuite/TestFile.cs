using System;
using System.IO;

namespace NTextSearchTestSuite{
    internal class TestFile: IDisposable{
        private readonly FileInfo _fileInfo;
        private bool _disposed;
        private static readonly object _sync = new object();

        public TestFile(FileInfo fileInfo){
            _fileInfo = fileInfo;
        }

        public void Dispose(){
            if(!_disposed){
                lock (_sync){
                    if(_fileInfo != null && _fileInfo.Exists)
                        _fileInfo.Delete();
                    _disposed = true;
                }
            }
        }
    }
}