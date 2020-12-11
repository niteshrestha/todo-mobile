using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services.Interface
{
    public interface IItemService
    {
        Task<Item> GetItemAsync(string id);
        Task<List<Item>> GetItemsAsync(bool showDone);

        Task<Item> CreateAsync(Item item);
        Task DeleteAsync(string id);
        Task ItemDoneAsync(string id);
    }
}
