using SearchFight.Interfaces;

namespace SearchFight.Implementations
{
    public class SearchResult:ISearchResult
    {
        public string SearchEngineUsed { get; set; }

        public string Query { get; set; }

        public long NumberOfResults { get; set; }
    }
}
