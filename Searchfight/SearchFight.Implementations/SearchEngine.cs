using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchFight.Interfaces;
using SearchFight.Exceptions;

namespace SearchFight.Implementations
{
    public abstract class SearchEngine : ISearchEngine
    {
        protected readonly IHttpHandler httpHandler;
       
        public SearchEngine(IHttpHandler httpHandler)
        {
            if (httpHandler == null) throw new ArgumentNullException("httpHandler");
            this.httpHandler = httpHandler;
        }
        public ISearchResult Search(string searchTerm)
        {
            AddRequestHeaders();

            try
            {
                var response = httpHandler.GetAsync(GetUrl(searchTerm)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    return Parse(json, searchTerm);
                }
                else
                {
                    throw new SearchEngineResponseException();
                }
            }
            catch (AggregateException ex)
            {
                ex.Handle((x) =>
                {
                    if (x is TimeoutException)
                    {
                        throw new TimeOutException();
                    }
                    else if (x is HttpRequestException)
                    {
                        throw new ConnectionException();
                    }
                    throw x;
                });

                throw ex;
            }
        }

        private ISearchResult Parse(string json,string searchTerm)
        {
            //Deserialize the string to JSON object
            dynamic jObj = (JObject)JsonConvert.DeserializeObject(json);
   
            var searchResult = new SearchResult();

            searchResult.SearchEngineUsed = ToString();
            searchResult.SearchTerm = searchTerm;
            searchResult.NumberOfResults = GetTotalResults(jObj);

            return searchResult;
        }

        protected abstract string GetUrl(string searchTerm);
        protected abstract void AddRequestHeaders();
        protected abstract long GetTotalResults(dynamic jObj);
    }
}