using System;
using Microsoft.Extensions.DependencyInjection;
using Todo.Helpers;
using Todo.Services.Interface;
using Todo.Views;
using Xamarin.Forms;

namespace Todo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var credentialService = Startup.ServiceProvider.GetService<ICrededntialService>();
            credentialService.ClearAuthToken();
            await Current.GoToAsync("//LoginPage");
        }
    }
}
