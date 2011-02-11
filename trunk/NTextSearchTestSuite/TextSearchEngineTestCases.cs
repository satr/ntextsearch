using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearch;

namespace NTextSearchTestSuite {
    /// <summary>
    /// Summary description for TextSearchEngineTestCases
    /// </summary>
    [TestClass]
    public class TextSearchEngineTestCases {
        private static FSTestHelper _fsTestHelper;
        private static Engine _engine;
        private static DirectoryInfo _testFolder;
        private DirectoryInfo _testSubFolderLevel1;
        private DirectoryInfo _testSubFolderLevel2;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext) {
            _fsTestHelper = new FSTestHelper();
            _testFolder = _fsTestHelper.TestFolder;
            _engine = new Engine();
        }

        //
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup() {
            if (_fsTestHelper != null)
                _fsTestHelper.Dispose();
        }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize]
        public void MyTestInitialize() {
            _testSubFolderLevel1 = _fsTestHelper.CreateSubFolder();
            _testSubFolderLevel2 = _fsTestHelper.CreateSubFolder(_testSubFolderLevel1.FullName);
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup() {
            _fsTestHelper.CleanTestFolder();
        }
        //
        #endregion

        [TestMethod]
        public void TestGetFilesInEmptyFolder() {
            Assert.AreEqual(0, _engine.GetFilesInFolder(_testFolder.FullName, false, null).Length);
        }

        [TestMethod]
        public void TestGetFilesFromNotEmptyFolder() {
            using (FSTestHelper.CreateFileTxt(_testFolder.FullName)) {
                Assert.IsTrue(0 < _engine.GetFilesInFolder(_testFolder.FullName, false, null).Length);
            }
        }

        [TestMethod]
        public void TestGetFilesFromFolderRecursive() {
            using (FSTestHelper.CreateFileTxt(_testFolder.FullName))
            using (FSTestHelper.CreateFileMp3(_testSubFolderLevel1.FullName))
            using (FSTestHelper.CreateFileXml(_testSubFolderLevel2.FullName)) {
                Assert.AreEqual(3, _engine.GetFilesInFolder(_testFolder.FullName, true, null).Length);
            }
        }

        [TestMethod]
        public void TestRegisterFileExtentions(){
            Assert.AreEqual(0, _engine.Plugins.Count);
            _engine.RegisterPlugin(new MockPlugin(FSTestHelper.FileExtention.TXT));
            Assert.AreEqual(1, _engine.Plugins.Count);
        }

        [TestMethod]
        public void TestFileExtList(){
            var fileExtentions = new List<string>();
            _engine.RegisterPlugin(new MockPlugin(FSTestHelper.FileExtention.TXT));
            _engine.RegisterPlugin(new MockPlugin(FSTestHelper.FileExtention.MP3));
            _engine.RegisterPlugin(new MockPlugin(FSTestHelper.FileExtention.XML));
            foreach (var plugin in _engine.Plugins){
                if(!fileExtentions.Contains(plugin.FileExtention))
                    fileExtentions.Add(plugin.FileExtention);
            }
            Assert.AreEqual(3, fileExtentions.Count);
        }

        [TestMethod]
        public void TestGetFilesByExtention() {
            var pluginForTxt = new MockPlugin(FSTestHelper.FileExtention.TXT);
            _engine.RegisterPlugin(pluginForTxt);
            using (FSTestHelper.CreateFileTxt(_testFolder.FullName))
            using (FSTestHelper.CreateFileTxt(_testFolder.FullName))
            using (FSTestHelper.CreateFileTxt(_testFolder.FullName)){
                Assert.AreEqual(3, _engine.GetFilesInFolder(_testFolder.FullName, true, pluginForTxt).Length);
                using (FSTestHelper.CreateFileMp3(_testSubFolderLevel1.FullName))
                using (FSTestHelper.CreateFileMp3(_testSubFolderLevel1.FullName))
                using (FSTestHelper.CreateFileMp3(_testSubFolderLevel1.FullName)){
                    Assert.AreEqual(3, _engine.GetFilesInFolder(_testFolder.FullName, true, pluginForTxt).Length);
                    using (FSTestHelper.CreateFileXml(_testSubFolderLevel2.FullName))
                    using (FSTestHelper.CreateFileXml(_testSubFolderLevel2.FullName))
                    using (FSTestHelper.CreateFileXml(_testSubFolderLevel2.FullName)){
                        Assert.AreEqual(3, _engine.GetFilesInFolder(_testFolder.FullName, true, pluginForTxt).Length);
                    }
                }
            }
        }
    }
}