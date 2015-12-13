using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Stockfighter.Helpers
{
    public class Client : IDisposable
    {
        private const string baseUrl = "https://api.stockfighter.io/ob/api/";
        private HttpClient client = new HttpClient();

        public async Task<T> Get<T>(string url)
        {
            var response = await client.GetAsync(Combine(baseUrl, url)).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(stringContent);
        }


        private string Combine(params string[] segments)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < segments.Length; i++)
            {
                if (i > 0) sb.Append('/');
                sb.Append(segments[i].Trim('/'));
            }

            return sb.ToString();
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
