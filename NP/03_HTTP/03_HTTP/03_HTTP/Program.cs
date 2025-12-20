using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace _03_HTTP
{
    internal class Program
    {
        static async Task Google()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://google.com");

                if (response.IsSuccessStatusCode)
                {
                    foreach (var item in response.Headers)
                    {
                        Console.WriteLine($"{item.Key} - {string.Join("", item.Value)}");
                    }

                    string html = await response.Content.ReadAsStringAsync();
                    File.WriteAllText("google.html", html);


                }
            }
        }

        static async Task DownloadImageAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(url);
                var ext = Path.GetExtension(url);
                File.WriteAllBytes("image" + ext, bytes);
            }
        }

        static async Task Main(string[] args)
        {
            // API
            string url = "https://thronesapi.com/api/v2/Characters";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var characters = await response.Content.ReadFromJsonAsync<List<CharacterModel>>();

                if(characters != null)
                {
                    //var first = characters[0];
                    //await DownloadImageAsync(first.imageUrl);

                    foreach (var ch in characters)
                    {
                        Console.WriteLine($"{ch.fullName} - {ch.family}");
                    }
                }
            }
        }
    }
}
