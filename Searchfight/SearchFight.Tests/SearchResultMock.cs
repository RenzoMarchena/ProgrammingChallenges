using SearchFight.Interfaces;

namespace SearchFight.Tests
{
    public class SearchResultMock : ISearchResult
    {
        public string SearchEngineUsed { get; set; }

        public string Query { get; set; }

        public long NumberOfResults { get; set; }
    }
}
