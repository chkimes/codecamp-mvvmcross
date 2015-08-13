using System;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MvvmCross.Demo.Core
{
    public class OmdbApi : IOmdbApi
    {
        private readonly IHttpClient _client;
        public OmdbApi(IHttpClient client) { _client = client; }

        private const string ApiUrl = "http://www.omdbapi.com/?";

        public async Task<SearchResults> Search(string name)
            => await Request<SearchResults>($"{ApiUrl}s={name}");

        public async Task<Movie> GetById(string imdbId)
            => await Request<Movie>($"{ApiUrl}i={imdbId}");

        private async Task<T> Request<T>(string url)
        {
            var response = await _client.Request(url);
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
