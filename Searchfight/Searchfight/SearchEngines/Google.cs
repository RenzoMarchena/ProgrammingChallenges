using System;
using System.Net.Http;
using SearchFight.Interfaces;

namespace SearchFight.SearchEngines
{
    public class Google : SearchEngineAPI, ISearch
    {
        private string apiKey = "AIzaSyAs-bKqh7pFBemXadxNDJ6TsrtmAzsqDfY";
        private string customSearchEngineID = "017576662512468239146:omuauf_lfve";
        private string uri = "https://www.googleapis.com/customsearch/v1/";
        

        public SearchResult Search(string stringToSearch) 
       {
                return Search(this.uri, stringToSearch);    
        }

        public override string AddParammeters(string absolutePath, string stringToSearch)
        {
            return absolutePath + "?key=" + this.apiKey + "&cx=" + this.customSearchEngineID + "&q=" + stringToSearch;
        }

        public override void AddApiKey(HttpClient client)
        {
            
        }

        public override long GetTotalResults(dynamic jObj)
        {
            return Convert.ToInt64(jObj["queries"]["request"][0]["totalResults"]);
        }
        public override string ToString()
        {
            return "Google";
        }


    }
}
