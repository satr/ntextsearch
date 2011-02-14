using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NTextSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearchTestPlugin;
using NTextSearchTestSuite;

namespace TextSearchTestSuite {
    [TestClass()]
    public class TextSearchPluginsTestCases : AbstractTextSearchTestCases {
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
            _testPlugin = new TestPlugin();
            base.MyTestInitialize();
        }

        #endregion

        [TestMethod]
        public void TestRegisterFileToProcess() {
            Assert.AreEqual(0, _testPlugin.FilesToProcess.Count);
            Assert.AreEqual(0, _textSearchEventArgs.Count);
            using (var file = FSHelper.CreateFileTst(_fsHelper.TestFolder.FullName)) {
                _testPlugin.RegisterFileToProcess(file.FullName);
                Assert.AreEqual(1, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(1, _textSearchEventArgs.Count);
                Assert.AreEqual(TextSearchStatus.TargetTextNotSpecified, _textSearchEventArgs[0].TextSearchStatus);
            }
        }

        [TestMethod]
        public void TestPerformPositiveTextSearch() {
            PerformTextSearch(TEST_TEXT, TEST_TEXT, TextSearchStatus.TextFoundInFile);
        }

        [TestMethod]
        public void TestPerformNegativeTextSearch() {
            PerformTextSearch(MISMATCH_TEST_TEXT, TEST_TEXT, TextSearchStatus.TextNotFoundInFile);
        }

        private void PerformTextSearch(string targetText, string textInFile, TextSearchStatus expectedStatus) {
            Assert.AreEqual(0, _textSearchEventArgs.Count);
            using (var file = FSHelper.CreateFileTst(_fsHelper.TestFolder.FullName, textInFile)) {
                _testPlugin.TargetText = targetText;
                Assert.AreEqual(1, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(0, _textSearchEventArgs.Count);
                _testPlugin.RegisterFileToProcess(file.FullName);
                var textSearchEventArg = _textSearchEventArgs[0];
                Assert.AreEqual(0, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(1, _textSearchEventArgs.Count);
                Assert.AreEqual(expectedStatus, textSearchEventArg.TextSearchStatus);
                Assert.AreEqual(file.FullName, textSearchEventArg.FullFileName);
            }
        }

        [TestMethod]
        public void TestRegisterSeveralFilesAndResetByNewSearch() {
            using (var file1 = FSHelper.CreateFileTst(_fsHelper.TestFolder.FullName)) {
                using (var file2 = FSHelper.CreateFileTst(_fsHelper.TestFolder.FullName)) {
                    _testPlugin.TargetText = TEST_TEXT;
                    _testPlugin.RegisterFileToProcess(file1.FullName);
                    _testPlugin.RegisterFileToProcess(file2.FullName);
                    Assert.AreEqual(2, _testPlugin.FilesToProcess.Count);
                    _testPlugin.TargetText = TEST_TEXT;
                    Assert.AreEqual(2, _testPlugin.FilesToProcess.Count);
                    _testPlugin.TargetText = MISMATCH_TEST_TEXT;
                    Assert.AreEqual(0, _testPlugin.FilesToProcess.Count);
                }
            }
        }

        [TestMethod]
        public void TestSplitString(){
            string[] lines = Regex.Split("123 456..-789-098/765+432\r\n123", @"[^\w]");
            Assert.IsTrue(lines.Length > 6);
        }
    }
}
