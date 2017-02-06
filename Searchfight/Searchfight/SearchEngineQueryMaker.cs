using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Searchfight
{
    public class SearchEngineQueryMaker : ISearchEngineQueryMaker 
    {
        // Makes a single query to the search engines passed as parameters and 
        // returns an enumerable collection of search engine query responses.
        public IEnumerable<SearchEngineQueryResponse> MakeNewQuery(string wordToSearch, params SearchEngine[] searchEngines )
        {
            List<SearchEngineQueryResponse> singleQueryResponses = new List<SearchEngineQueryResponse>();

            for (int i = 0; i < searchEngines.Length; i++)
            {
                switch (searchEngines[i])
                {
                    case SearchEngine.Google:
                        {
                            singleQueryResponses.Add(QueryGoogle(wordToSearch));
                            break;
                        }
                    case SearchEngine.MSNSearch:
                        {
                            singleQueryResponses.Add(QueryMSNSearch(wordToSearch));
                            break;
                        }   
                }
            }

            return singleQueryResponses;
        }

        // Makes a bash query to the search engines passed as parameters and 
        // returns an enumerable collection of search engine query responses.
        public IEnumerable<SearchEngineQueryResponse> MakeNewBashQuery(IEnumerable<string> wordsToSearch, params SearchEngine[] searchEngines )
        {
            List<SearchEngineQueryResponse> bashQueryResponses = new List<SearchEngineQueryResponse>();

            foreach (string word in wordsToSearch)
            {
                IEnumerable<SearchEngineQueryResponse> singleQueryResponses = MakeNewQuery(word, searchEngines);

                foreach (SearchEngineQueryResponse searchQR in singleQueryResponses)
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
            HttpClient client = new HttpClient();

            string apiKey = "AIzaSyAs-bKqh7pFBemXadxNDJ6TsrtmAzsqDfY";
            string customSearchEngineID = "017576662512468239146:omuauf_lfve";
            string uri = "https://www.googleapis.com/customsearch/v1/";

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(client.BaseAddress.AbsolutePath + "?key="+ apiKey
                                                                                           + "&cx=" + customSearchEngineID
                                                                                           + "&q="  + wordToSearch).Result;

            string totalResults = "";

            if (response.IsSuccessStatusCode)
            {
                string strJson = response.Content.ReadAsStringAsync().Result;

                //Deserialize the string to JSON object
                dynamic jObj = (JObject)JsonConvert.DeserializeObject(strJson);

                totalResults = jObj["queries"]["request"][0]["totalResults"];

            }

            SearchEngineQueryResponse searchEngineQR = new SearchEngineQueryResponse();

            searchEngineQR.SearchEngineUsed = SearchEngine.Google;
            searchEngineQR.WordQueried = wordToSearch;
            searchEngineQR.NumberOfResults = Convert.ToInt64(totalResults);


           return searchEngineQR;

        }

        // Makes a single word query to the MSN Search search engine using Bing Web Search API
        // returns a search engine query response.
        private SearchEngineQueryResponse QueryMSNSearch(string wordToSearch)
        {
            HttpClient client = new HttpClient();

            string apiKey = "1f3497a23ded414e9590844d2313fa72";
            string uri = "https://api.cognitive.microsoft.com/bing/v5.0/search";

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
           // ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        
            HttpResponseMessage response = client.GetAsync(client.BaseAddress.AbsolutePath + "?q=" + wordToSearch).Result;
            
            long totalResults = 0;

            if (response.IsSuccessStatusCode)
            {
                string strJson = response.Content.ReadAsStringAsync().Result;

               //Deserialize the string to JSON object
                dynamic jObj = (JObject)JsonConvert.DeserializeObject(strJson);

                totalResults = jObj["webPages"]["totalEstimatedMatches"];
            }

            SearchEngineQueryResponse searchEngineQR = new SearchEngineQueryResponse();

            searchEngineQR.SearchEngineUsed = SearchEngine.MSNSearch;
            searchEngineQR.WordQueried = wordToSearch;
            searchEngineQR.NumberOfResults = totalResults;


            return searchEngineQR;

        }

    }
}
