using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Stockfighter.Helpers
{
    public class Client : IDisposable
    {
        private const string authHeader = "X-Starfighter-Authorization";
        private HttpClient client = new HttpClient();
        private string apiKey;

        public Client() { }
        public Client(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<T> Get<T>(string baseUrl, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Combine(baseUrl, url));
            Debug.WriteLine($"GET {request.RequestUri}");

            AddAuthHeader(request);

            var response = await client.SendAsync(request).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(stringContent);
        }

        public async Task<T> Post<T>(string baseUrl, string url, object body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Combine(baseUrl, url));
            Debug.WriteLine($"POST {request.RequestUri}");

            AddAuthHeader(request);

            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(stringContent);
        }

        public async Task<T> Delete<T>(string baseUrl, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, Combine(baseUrl, url));
            Debug.WriteLine($"DELETE {request.RequestUri}");

            AddAuthHeader(request);

            var response = await client.SendAsync(request).ConfigureAwait(false);

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

        private void AddAuthHeader(HttpRequestMessage request)
        {
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                request.Headers.Add(authHeader, apiKey);
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
