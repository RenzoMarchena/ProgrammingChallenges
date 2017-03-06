using System;
using System.Net.Http;
using System.Threading.Tasks;
using SearchFight.Interfaces;

namespace SearchFight.Tests.HttpHandlerMocks
{
    public class HttpHandlerMockTimeOut:IHttpHandler
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
                throw new TimeoutException();
                return new HttpResponseMessage();
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
