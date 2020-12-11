using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services.Interface
{
    public interface IUserService
    {
        Task<bool> LoginAsync(Login login);
        Task<bool> Register(Register register);
    }
}
