using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchFight.Interfaces;

namespace SearchFight.SearchEngines
{
    public abstract class SearchEngineAPI
    {
        public SearchResult Search(string uri, string stringToSearch)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AddApiKey(client);

            var response = client.GetAsync(AddParammeters(client.BaseAddress.AbsolutePath,stringToSearch)).Result;

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
            }
            var searchResult = new SearchResult();

            searchResult.SearchEngineUsed = ToString();
            searchResult.Query = stringToSearch;
            searchResult.NumberOfResults = totalResults;

            return searchResult;
        }

        public abstract string AddParammeters(string absolutePath, string stringToSearch);

        public abstract void AddApiKey(HttpClient client);

        public abstract long GetTotalResults(dynamic jObj);
    }
}