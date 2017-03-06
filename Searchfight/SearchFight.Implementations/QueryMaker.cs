using System.Collections.Generic;
using SearchFight.Interfaces;
using System;

namespace SearchFight.Implementations
{
    public class QueryMaker : IQueryMaker 
    {
        private readonly IEnumerable<ISearchEngine> supportedSearchEngines;

        public QueryMaker(IEnumerable<ISearchEngine> supportedSearchEngines)
        {
            if (supportedSearchEngines == null) throw new ArgumentNullException("supportedSearchEngines");
            this.supportedSearchEngines = supportedSearchEngines;
        }

        public IEnumerable<ISearchResult> QuerySearchEngines(IEnumerable<string> searchTerms)
        {
            var searchResults = new List<ISearchResult>();

            foreach (var searchTerm in searchTerms)
            {
                foreach (var searchEngine in supportedSearchEngines)
                {
                        var searchResult = searchEngine.Search(searchTerm);
                        searchResults.Add(searchResult);
                }
            }

            return searchResults;
  
        }

        
    }
}
