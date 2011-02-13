using System;
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

        [TestInitialize]
        public override void MyTestInitialize() {
            _engine.LoadPlugins();
            _testPlugin = (ITextSearch)_engine.Plugins.Find(pl => pl.FileExtention == FileExtentions.TEST);
            base.MyTestInitialize();
        }

        #endregion

        [TestMethod]
        public void TestGetFilesInEmptyFolder() {
            Assert.AreEqual(0, _engine.GetFilesInFolder(_testFolder.FullName, false, null).Length);
        }

        [TestMethod]
        public void TestGetFilesFromNotEmptyFolder() {
            using (FSHelper.CreateFileTxt(_testFolder.FullName)) {
                Assert.IsTrue(0 < _engine.GetFilesInFolder(_testFolder.FullName, false, null).Length);
            }
        }

        [TestMethod]
        public void TestGetFilesFromFolderRecursive() {
            using (FSHelper.CreateFileTxt(_testFolder.FullName))
            using (FSHelper.CreateFileMp3(_testSubFolderLevel1.FullName))
            using (FSHelper.CreateFileXml(_testSubFolderLevel2.FullName)) {
                Assert.AreEqual(3, _engine.GetFilesInFolder(_testFolder.FullName, true, null).Length);
            }
        }

        [TestMethod]
        public void TestRegisterFileExtentions(){
            var pluginsCount = _engine.Plugins.Count;
            _engine.RegisterPlugin(new TestPlugin(FileExtentions.TXT));
            Assert.AreEqual(pluginsCount + 1, _engine.Plugins.Count);
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
            using (FSHelper.CreateFileTxt(_testFolder.FullName))
            using (FSHelper.CreateFileTxt(_testFolder.FullName))
            using (FSHelper.CreateFileTxt(_testFolder.FullName)){
                Assert.AreEqual(3, _engine.GetFilesInFolder(_testFolder.FullName, true, pluginForTxt).Length);
                using (FSHelper.CreateFileMp3(_testSubFolderLevel1.FullName))
                using (FSHelper.CreateFileMp3(_testSubFolderLevel1.FullName))
                using (FSHelper.CreateFileMp3(_testSubFolderLevel1.FullName)){
                    Assert.AreEqual(3, _engine.GetFilesInFolder(_testFolder.FullName, true, pluginForTxt).Length);
                    using (FSHelper.CreateFileXml(_testSubFolderLevel2.FullName))
                    using (FSHelper.CreateFileXml(_testSubFolderLevel2.FullName))
                    using (FSHelper.CreateFileXml(_testSubFolderLevel2.FullName)){
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

        [TestMethod]
        public void TestAttemptToPerformSearchWOCurrentPlugin(){
            _engine.CurrentPlugin = null;
            _engine.PerformSearch(TEST_TEXT);
        }

        [TestMethod]
        public void TestAttemptToPerformSearchWithEmptyText() {
            _engine.CurrentPlugin = _testPlugin;
            _engine.PerformSearch(EMPTY_TEXT);
        }

        [TestMethod]
        public void TestPerformSearch(){
            _engine.CurrentPlugin = _testPlugin;
            using(var file = FSHelper.CreateFileTst(_fsHelper.TestFolder.FullName, TEST_TEXT)){
                _engine.PerformSearch(TEST_TEXT);

            }
        }

    }
}