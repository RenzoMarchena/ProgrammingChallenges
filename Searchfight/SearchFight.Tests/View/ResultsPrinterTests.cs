using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.View.Tests
{
    [TestClass()]
    public class ResultsPrinterTests
    {
        [TestMethod()]
        public void GetResultsByProgrammingLanguageTest()
        {
            var searchResults = new Model.SearchResult[]
                                                    {
                                                     new Model.SearchResult { Query =".net",
                                                                        SearchEngineUsed ="Google",
                                                                        NumberOfResults = 1900000 },
                                                     new Model.SearchResult { Query ="java",
                                                                        SearchEngineUsed ="Google",
                                                                        NumberOfResults = 2900000 },
                                                     new Model.SearchResult { Query =".net",
                                                                        SearchEngineUsed ="MSN Search",
                                                                        NumberOfResults = 19001200 },
                                                     new Model.SearchResult { Query ="java",
                                                                        SearchEngineUsed ="MSN Search",
                                                                        NumberOfResults = 800000 }
                                                     };

            var results = ResultsPrinter.GetResultsByProgrammingLanguage(searchResults);

            Assert.IsTrue(results.Count() == 2);
            Assert.IsTrue(results.Intersect(new string[] { ".net: Google: 1900000 MSN Search: 19001200 ",
                                                          "java: Google: 2900000 MSN Search: 800000 " }).Count() == 2);
        }

        [TestMethod()]
        public void GetWinnerBySearchEngineTest()
        {
            var searchResults = new Model.SearchResult[]
                                                    {
                                                     new Model.SearchResult { Query =".net",
                                                                        SearchEngineUsed ="Google",
                                                                        NumberOfResults = 1900000 },
                                                     new Model.SearchResult { Query ="java",
                                                                        SearchEngineUsed ="Google",
                                                                        NumberOfResults = 2900000 },
                                                     new Model.SearchResult { Query =".net",
                                                                        SearchEngineUsed ="MSN Search",
                                                                        NumberOfResults = 19001200 },
                                                     new Model.SearchResult { Query ="java",
                                                                        SearchEngineUsed ="MSN Search",
                                                                        NumberOfResults = 800000 }
                                                     };
            var winners = ResultsPrinter.GetWinnerBySearchEngine(searchResults);
                                         

            Assert.IsTrue(winners.Count() == 2);
            Assert.IsTrue(winners.Intersect(new string[] { "Google winner: java",
                                                          "MSN Search winner: .net" }).Count() == 2);

        }
    }
}