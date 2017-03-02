using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchFight.Interfaces;
using SearchFight.Exceptions;

namespace SearchFight.Implementations
{
    public abstract class SearchEngine:ISearchEngine
    {
        private readonly IHttpHandler httpHandler;
        public SearchEngine(IHttpHandler httpHandler)
        {
            if (httpHandler == null) throw new ArgumentNullException("httpHandler");
            this.httpHandler = httpHandler;
        }
        public ISearchResult Search(string stringToSearch)
        {
            AddApiKey(httpHandler);

            HttpResponseMessage response;

            try
            {
                response = httpHandler.GetAsync(AddParammeters(GetUri(), stringToSearch)).Result;
            }
            catch (Exception ex)
            {
                throw new NoInternetConnectionException();
            }

            long totalResults = 0;

            if (response.IsSuccessStatusCode)
            {
                var strJson = response.Content.ReadAsStringAsync().Result;

                //Deserialize the string to JSON object
                dynamic jObj = (JObject)JsonConvert.DeserializeObject(strJson);
                totalResults = GetTotalResults(jObj);

            }
            else
            {
                throw new TimeOutException(); 
            }

            var searchResult = new SearchResult();

            searchResult.SearchEngineUsed = ToString();
            searchResult.Query = stringToSearch;
            searchResult.NumberOfResults = totalResults;

            return searchResult;
        }

        protected abstract string AddParammeters(string absolutePath, string stringToSearch);

        protected abstract void AddApiKey(IHttpHandler httpHandler);

        protected abstract long GetTotalResults(dynamic jObj);

        protected abstract string GetUri();
    }
}