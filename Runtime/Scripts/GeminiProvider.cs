using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

public class GeminiProvider
{
    static readonly HttpClient client = new HttpClient();

    public async Task<string> Ask(string prompt)
    {
        string key = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
        string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key=" + key;

        var body = @"{
          ""contents"": [{
            ""parts"": [{""text"": ""Reply ONLY in JSON. " + prompt + @"""}]
          }]
        }";

        var res = await client.PostAsync(url,
            new StringContent(body, Encoding.UTF8, "application/json"));

        return await res.Content.ReadAsStringAsync();
    }
}
