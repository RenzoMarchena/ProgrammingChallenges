using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.Interfaces;
using System.Linq;


namespace SearchFight.Tests
{
    [TestClass()]
    public class SearchResultsAnalyzerTests
    {
        [TestMethod()]
        public void GetResultsByProgrammingLanguageTest()
        {
            var sra = new SearchResultsAnalyzer();
            var results = sra.GetResultsByProgrammingLanguage
                                                (new SearchResult[]
                                                    {
                                                     new SearchResult { Query =".net",
                                                                        SearchEngineUsed ="Google",
                                                                        NumberOfResults = 1900000 },
                                                     new SearchResult { Query ="java",
                                                                        SearchEngineUsed ="Google",
                                                                        NumberOfResults = 2900000 },
                                                     new SearchResult { Query =".net",
                                                                        SearchEngineUsed ="MSN Search",
                                                                        NumberOfResults = 19001200 },
                                                     new SearchResult { Query ="java",
                                                                        SearchEngineUsed ="MSN Search",
                                                                        NumberOfResults = 800000 }
                                                     }
                                                 );

            Assert.IsTrue(results.Count() == 2);
            Assert.IsTrue(results.Intersect(new string[] { ".net: Google: 1900000 MSN Search: 19001200 ",
                                                          "java: Google: 2900000 MSN Search: 800000 " }).Count() == 2);
        }

        [TestMethod()]
        public void GetWinnerBySearchEngineTest()
        {
            var sra = new SearchResultsAnalyzer();
            var winners = sra.GetWinnerBySearchEngine
                                                (new SearchResult[]
                                                    {
                                                     new SearchResult { Query =".net",
                                                                        SearchEngineUsed ="Google",
                                                                        NumberOfResults = 1900000 },
                                                     new SearchResult { Query ="java",
                                                                        SearchEngineUsed ="Google",
                                                                        NumberOfResults = 2900000 },
                                                     new SearchResult { Query =".net",
                                                                        SearchEngineUsed ="MSN Search",
                                                                        NumberOfResults = 19001200 },
                                                     new SearchResult { Query ="java",
                                                                        SearchEngineUsed ="MSN Search",
                                                                        NumberOfResults = 800000 }
                                                     }
                                                 );

            Assert.IsTrue(winners.Count() == 2);
            Assert.IsTrue(winners.Intersect(new string[] { "Google winner: java",
                                                          "MSN Search winner: .net" }).Count() == 2);



        }
    }
}