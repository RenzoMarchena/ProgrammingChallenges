using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight
{
    public interface ISearchEngineQueryMaker
    {
        IEnumerable<SearchEngineQueryResponse> MakeNewQuery(string wordToSearch, params SearchEngine[] searchEngines);
        IEnumerable<SearchEngineQueryResponse> MakeNewBashQuery(IEnumerable<string> wordsToSearch, params SearchEngine[] searchEngines);

    }
}
