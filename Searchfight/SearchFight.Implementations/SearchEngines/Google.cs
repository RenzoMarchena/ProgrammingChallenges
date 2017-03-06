using System;
using SearchFight.Interfaces;

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

        protected override string GetUrl(string searchTerm)
        {
            return uri + "?key=" + apiKey + "&cx=" + customSearchEngineID + "&q=" + searchTerm;
        }

        protected override void AddRequestHeaders()
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
