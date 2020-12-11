using System.Diagnostics;
using Todo.Models;
using Todo.Views;
using Xamarin.Forms;

namespace Todo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Fields
        private bool ValidateLogin() => !string.IsNullOrWhiteSpace(_username)
                && !string.IsNullOrWhiteSpace(_password);

        public Command LoginCommand { get; }

        public Command RegisterCommand { get; set; }

        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked, ValidateLogin);
            RegisterCommand = new Command(OnRegisterClicked);
            PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }
        #endregion

        #region Methods
        private async void OnLoginClicked()
        {
            IsBusy = true;

            try
            {
                var login = new Login
                {
                    Username = Username,
                    Password = Password
                };
                if (await UserService.LoginAsync(login))
                {
                    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                    await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnRegisterClicked(object obj) => await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        #endregion
    }
}
