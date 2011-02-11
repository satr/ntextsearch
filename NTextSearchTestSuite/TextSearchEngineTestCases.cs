using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearchLib;

namespace NTextSearchTestSuite {
    /// <summary>
    /// Summary description for TextSearchEngineTestCases
    /// </summary>
    [TestClass]
    public class TextSearchEngineTestCases {
        private TestContext testContextInstance;
        private static FSTestHelper _fsTestHelper;
        private static Engine _engine;
        private static string _testFolderPath;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
         [ClassInitialize()]
         public static void MyClassInitialize(TestContext testContext){
             _fsTestHelper = new FSTestHelper();
             _testFolderPath = _fsTestHelper.TestFolder.FullName;
             _engine = new Engine();
         }

        //
        // Use ClassCleanup to run code after all tests in a class have run
         [ClassCleanup()]
         public static void MyClassCleanup(){
             if (_fsTestHelper != null)
                 _fsTestHelper.Dispose();
         }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetFilesInEmptyFolder(){
             Assert.AreEqual(0, _engine.GetFilesInFolder(_testFolderPath).Length);
        }

        [TestMethod]
        public void TestGetFilesFromNotEmptyFolder(){
            using (var file = FSTestHelper.CreateFileTxt(_testFolderPath)){
                Assert.IsTrue(0 < _engine.GetFilesInFolder(_testFolderPath).Length);
            }
        }

        [TestMethod]
        public void TestGetFilesFromFolderRecursive() {
            _fsTestHelper.CleanTestFolder();
            var subFolder1 = _fsTestHelper.CreateSubFolder();
            var subFolder2 = _fsTestHelper.CreateSubFolder(subFolder1.FullName);
            using(var file1 = FSTestHelper.CreateFileTxt(_testFolderPath))
            using(var file2 = FSTestHelper.CreateFileTxt(subFolder1.FullName))
            using(var file3 = FSTestHelper.CreateFileTxt(subFolder2.FullName))
            {
                Assert.AreEqual(3, _engine.GetFilesInFolder(_testFolderPath, true).Length);
            }
        }
    }
}
