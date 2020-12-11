using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Helpers;
using Xamarin.Essentials;

namespace Todo.Services.Interface
{
    public class CredentialService : ICrededntialService
    {
        public async Task SetAuthTokenAsync(string token)
        {
            try
            {
                await SecureStorage.SetAsync(SettingKeys.AuthToken, token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetAuthTokenAsync()
        {
            string token;
            try
            {
                token = await SecureStorage.GetAsync(SettingKeys.AuthToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return token;
        }

        public void ClearAuthToken() => SecureStorage.RemoveAll();
    }
}
