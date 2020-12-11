using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Services.Interface
{
    public interface ICrededntialService
    {
        Task SetAuthTokenAsync(string token);
        Task<string> GetAuthTokenAsync();
        void ClearAuthToken();
    }
}
