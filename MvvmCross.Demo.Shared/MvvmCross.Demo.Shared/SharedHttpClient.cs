using System;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmCross.Demo.Core;

namespace MvvmCross.Demo.Shared
{
    public class SharedHttpClient : IHttpClient
    {
        public async Task<string> Request(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

