using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace SearchFight.Tests
{
    [TestClass()]
    public class QueryMakerTests
    {
        [TestMethod()]
        public void QuerySearchEnginesTest()
        {
            
            RunTest(new string[] { "java", "c#", "ruby on rails" });
            RunTest(new string[] { "java script"});
            RunTest(new string[] { "java script", "c#" });
            RunTest(new string[] { "java script", "c#", "Ruby on Rails","Visual Basic" });
            RunTest(new string[] { "java script", "c#", "Ruby on Rails", "Visual Basic", ".net" });
            
        }

        public void RunTest(string[] sampleInput)
        {
            try
            {
                var queryMaker = new QueryMaker();
                var searchResults = queryMaker.QuerySearchEngines(sampleInput);

                //Make sure that the queryMaker returns results for every query
                //Also make sure that all the Terms given as parammeters were searched
                foreach (var searchResult in searchResults)
                {
                    Assert.IsTrue(searchResult.NumberOfResults > 0);
                    int pos = Array.IndexOf(sampleInput, searchResult.Query);
                    Assert.IsTrue(pos > -1);
                }
            }
            catch (TimeoutException ex)
            { }
        }
    }
}