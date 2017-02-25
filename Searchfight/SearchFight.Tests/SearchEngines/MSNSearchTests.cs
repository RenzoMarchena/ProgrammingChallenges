using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.SearchEngines;
using System;

namespace SearchFight.Tests
{
    [TestClass()]
    public class MSNSearchTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            RunTest("java");
            RunTest("java script");
            RunTest("  java");
            RunTest("Ruby on Rails");
            RunTest("C#");
        }

        private void RunTest(string stringToSearch)
        {
            try
            {
                var msnSearch = new MSNSearch();
                var searchResult = msnSearch.Search(stringToSearch);

                Assert.IsTrue(searchResult.NumberOfResults > 0);
                Assert.IsTrue(searchResult.Query == stringToSearch);
                Assert.IsTrue(searchResult.SearchEngineUsed == "MSN Search");
            }
            catch (Exception ex)
            { }
        }
    }
}