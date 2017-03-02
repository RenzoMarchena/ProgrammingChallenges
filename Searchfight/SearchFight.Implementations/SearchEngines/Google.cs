using System;
using SearchFight.Interfaces;
using System.Net.Http;

namespace SearchFight.Implementations.SearchEngines
{
    public class Google : SearchEngine
    {
        private const string apiKey = "AIzaSyAs-bKqh7pFBemXadxNDJ6TsrtmAzsqDfY";
        private const string customSearchEngineID = "017576662512468239146:omuauf_lfve";
        private const string uri = "https://www.googleapis.com/customsearch/v1/";

        public Google(IHttpHandler httpHandler):base(httpHandler)
        {

        }
        protected override string GetUri()
        {
            return uri;
        }
        protected override string AddParammeters(string absolutePath, string stringToSearch)
        {
            return absolutePath + "?key=" + apiKey + "&cx=" + customSearchEngineID + "&q=" + stringToSearch;
        }

        protected override void AddApiKey(IHttpHandler httpHandler)
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
