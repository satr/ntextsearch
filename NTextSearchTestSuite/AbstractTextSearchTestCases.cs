using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearch;

namespace NTextSearchTestSuite{
    [TestClass]
    public abstract class AbstractTextSearchTestCases {
        private static FSTestHelper _fsTestHelper;
        protected static Engine _engine;
        protected static DirectoryInfo _testFolder;
        protected DirectoryInfo _testSubFolderLevel1;
        protected DirectoryInfo _testSubFolderLevel2;

        public TestContext TestContext { get; set; }

        #region Additional test attributes
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext) {
            _fsTestHelper = new FSTestHelper();
            _testFolder = _fsTestHelper.TestFolder;
            _engine = new Engine();
        }

        [ClassCleanup]
        public static void MyClassCleanup() {
            if (_fsTestHelper != null)
                _fsTestHelper.Dispose();
        }

        [TestInitialize]
        public void MyTestInitialize() {
            _testSubFolderLevel1 = _fsTestHelper.CreateSubFolder();
            _testSubFolderLevel2 = _fsTestHelper.CreateSubFolder(_testSubFolderLevel1.FullName);
        }

        [TestCleanup]
        public void MyTestCleanup() {
            _fsTestHelper.CleanTestFolder();
        }
        
        #endregion

    }
}