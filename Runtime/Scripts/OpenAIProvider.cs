using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

public class OpenAIProvider
{
    static readonly HttpClient client = new HttpClient();

    public async Task<string> Ask(string prompt)
    {
        string key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        var body = @"{
          ""model"": ""gpt-4o-mini"",
          ""messages"": [
            {""role"": ""system"", ""content"": ""Reply ONLY in JSON""},
            {""role"": ""user"", ""content"": """ + prompt + @"""}
          ]
        }";

        var req = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        req.Headers.Add("Authorization", "Bearer " + key);
        req.Content = new StringContent(body, Encoding.UTF8, "application/json");

        var res = await client.SendAsync(req);
        return await res.Content.ReadAsStringAsync();
    }
}
