using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.Implementations.SearchEngines;
using SearchFight.Tests.HttpHandlerMocks;

namespace SearchFight.Tests
{
    [TestClass()]
    public class MSNSearchTests
    {
       [TestMethod()]
        public void SearchingMSNSearchReturnsValidSearchResult()
        {
            //Arrange
            var fakeHttpHandler = new HttpHandlerMockMSNSearch();
            var google = new MSNSearch(fakeHttpHandler);

            //Act
            var searchResult = google.Search("java");

            //Assert
            Assert.AreEqual("java", searchResult.Query);
            Assert.AreEqual(13300000, searchResult.NumberOfResults);
            Assert.AreEqual("MSN Search", searchResult.SearchEngineUsed);

        }
    }
}