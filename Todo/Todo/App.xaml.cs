using Microsoft.Extensions.DependencyInjection;
using Todo.Extensions;
using Todo.Helpers;
using Todo.Services;
using Todo.Services.Interface;
using Todo.ViewModels;
using Xamarin.Forms;

namespace Todo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Startup.Init();
            MainPage = new AppShell();
            var credentialService = Startup.ServiceProvider.GetService<ICrededntialService>();
            var token = credentialService.GetAuthTokenAsync().GetAwaiter().GetResult();
            if (!token.HasContent())
            {
                Shell.Current.GoToAsync("//LoginPage").GetAwaiter().GetResult();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
