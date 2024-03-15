using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    internal class HttpDataService
    {
        private readonly HttpClient client;

        public HttpDataService(string defaultBaseUrl = "")
        {
            client = new HttpClient();

            if (!string.IsNullOrEmpty(defaultBaseUrl)) client.BaseAddress = new Uri($"{defaultBaseUrl}/");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(T item, string uri = "")
        {
            if (item == null) throw new NullReferenceException();

            var byteContent = ToByteContent(item);

            return await client.PostAsync(uri, byteContent);
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(T item, string uri = "")
        {
            if (item == null) throw new NullReferenceException();

            var stringContent = ToJsonStringContent(item);

            return await client.PostAsync(uri, stringContent);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(T item, string uri = "")
        {
            if (item == null) throw new NullReferenceException();

            var byteContent = ToByteContent(item);

            var response = await client.PutAsync(uri, byteContent);

            return response;
        }

        public async Task<HttpResponseMessage> PutAsJsonAsync<T>(T item, string uri = "")
        {
            if (item == null) throw new NullReferenceException();

            var stringContent = ToJsonStringContent(item);

            var response = await client.PutAsync(uri, stringContent);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri = "")
        {
            var response = await client.DeleteAsync(uri);

            return response;
        }

        public void AddAuthorizationHeader(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = null;
                return;
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private ByteArrayContent ToByteContent(object obj)
        {
            var serializedItem = JsonConvert.SerializeObject(obj);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            return new ByteArrayContent(buffer);
        }

        private StringContent ToJsonStringContent(object obj)
        {
            var serializedItem = JsonConvert.SerializeObject(obj);
            return new StringContent(serializedItem, Encoding.UTF8, "application/json");
        }
    }
}
