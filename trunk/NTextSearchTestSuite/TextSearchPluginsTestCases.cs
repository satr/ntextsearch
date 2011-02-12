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
        readonly string TEST_TEXT = Guid.NewGuid().ToString();
        readonly string TEST_MISMATCH_TEXT = Guid.NewGuid().ToString();
        readonly string EMPTY_TEXT = string.Empty;
        private TestPlugin _testPlugin;
        private readonly List<TextSearchEventArg> _textSearchEventArgs = new List<TextSearchEventArg>();

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
            _textSearchEventArgs.Clear();
            _testPlugin = new TestPlugin();
            _testPlugin.OnNotify += testPlugin_OnTextFound;
        }

        private void testPlugin_OnTextFound(TextSearchEventArg args){
            _textSearchEventArgs.Add(args);
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
            Assert.AreEqual(0, _textSearchEventArgs.Count);
            using (var file = FSTestHelper.CreateFileTst(_fsTestHelper.TestFolder.FullName)) {
                _testPlugin.RegisterFileToProcess(file.FullName);
                Assert.AreEqual(1, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(1, _textSearchEventArgs.Count);
                Assert.AreEqual(TextSearchStatus.TargetTextNotSpecified, _textSearchEventArgs[0].TextSearchStatus);
            }
        }

        [TestMethod]
        public void TestPerformPositiveTextSearch(){
            PerformTextSearch(TEST_TEXT, TEST_TEXT, TextSearchStatus.TextFoundInFile);
        }

        [TestMethod]
        public void TestPerformNegativeTextSearch() {
            PerformTextSearch(TEST_MISMATCH_TEXT, TEST_TEXT, TextSearchStatus.TextNotFoundInFile);
        }

        private void PerformTextSearch(string targetText, string textInFile, TextSearchStatus expectedStatus) {
            Assert.AreEqual(0, _textSearchEventArgs.Count);
            using(var file = FSTestHelper.CreateFileTst(_fsTestHelper.TestFolder.FullName, textInFile)){
                _testPlugin.TargetText = targetText;
                _testPlugin.RegisterFileToProcess(file.FullName);
                Assert.AreEqual(file.FullName, _testPlugin.PerformSearch());
                Assert.AreEqual(0, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(1, _textSearchEventArgs.Count);
                Assert.AreEqual(expectedStatus, _textSearchEventArgs[0].TextSearchStatus);
            }
        }
    }
}
