using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SearchFight.ViewModel;
using System.Linq;

namespace SearchFight.View.Tests
{
    [TestClass()]
    public class ResultsPrinterTests
    {
        [TestMethod()]
        public void GettingResultsByProgrammingLanguageReturnsExpectedLineForOneSearchTerm()
        {
            //Arrange
            var searchResults = new List<SearchResult> { new SearchResult {SearchEngineUsed="Google",NumberOfResults=1000,ProgrammingLanguage=".net"},
                                             new SearchResult {SearchEngineUsed="MSN Search",NumberOfResults=2000,ProgrammingLanguage=".net"}};
            //Act
            var lines = ResultsPrinter.GetResultsByProgrammingLanguage(searchResults);
            
            //Assert
            var expectedLine = ".net: Google: 1000 MSN Search: 2000 ";
            foreach (var line in lines)
            {
                Assert.AreEqual(line, expectedLine);
            }
            
        }

        [TestMethod()]
        public void GettingResultsByProgrammingLanguageReturnsExpectedLinesForMultipleSearchTerms()
        {
            //Arrange
            var searchResults = new List<SearchResult> { new SearchResult {SearchEngineUsed="Google",NumberOfResults=1000,ProgrammingLanguage=".net"},
                                                         new SearchResult {SearchEngineUsed="MSN Search",NumberOfResults=2000,ProgrammingLanguage=".net"},
                                                         new SearchResult {SearchEngineUsed="Google",NumberOfResults=1000,ProgrammingLanguage="java"},
                                                         new SearchResult {SearchEngineUsed="MSN Search",NumberOfResults=2000,ProgrammingLanguage="java"}};
            //Act
            var lines = ResultsPrinter.GetResultsByProgrammingLanguage(searchResults);

            //Assert
            var expectedLines = new List<string> { ".net: Google: 1000 MSN Search: 2000 ", "java: Google: 1000 MSN Search: 2000 " };

            Assert.IsTrue(lines.Intersect(expectedLines).Count() == lines.Count());
        }

        public void GettingWinnerBySearchEngineReturnsExpectedLinesForOneSearchTerm()
        {
            //Arrange
            var searchResults = new List<SearchResult> { new SearchResult {SearchEngineUsed="Google",NumberOfResults=1000,ProgrammingLanguage=".net"},
                                             new SearchResult {SearchEngineUsed="MSN Search",NumberOfResults=2000,ProgrammingLanguage=".net"}};
            //Act
            var lines = ResultsPrinter.GetWinnerBySearchEngine(searchResults);

            //Assert
            var expectedLines = new List<string> { "Google winner: .net", "MSN Search winner: .net" };

            Assert.IsTrue(lines.Intersect(expectedLines).Count() == lines.Count());
        }
    }
}