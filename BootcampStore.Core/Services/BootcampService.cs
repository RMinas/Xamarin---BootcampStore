using BootcampStore.Core.Exceptions;
using BootcampStore.Core.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BootcampStore.Core.Helpers.ReflectionHelper;

namespace BootcampStore.Core.Services
{
    public class BootcampService : IBootcampService
    {
        private readonly string _basePath = "http://bootcampservices.azurewebsites.net/api/";
        private HttpClient _httpClient;
        private HttpClient Ws => _httpClient ?? (_httpClient = CreateHttpClient());

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_basePath),
                Timeout = TimeSpan.FromSeconds(30)
            };

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task<T> GetAsync<T>(string requestUri, CancellationToken ct = default(CancellationToken)) where T : class, new()
        {
            var response = await Ws.GetAsync(requestUri, ct);
            var responseJson = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException(responseJson);
            }

            var obj = JsonConvert.DeserializeObject<T>(responseJson);

            return obj ?? GetDefault<T>();
        }

        public async Task PostAsync<T>(string requestUri, T content, CancellationToken ct = default(CancellationToken)) where T : class, new()
        {
            var serializedObject = JsonConvert.SerializeObject(content);
            HttpContent contentPost = new StringContent(serializedObject, System.Text.Encoding.UTF8, "application/json");

            var response = await Ws.PostAsync(requestUri, contentPost, ct);
            var responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException(responseJson);
            }
        }
    }
}
