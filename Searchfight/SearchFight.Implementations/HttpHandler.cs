using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SearchFight.Interfaces;

namespace SearchFight.Implementations
{
    public class HttpHandler : IHttpHandler
    {
        private HttpClient client;

        public HttpHandler()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public HttpResponseMessage Get(string url)
        {
            
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return client.GetAsync(url);
        }

        public Task<HttpResponseMessage> GetAsync(string url, HttpContent content)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            throw new NotImplementedException();
        }

        public void AddRequestHeader(string name,string value)
        {
            client.DefaultRequestHeaders.Add(name, value);
        }
    }
}
