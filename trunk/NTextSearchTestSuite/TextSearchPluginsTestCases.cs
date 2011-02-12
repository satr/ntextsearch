using NTextSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTextSearchTestSuite;

namespace TextSearchTestSuite
{
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
        #endregion

    }
}
