using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Searchfight
{
    public class SearchEngineQueryMaker : ISearchEngineQueryMaker 
    {
        // Makes a single word query to the search engines passed as parameters and 
        // returns an enumerable collection of search engine query responses.
        public IEnumerable<SearchEngineQueryResponse> MakeNewQuery(string wordToSearch)
        {
            var singleQueryResponses = new List<SearchEngineQueryResponse>();

            singleQueryResponses.Add(QueryGoogle(wordToSearch));
            singleQueryResponses.Add(QueryMSNSearch(wordToSearch));
                
            return singleQueryResponses;
        }

        // Makes a bash query to the search engines passed as parameters and 
        // returns an enumerable collection of search engine query responses.
        public IEnumerable<SearchEngineQueryResponse> MakeNewBashQuery(IEnumerable<string> wordsToSearch)
        {
            var bashQueryResponses = new List<SearchEngineQueryResponse>();

            foreach (var word in wordsToSearch)
            {
                var singleQueryResponses = MakeNewQuery(word);

                foreach (var searchQR in singleQueryResponses)
                {
                    bashQueryResponses.Add(searchQR);
                }
            }

            return bashQueryResponses;
        }


        // Makes a single word query to the Google search engine using Custom Search API
        // returns a search engine query response.
        private  SearchEngineQueryResponse QueryGoogle(string wordToSearch)
        {
            var client = new HttpClient();

            var apiKey = "AIzaSyAs-bKqh7pFBemXadxNDJ6TsrtmAzsqDfY";
            var customSearchEngineID = "017576662512468239146:omuauf_lfve";
            var uri = "https://www.googleapis.com/customsearch/v1/";

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(client.BaseAddress.AbsolutePath + "?key="+ apiKey
                                                                                           + "&cx=" + customSearchEngineID
                                                                                           + "&q="  + wordToSearch).Result;

            var totalResults = "";

            if (response.IsSuccessStatusCode)
            {
                var strJson = response.Content.ReadAsStringAsync().Result;

                //Deserialize the string to JSON object
                dynamic jObj = (JObject)JsonConvert.DeserializeObject(strJson);

                totalResults = jObj["queries"]["request"][0]["totalResults"];

            }

            var searchEngineQR = new SearchEngineQueryResponse();

            searchEngineQR.SearchEngineUsed = "Google";
            searchEngineQR.WordQueried = wordToSearch;
            searchEngineQR.NumberOfResults = Convert.ToInt64(totalResults);


           return searchEngineQR;

        }

        // Makes a single word query to the MSN Search search engine using Bing Web Search API
        // returns a search engine query response.
        private SearchEngineQueryResponse QueryMSNSearch(string wordToSearch)
        {
            var client = new HttpClient();

            var apiKey = "1f3497a23ded414e9590844d2313fa72";
            var uri = "https://api.cognitive.microsoft.com/bing/v5.0/search";

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
           // ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        
            var response = client.GetAsync(client.BaseAddress.AbsolutePath + "?q=" + wordToSearch).Result;
            
            long totalResults = 0;

            if (response.IsSuccessStatusCode)
            {
                var strJson = response.Content.ReadAsStringAsync().Result;

               //Deserialize the string to JSON object
                dynamic jObj = (JObject)JsonConvert.DeserializeObject(strJson);

                totalResults = jObj["webPages"]["totalEstimatedMatches"];
            }

            var searchEngineQR = new SearchEngineQueryResponse();

            searchEngineQR.SearchEngineUsed = "MSN Search";
            searchEngineQR.WordQueried = wordToSearch;
            searchEngineQR.NumberOfResults = totalResults;


            return searchEngineQR;

        }

    }
}
