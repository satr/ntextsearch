using System;
using System.Collections.Generic;
using NTextSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearchTestPlugin;
using NTextSearchTestSuite;

namespace TextSearchTestSuite
{
    [TestClass()]
    public class TextSearchPluginsTestCases : AbstractTextSearchTestCases {
        private TestPlugin _testPlugin;
        private readonly List<string> _filesWithFoundText = new List<string>();

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
            base.MyTestInitialize();
            _filesWithFoundText.Clear();
            _testPlugin = new TestPlugin();
            _testPlugin.OnTextFound += testPlugin_OnTextFound;
        }

        private void testPlugin_OnTextFound(string fileFullName){
            _filesWithFoundText.Add(fileFullName);
        }

        [TestCleanup]
        public override void MyTestCleanup() {
            base.MyTestCleanup();
            if (_testPlugin != null)
                _testPlugin.Shutdown();
        }

        #endregion

        [TestMethod]
        public void TestRegisterFileToProcess(){
            Assert.AreEqual(0, _testPlugin.FilesToProcess.Count);
            using(var file = FSTestHelper.CreateFileTst(_fsTestHelper.TestFolder.FullName)){
                _testPlugin.RegisterFileToProcess(file.FullName);
                Assert.AreEqual(1, _testPlugin.FilesToProcess.Count);
            }
        }


        [TestMethod]
        public void TestPerformPositiveTextSearch(){
            Assert.AreEqual(0, _filesWithFoundText.Count);
            using(var file = FSTestHelper.CreateFileTst(_fsTestHelper.TestFolder.FullName)){
                _testPlugin.RegisterFileToProcess(file.FullName);
                Assert.AreEqual(1, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(0, _filesWithFoundText.Count);
                Assert.AreEqual(file.FullName, _testPlugin.PerformPositiveTestSearchInOneFile());
                Assert.AreEqual(0, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(1, _filesWithFoundText.Count);
            }
        }

        [TestMethod]
        public void TestPerformNegativeTextSearch(){
            Assert.AreEqual(0, _filesWithFoundText.Count);
            using(var file = FSTestHelper.CreateFileTst(_fsTestHelper.TestFolder.FullName)){
                _testPlugin.RegisterFileToProcess(file.FullName);
                Assert.AreEqual(1, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(0, _filesWithFoundText.Count);
                Assert.AreEqual(file.FullName, _testPlugin.PerformNegativeTestSearchInOneFile());
                Assert.AreEqual(0, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(0, _filesWithFoundText.Count);
            }
        }
    }
}
