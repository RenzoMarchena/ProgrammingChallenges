using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using SearchFight.Interfaces;

namespace SearchFight
{
    public class QueryMaker : IQueryMaker 
    {
        private IEnumerable<ISearchEngine> supportedSearchEngines;
        public QueryMaker()
        {
            supportedSearchEngines = GetSupportedSearchEngines();
        }

        public QueryMaker(IEnumerable<ISearchEngine> supportedSearchEngines)
        {
            this.supportedSearchEngines = supportedSearchEngines;
        }

        public IEnumerable<SearchResult> QuerySearchEngines(IEnumerable<string> queries)
        {
            var searchResults = new List<SearchResult>();

            foreach (var query in queries)
            {
                foreach (var searchEngine in supportedSearchEngines)
                {
                        var searchResult = searchEngine.Search(query);
                        searchResults.Add(searchResult);
                }
            }

            return searchResults;
  
        }

        private IEnumerable<ISearchEngine> GetSupportedSearchEngines()
        {

            var supportedSearchEngines = from t in Assembly.GetExecutingAssembly().GetTypes()
                                         where t.GetInterfaces().Contains(typeof(ISearchEngine))
                                         && t.GetConstructor(Type.EmptyTypes) != null
                                         select Activator.CreateInstance(t) as ISearchEngine;

            return supportedSearchEngines;

        }
    }
}
