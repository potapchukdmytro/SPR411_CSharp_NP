using System.Net.Http.Json;

namespace _05_JSON_Patterns
{
    public class HttpConvertor
    {
        private HttpClient client;

        public HttpConvertor()
        {
            client = new HttpClient();
        }

        public async Task<T?> GetAsync<T>(string url)
        { 
            return await client.GetFromJsonAsync<T>(url);
        }
    }
}
