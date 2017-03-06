using SearchFight.Interfaces;

namespace SearchFight.Implementations
{
    public class SearchResult:ISearchResult
    {
        public string SearchEngineUsed { get; set; }

        public string SearchTerm { get; set; }

        public long NumberOfResults { get; set; }
    }
}
