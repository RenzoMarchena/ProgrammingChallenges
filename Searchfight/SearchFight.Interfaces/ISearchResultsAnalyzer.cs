using System.Collections.Generic;

namespace SearchFight.Interfaces
{
    public interface ISearchResultsAnalyzer
    {
        IEnumerable<string> GetResultsByProgrammingLanguage(IEnumerable<SearchResult> searchResults);
        IEnumerable<string> GetWinnerBySearchEngine(IEnumerable<SearchResult> searchResults);

    } 
}
