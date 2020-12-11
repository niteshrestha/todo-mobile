using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Todo.Extensions;
using Todo.Models;
using Todo.Services.Interface;

namespace Todo.Services
{
    public class ItemService : IItemService
    {
        #region Fields
        private readonly HttpClient _client;
        #endregion

        #region Constructor
        public ItemService(HttpClient client) =>
            _client = client;
        #endregion

        #region Methods
        public async Task<Item> CreateAsync(Item item)
        {
            var response = await _client.PostAsJsonAsync("", item);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsJsonAsync<Item>();
        }

        public async Task DeleteAsync(string id) =>
            await _client.DeleteAsync($"/{id}");

        public async Task<List<Item>> GetItemsAsync(bool showDone) =>
            await _client.GetFromJsonAsync<List<Item>>($"?showDone={showDone}");

        public async Task<Item> GetItemAsync(string id) =>
            await _client.GetFromJsonAsync<Item>($"/{id}");

        public async Task ItemDoneAsync(string id) =>
            await _client.PutAsync($"/{id}", null);
        #endregion
    }
}
