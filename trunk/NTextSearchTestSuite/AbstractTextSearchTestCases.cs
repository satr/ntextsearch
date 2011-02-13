using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearch;
using NTextSearchTestPlugin;

namespace NTextSearchTestSuite{
    [TestClass]
    public abstract class AbstractTextSearchTestCases {
        protected static FSHelper _fsHelper;
        protected static Engine _engine;
        protected static DirectoryInfo _testFolder;
        protected DirectoryInfo _testSubFolderLevel1;
        protected DirectoryInfo _testSubFolderLevel2;
        protected readonly string TEST_TEXT = Guid.NewGuid().ToString();
        protected readonly string MISMATCH_TEST_TEXT = Guid.NewGuid().ToString();
        protected readonly string EMPTY_TEXT = string.Empty;
        protected readonly List<TextSearchEventArg> _textSearchEventArgs = new List<TextSearchEventArg>();
        protected ITextSearch _testPlugin;

        public TestContext TestContext { get; set; }

        #region Additional test attributes
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext) {
            _fsHelper = new FSHelper();
            _testFolder = _fsHelper.TestFolder;
            _engine = new Engine();
        }

        [ClassCleanup]
        public static void MyClassCleanup() {
            if (_fsHelper != null)
                _fsHelper.Dispose();
        }

        [TestInitialize]
        public virtual void MyTestInitialize() {
            _testSubFolderLevel1 = _fsHelper.CreateSubFolder();
            _testSubFolderLevel2 = _fsHelper.CreateSubFolder(_testSubFolderLevel1.FullName);
            _textSearchEventArgs.Clear();
            if (_testPlugin == null)
                throw new InvalidOperationException("The test plugin is not initialized");
            _testPlugin.OnNotify += testPlugin_OnNotify;
        }

        private void testPlugin_OnNotify(TextSearchEventArg args) {
            _textSearchEventArgs.Add(args);
        }

        [TestCleanup]
        public void MyTestCleanup() {
            _fsHelper.CleanTestFolder();
            if (_testPlugin != null){
                _testPlugin.OnNotify -= testPlugin_OnNotify;
                _testPlugin.Shutdown();
            }
        }
        
        #endregion

    }
}