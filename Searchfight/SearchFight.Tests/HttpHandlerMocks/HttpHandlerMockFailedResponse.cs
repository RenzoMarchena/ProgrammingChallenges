using System;
using System.Net.Http;
using System.Threading.Tasks;
using SearchFight.Interfaces;

namespace SearchFight.Tests.HttpHandlerMocks
{
    public class HttpHandlerMockFailedResponse : IHttpHandler
    {
        public void AddRequestHeader(string name, string value)
        {
            
        }

        public HttpResponseMessage Get(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return Task.Run(() =>
            {
                var response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            });
        }

        public Task<HttpResponseMessage> GetAsync(string url, HttpContent content)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            throw new NotImplementedException();
        }
    }
}
