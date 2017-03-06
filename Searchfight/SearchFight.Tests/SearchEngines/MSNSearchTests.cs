using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.Implementations.SearchEngines;
using SearchFight.Tests.HttpHandlerMocks;
using SearchFight.Exceptions;

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
            var msnSearch = new MSNSearch(fakeHttpHandler);

            //Act
            var searchResult = msnSearch.Search("java");

            //Assert
            Assert.AreEqual("java", searchResult.SearchTerm);
            Assert.AreEqual(13300000, searchResult.NumberOfResults);
            Assert.AreEqual("MSN Search", searchResult.SearchEngineUsed);

        }

        [TestMethod()]
        [ExpectedException(typeof(SearchEngineResponseException))]
        public void CannotReturnSearchResultsFromMSNSearchWhenResponseFailed()
        {
            //Arrange
            var fakeHttpHandler = new HttpHandlerMockFailedResponse();
            var msnSearch = new MSNSearch(fakeHttpHandler);

            //Act
            var searchResult = msnSearch.Search(".net");

            //Assert

        }

        [TestMethod()]
        [ExpectedException(typeof(TimeOutException))]
        public void CannotSearchMSNSearchWhenTimeOut()
        {
            //Arrange
            var fakeHttpHandler = new HttpHandlerMockTimeOut();
            var msnSearch = new MSNSearch(fakeHttpHandler);

            //Act
            var searchResult = msnSearch.Search("java");

            //Assert

        }

        [TestMethod()]
        [ExpectedException(typeof(ConnectionException))]
        public void CannotSearchMSNSearchWhenNoConnection()
        {
            //Arrange
            var fakeHttpHandler = new HttpHandlerMockConnectionProblem();
            var msnSearch = new MSNSearch(fakeHttpHandler);

            //Act
            var searchResult = msnSearch.Search("java");

            //Assert

        }

    }
}