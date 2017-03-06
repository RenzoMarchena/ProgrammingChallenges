using System.Collections.Generic;
using SearchFight.Interfaces;

namespace SearchFight.Tests
{
    public class QueryMakerMock : IQueryMaker
    {
        public IEnumerable<ISearchResult> QuerySearchEngines(IEnumerable<string> queries)
        {
            return new List<ISearchResult> { new SearchResultMock {SearchEngineUsed="Google",NumberOfResults=1000,SearchTerm=".net"},
                                             new SearchResultMock {SearchEngineUsed="MSNSearch",NumberOfResults=2000,SearchTerm=".net"},
                                             new SearchResultMock {SearchEngineUsed="Google",NumberOfResults=1000,SearchTerm="java"},
                                             new SearchResultMock {SearchEngineUsed="MSNSearch",NumberOfResults=2000,SearchTerm="java"} };
        }
    }
}
