using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoorMansReddit.Models
{
    public class PoorMansRedditDAL
    {
        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.reddit.com");
            return client;
        }

        public async Task<RedditClass> GetRedditItems(string searchTerm)
        {
            var client = GetHttpClient();

            var request = await client.GetAsync($"/r/{searchTerm}/.json");
            var response = await request.Content.ReadAsAsync<RedditClass>(); //install-package Microsoft.AspNet.WebAPI.Client

            return response;
        }
    }
}
