using System.Collections.Generic;
 
namespace SearchFight.Interfaces
{
    public interface IQueryMaker
    {
        IEnumerable<ISearchResult> QuerySearchEngines(IEnumerable<string> searchTerms);
         
    }
}
