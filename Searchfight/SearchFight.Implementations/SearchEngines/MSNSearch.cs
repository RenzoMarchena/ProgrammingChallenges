using System.Net.Http;
using SearchFight.Interfaces;

namespace SearchFight.Implementations.SearchEngines
{
    public class MSNSearch : SearchEngine
    {
        private const string apiKey = "1f3497a23ded414e9590844d2313fa72";
        private const string uri = "https://api.cognitive.microsoft.com/bing/v5.0/search";

        public MSNSearch(IHttpHandler httpHandler) : base(httpHandler)
        {

        }
        protected override string GetUri()
        {
            return uri;
        }
        protected override string AddParammeters(string absolutePath, string stringToSearch)
        {
            return absolutePath + "?q=" + stringToSearch;
        }

        protected override void AddApiKey(IHttpHandler httpHandler)
        {
           httpHandler.AddRequestHeader("Ocp-Apim-Subscription-Key", apiKey);
        }

        protected override long GetTotalResults(dynamic jObj)
        {
            return jObj["webPages"]["totalEstimatedMatches"];
        }
        public override string ToString()
        {
            return "MSN Search";
        }

    }
}
