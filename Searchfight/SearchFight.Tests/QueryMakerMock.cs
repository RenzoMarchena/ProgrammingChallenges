using System;
using System.Collections.Generic;
using SearchFight.Interfaces;
using SearchFight.Implementations;


namespace SearchFight.Tests
{
    public class QueryMakerMock : IQueryMaker
    {
        public IEnumerable<ISearchResult> QuerySearchEngines(IEnumerable<string> queries)
        {
            return new List<ISearchResult> { new SearchResultMock {SearchEngineUsed="Google",NumberOfResults=1000,Query=".net"},
                                             new SearchResultMock {SearchEngineUsed="MSNSearch",NumberOfResults=2000,Query=".net"},
                                             new SearchResultMock {SearchEngineUsed="Google",NumberOfResults=1000,Query="java"},
                                             new SearchResultMock {SearchEngineUsed="MSNSearch",NumberOfResults=2000,Query="java"} };
        }
    }
}
