using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearch;
using NTextSearchTestPlugin;

namespace NTextSearchTestSuite {
    /// <summary>
    /// Summary description for TextSearchEngineTestCases
    /// </summary>
    [TestClass]
    public class TextSearchEngineTestCases : AbstractTextSearchTestCases{

        #region Additional test attributes
        [ClassInitialize]
        public new static void MyClassInitialize(TestContext testContext) {
            AbstractTextSearchTestCases.MyClassInitialize(testContext);
        }

        [ClassCleanup]
        public new static void MyClassCleanup() {
            AbstractTextSearchTestCases.MyClassCleanup();
        }
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
            _engine.RegisterPlugin(new TestPlugin(FileExtentions.TXT));
            Assert.AreEqual(1, _engine.Plugins.Count);
        }

        [TestMethod]
        public void TestFileExtList(){
            var fileExtentions = new List<string>();
            _engine.Plugins.Clear();
            _engine.RegisterPlugin(new TestPlugin(FileExtentions.TXT));
            _engine.RegisterPlugin(new TestPlugin(FileExtentions.MP3));
            _engine.RegisterPlugin(new TestPlugin(FileExtentions.XML));
            foreach (var plugin in _engine.Plugins){
                if(!fileExtentions.Contains(plugin.FileExtention))
                    fileExtentions.Add(plugin.FileExtention);
            }
            Assert.AreEqual(3, fileExtentions.Count);
        }

        [TestMethod]
        public void TestGetFilesByExtention() {
            var pluginForTxt = new TestPlugin(FileExtentions.TXT);
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

        [TestMethod]
        public void TestLoadPlugins(){
            _engine.LoadPlugins();
            Assert.IsTrue(_engine.Plugins.Count > 0);
        }
    }
}