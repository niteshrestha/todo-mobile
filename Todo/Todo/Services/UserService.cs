using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Todo.Extensions;
using Todo.Helpers;
using Todo.Models;
using Todo.Services.Interface;
using Xamarin.Forms;

namespace Todo.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly HttpClient _client;
        private readonly ICrededntialService _credentialService;
        #endregion

        #region Constructors
        public UserService(HttpClient client, ICrededntialService crededntialService)
        {
            _client = client;
            _credentialService = crededntialService;
        }
        #endregion

        #region Methods
        public async Task<bool> LoginAsync(Login login)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(BackendPath.Login, login);
                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadAsJsonAsync<LoginResponse>();
                    await _credentialService.SetAuthTokenAsync(loginResponse.Token);
                    return true;
                }
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid username or password.", "Ok");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Application.Current.MainPage.DisplayAlert("Oops!", "Somehow, Somewhere, Something went wrong.", "Ok");
                return false;
            }
        }

        public async Task<bool> Register(Register register)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(BackendPath.Register, register);
                if (response.IsSuccessStatusCode)
                {
                    var registerResponse = await response.Content.ReadAsJsonAsync<RegisterResponse>();
                    await _credentialService.SetAuthTokenAsync(registerResponse.Token);
                    return true;
                }
                await Application.Current.MainPage.DisplayAlert("Oops!", "Somehow, Somewhere, Something went wrong.", "Ok");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Application.Current.MainPage.DisplayAlert("Oops!", "Somehow, Somewhere, Something went wrong.", "Ok");
                return false;
            }
        }
        #endregion
    }
}
