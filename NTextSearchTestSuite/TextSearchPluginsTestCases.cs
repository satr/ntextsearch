﻿using System;
using System.Collections.Generic;
using NTextSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearchTestPlugin;
using NTextSearchTestSuite;

namespace TextSearchTestSuite {
    [TestClass()]
    public class TextSearchPluginsTestCases : AbstractTextSearchTestCases {
        readonly string TEST_TEXT = Guid.NewGuid().ToString();
        readonly string MISMATCH_TEST_TEXT = Guid.NewGuid().ToString();
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

        private void testPlugin_OnTextFound(TextSearchEventArg args) {
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
        public void TestRegisterFileToProcess() {
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
        public void TestPerformPositiveTextSearch() {
            PerformTextSearch(TEST_TEXT, TEST_TEXT, TextSearchStatus.TextFoundInFile);
        }

        [TestMethod]
        public void TestPerformNegativeTextSearch() {
            PerformTextSearch(MISMATCH_TEST_TEXT, TEST_TEXT, TextSearchStatus.TextNotFoundInFile);
        }

        private void PerformTextSearch(string targetText, string textInFile, TextSearchStatus expectedStatus) {
            Assert.AreEqual(0, _textSearchEventArgs.Count);
            using (var file = FSTestHelper.CreateFileTst(_fsTestHelper.TestFolder.FullName, textInFile)) {
                _testPlugin.TargetText = targetText;
                _testPlugin.RegisterFileToProcess(file.FullName);
                Assert.AreEqual(1, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(0, _textSearchEventArgs.Count);
                _testPlugin.PerformSearch();
                var textSearchEventArg = _textSearchEventArgs[0];
                Assert.AreEqual(0, _testPlugin.FilesToProcess.Count);
                Assert.AreEqual(1, _textSearchEventArgs.Count);
                Assert.AreEqual(expectedStatus, textSearchEventArg.TextSearchStatus);
                Assert.AreEqual(file.FullName, textSearchEventArg.FullFileName);
            }
        }

        [TestMethod]
        public void TestRegisterSeveralFilesAndResetByNewSearch() {
            using (var file1 = FSTestHelper.CreateFileTst(_fsTestHelper.TestFolder.FullName)) {
                using (var file2 = FSTestHelper.CreateFileTst(_fsTestHelper.TestFolder.FullName)) {
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
    }
}
