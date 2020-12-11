using System.Diagnostics;
using System.Windows.Input;
using Todo.Helpers;
using Todo.Models;
using Todo.Views;
using Xamarin.Forms;

namespace Todo.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Fields
        public ICommand RegisterCommand { get; set; }

        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _email;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }


        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _confirmPassword;

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }
        #endregion

        #region Constructor
        public RegisterViewModel() => RegisterCommand = new Command(OnRegisterClicked);
        #endregion

        #region Methods
        private async void OnRegisterClicked(object obj)
        {
            IsBusy = true;

            try
            {
                var register = new Register
                {
                    Username = Username,
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword
                };

                if (await UserService.Register(register))
                {
                    await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
