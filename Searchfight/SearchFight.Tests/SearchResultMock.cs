using SearchFight.Interfaces;

namespace SearchFight.Tests
{
    public class SearchResultMock : ISearchResult
    {
        public string SearchEngineUsed { get; set; }

        public string SearchTerm { get; set; }

        public long NumberOfResults { get; set; }
    }
}
