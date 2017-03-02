using SearchFight.Interfaces;

namespace SearchFight.Tests.SearchEnginesMocks
{
    public class GoogleMock : ISearchEngine
    {
        public ISearchResult Search(string stringToSearch)
        {
            var searchResultMock =  new SearchResultMock();
            searchResultMock.Query = stringToSearch;
            searchResultMock.SearchEngineUsed = "Google";
            searchResultMock.NumberOfResults = 1000;

            return searchResultMock;
        }

        
    }
}
