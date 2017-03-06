using SearchFight.Interfaces;

namespace SearchFight.Tests.SearchEnginesMocks
{
    public class MSNSearchMock : ISearchEngine
    {
        public ISearchResult Search(string stringToSearch)
        {
            var searchResultMock = new SearchResultMock();
            searchResultMock.SearchTerm = stringToSearch;
            searchResultMock.SearchEngineUsed = "MSNSearch";
            searchResultMock.NumberOfResults = 1000;

            return searchResultMock;
        }
    }
}
