﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.Implementations.SearchEngines;
using SearchFight.Tests.HttpHandlerMocks;
using SearchFight.Exceptions;

namespace SearchFight.Tests
{
    [TestClass()]
    public class GoogleTests
    {
        [TestMethod()]
        public void SearchingGoogleReturnsValidSearchResult()
        {
            //Arrange
            var fakeHttpHandler = new HttpHandlerMockGoogle();
            var google = new Google(fakeHttpHandler);

            //Act
            var searchResult = google.Search(".net");

            //Assert
            Assert.AreEqual(".net", searchResult.SearchTerm);
            Assert.AreEqual(1560000000, searchResult.NumberOfResults);
            Assert.AreEqual("Google", searchResult.SearchEngineUsed);

        }

        [TestMethod()]
        [ExpectedException(typeof(TimeOutException))]
        public void CannotSearchGoogleWhenTimeOut()
        {
            //Arrange
            var fakeHttpHandler = new HttpHandlerMockTimeOut();
            var google = new Google(fakeHttpHandler);

            //Act
            var searchResult = google.Search(".net");

            //Assert
            

        }

    }
}