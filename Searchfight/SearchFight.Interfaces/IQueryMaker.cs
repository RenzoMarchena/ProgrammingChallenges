using System.Collections.Generic;
 
namespace SearchFight.Interfaces
{
    public interface IQueryMaker
    {
        IEnumerable<SearchResult> QuerySearchEngines(IEnumerable<string> queries);
         
    }
}
