using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SearchFight.Tests;
using System.Linq;

namespace SearchFight.Controller.Tests
{
    [TestClass()]
    public class SearchFightControllerTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateControllerWithNullQueryMaker()
        {
            // Arrange     

            // Act     
            new SearchFightController(null);

            // Assert

        }


        [TestMethod()]
        public void SearchFightControllerReturnsValidViewModel()
        {
            //Arrange
            var fakeQueryMaker = new QueryMakerMock();
            var searchFightCon = new SearchFightController(fakeQueryMaker);

            //Act
            var sampleInput = new string[] { ".net", "java" };
            var viewModel = searchFightCon.StartSearchFight(sampleInput);

            //Assert

            var expectedViewModel = new ViewModel.SearchResult[] {  new ViewModel.SearchResult {SearchEngineUsed="Google",NumberOfResults=1000,ProgrammingLanguage=".net"},
                                                                    new ViewModel.SearchResult {SearchEngineUsed="MSNSearch",NumberOfResults=2000,ProgrammingLanguage=".net"},
                                                                    new ViewModel.SearchResult {SearchEngineUsed="Google",NumberOfResults=1000,ProgrammingLanguage="java"},
                                                                    new ViewModel.SearchResult {SearchEngineUsed="MSNSearch",NumberOfResults=2000,ProgrammingLanguage="java"} };

            Assert.AreEqual(viewModel.Count(), expectedViewModel.Count());
            foreach (var searchResult in viewModel)
            {
                Assert.IsTrue(searchResult.NumberOfResults > 0);
                int pos = Array.IndexOf(sampleInput, searchResult.ProgrammingLanguage);
                Assert.IsTrue(pos > -1);
            }
        }
    }
}