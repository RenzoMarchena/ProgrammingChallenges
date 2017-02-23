
using System.Collections.Generic;


namespace Searchfight
{
    public interface ISearchEngineQueryMaker
    {
        IEnumerable<SearchEngineQueryResponse> MakeNewQuery(string wordToSearch);
        IEnumerable<SearchEngineQueryResponse> MakeNewBashQuery(IEnumerable<string> wordsToSearch);
         

    }
}
