using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SearchFight.Interfaces;

namespace SearchFight.Tests
{
    public class HttpHandlerMock : IHttpHandler
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
            return null;
            //return client.GetAsync(url);
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
