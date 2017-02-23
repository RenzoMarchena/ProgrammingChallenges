using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Tests
{
    [TestClass()]
    public class QueryMakerTests
    {
        [TestMethod()]
        public void QuerySearchEnginesTest()
        {
            var queryMaker = new QueryMaker();

            var searchResults = queryMaker.QuerySearchEngines(new string[] { "java", "c#", " ruby on rails " });

            //Make sure that the queryMaker returns results for every query
            foreach (var searchResult in searchResults)
            {
                Assert.IsTrue(searchResult.NumberOfResults > 0);
            }

            //Make sure that the Terms searched were the same as the ones given as parammeters

          /*  var termSearched = searchResults.Select(searchResult => (new { searchResult.Query }).ToString());

            Assert.IsTrue(termSearched.Intersect(new string[] { "java", "c#", " ruby on rails " }).Count() == 2);

           */

        }
    }
}