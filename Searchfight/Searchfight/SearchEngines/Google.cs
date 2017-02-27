using System;
using System.Net.Http;
using SearchFight.Interfaces;

namespace SearchFight.SearchEngines
{
    public class Google : SearchEngine
    {
        private string apiKey = "AIzaSyAs-bKqh7pFBemXadxNDJ6TsrtmAzsqDfY";
        private string customSearchEngineID = "017576662512468239146:omuauf_lfve";
        private string uri = "https://www.googleapis.com/customsearch/v1/";

        protected override string GetUri()
        {
            return uri;
        }
        protected override string AddParammeters(string absolutePath, string stringToSearch)
        {
            return absolutePath + "?key=" + apiKey + "&cx=" + customSearchEngineID + "&q=" + stringToSearch;
        }

        protected override void AddApiKey(HttpClient client)
        {
            
        }

        protected override long GetTotalResults(dynamic jObj)
        {
            return Convert.ToInt64(jObj["queries"]["request"][0]["totalResults"]);
        }
        public override string ToString()
        {
            return "Google";
        }


    }
}
