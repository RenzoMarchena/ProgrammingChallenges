using System.Threading.Tasks;
using System.Net.Http;

namespace SearchFight.Interfaces
{
    public interface IHttpHandler
    {
        HttpResponseMessage Get(string url);
        HttpResponseMessage Post(string url, HttpContent content);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> GetAsync(string url, HttpContent content);
        void AddRequestHeader(string name, string value);
    }
}
