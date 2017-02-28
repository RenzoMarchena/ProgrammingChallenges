using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchFight.Interfaces;
using SearchFight.Exceptions;

namespace SearchFight.SearchEngines
{
    public abstract class SearchEngine:ISearchEngine
    {
        public SearchResult Search(string stringToSearch)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(GetUri());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AddApiKey(client);

            HttpResponseMessage response;

            try
            {
                response = client.GetAsync(AddParammeters(client.BaseAddress.AbsolutePath, stringToSearch)).Result;
            }
            catch (AggregateException ex)
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
                //handle TimeOut here
                throw new TimeOutException(); 

            }
            var searchResult = new SearchResult();

            searchResult.SearchEngineUsed = ToString();
            searchResult.Query = stringToSearch;
            searchResult.NumberOfResults = totalResults;

            return searchResult;
        }

        protected abstract string AddParammeters(string absolutePath, string stringToSearch);

        protected abstract void AddApiKey(HttpClient client);

        protected abstract long GetTotalResults(dynamic jObj);

        protected abstract string GetUri();
    }
}