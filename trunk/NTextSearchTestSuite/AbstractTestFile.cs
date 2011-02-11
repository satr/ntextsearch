using System.IO;

namespace TextSearchTestSuite{
    internal abstract class AbstractTestFile{
        public AbstractTestFile(string folderPath){
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Path.GetTempFileName());

            new FileInfo(Path.Combine(folderPath, GetFileName(fileNameWithoutExtension))).Create();
        }

        protected abstract string GetFileName(string fileNameWithoutExtension);
    }
}