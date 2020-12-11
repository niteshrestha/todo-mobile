using System;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Todo.Helpers;
using Todo.Services;
using Todo.Services.Interface;
using Todo.ViewModels;
using Xamarin.Essentials;

namespace Todo
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("Todo.appsettings.json");

            var host = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                    c.AddJsonStream(stream);
                })
                .ConfigureServices((c, x) =>
                {
                    ConfigureServices(c, x);
                })
                .ConfigureLogging(l => l.AddConsole(o =>
                {
                    o.DisableColors = true;
                })).Build();

            ServiceProvider = host.Services;
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>(clientOption =>
            {
                clientOption.BaseAddress = new Uri(BackendPath.UserServiceURL);
            });
            services.AddHttpClient<IItemService, ItemService>(clientOption =>
             {
                 clientOption.BaseAddress = new Uri(BackendPath.ItemServiceURL);
             });

            services.AddSingleton<ICrededntialService, CredentialService>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<ItemsViewModel>();
            services.AddTransient<ItemDetailViewModel>();
            services.AddTransient<NewItemViewModel>();
        }
    }
}
