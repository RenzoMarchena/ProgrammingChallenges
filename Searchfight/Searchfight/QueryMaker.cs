using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using SearchFight.Interfaces;

namespace SearchFight
{
    public class QueryMaker : IQueryMaker 
    {
        public IEnumerable<SearchResult> QuerySearchEngines(IEnumerable<string> queries)
        {
            var searchResults = new List<SearchResult>();
            var supportedSearchEngines = GetSupportedSearchEngines();

            foreach (var query in queries)
            {
                foreach (var searchEngine in supportedSearchEngines)
                {
                    try
                    {
                        var searchResult = searchEngine.Search(query);
                        searchResults.Add(searchResult);
                    }
                    catch (TimeoutException ex)
                    {


                    }
                }
            }

            return searchResults;
  
        }

        private IEnumerable<ISearch> GetSupportedSearchEngines()
        {

            var supportedSearchEngines = from t in Assembly.GetExecutingAssembly().GetTypes()
                                         where t.GetInterfaces().Contains(typeof(ISearch))
                                         && t.GetConstructor(Type.EmptyTypes) != null
                                         select Activator.CreateInstance(t) as ISearch;

            return supportedSearchEngines;

        }
    }
}
