using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.Interfaces;
using SearchFight.Tests.SearchEnginesMocks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Implementations.Tests
{
    [TestClass()]
    public class QueryMakerTests
    {
        [TestMethod()]
        public void MakingQueryWithOneProgrammingLanguageReturnsValidSearchResults()
        {
            //Arrange
            var fakeSearchEngines = ReturnSearchEnginesMocks();
            var queryMaker = new QueryMaker(fakeSearchEngines);

            //Act
            var searchResults = queryMaker.QuerySearchEngines(new string[] { "java script" });

            //Assert
            var numberOfSearchEngines = fakeSearchEngines.Count();
            Assert.AreEqual(numberOfSearchEngines, searchResults.Count());
   
            AssertAreValidSearchResults(searchResults, numberOfSearchEngines, "java script");
            AssertNumberOfResutsGreaterOrEqualThanZero(searchResults);

        }

        [TestMethod()]
        public void MakingQueryWithMultipleProgrammingLanguagesReturnsValidSearchResults()
        {
            //Arrange
            var fakeSearchEngines = ReturnSearchEnginesMocks();
            var queryMaker = new QueryMaker(fakeSearchEngines);

            //Act
            var programmingLanguages = new string[] { "java script", "c#", "Ruby on Rails", "Visual Basic", ".net" };
            var searchResults = queryMaker.QuerySearchEngines(programmingLanguages);

            //Assert
            var numberOfSearchEngines = fakeSearchEngines.Count();
            Assert.AreEqual(5 * numberOfSearchEngines, searchResults.Count());

            foreach (var programmingLanguage in programmingLanguages)
            {
                AssertAreValidSearchResults(searchResults, numberOfSearchEngines, programmingLanguage);

            }

            AssertNumberOfResutsGreaterOrEqualThanZero(searchResults);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateQueryMakerWithNullColletionOfSearchEngines()
        {
            // Arrange     

            // Act     
            new QueryMaker(null);

            // Assert

        }

        private static void AssertAreValidSearchResults(IEnumerable<ISearchResult> searchResults, int numberOfSearchEngines, string programmingLanguage)
        {
            var searchesByLanguage = searchResults.Where(searchResult => searchResult.Query == programmingLanguage);

            var numberOfSearchesByLanguage = searchesByLanguage.Count();
            Assert.AreEqual(numberOfSearchEngines, numberOfSearchesByLanguage);

            var searchEnginesUsed = searchesByLanguage.GroupBy(searchResult => searchResult.SearchEngineUsed).Count();
            Assert.AreEqual(searchEnginesUsed, numberOfSearchEngines);
        }

        private static void AssertNumberOfResutsGreaterOrEqualThanZero(IEnumerable<ISearchResult> searchResults)
        {
            var searchesWithZeroOrLessResults = searchResults.Where(searchResult => searchResult.NumberOfResults <= 0).Count();
            Assert.IsTrue(searchesWithZeroOrLessResults == 0);
        }
    
        private IEnumerable<ISearchEngine> ReturnSearchEnginesMocks()
        {
            var google = new GoogleMock();
            var msnSearch = new MSNSearchMock();

            return new List<ISearchEngine> { google, msnSearch };   
            
        }
       
    }
}