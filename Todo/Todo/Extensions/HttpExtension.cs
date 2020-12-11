using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Todo.Extensions
{
    public static class HttpExtension
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content) =>
            JsonSerializer.Deserialize<T>(await content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
    }
}
