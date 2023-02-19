using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Refit;
using EbookStore.Presentation.RefitClient;
using Microsoft.Extensions.Hosting;
using DIInWPF.StartupHelpers;
using EbookStore.Presentation.View.Pages;
using EbookStore.Presentation.ViewModel;

namespace EbookStore.Presentation;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }
    private static string baseUrl = "https://localhost:7186/api";

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddDependencyFactory<RegisterPage>();
                services.AddDependencyFactory<LoginPage>();
                services.AddDependencyFactory<HomePage>();
                services.AddDependencyFactory<BookCreatePage>();
                services.AddDependencyFactory<BookUpdatePage>();
                services.AddDependencyFactory<UserRegisterViewModel>();
                services.AddRefitClient<IUserClient>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
                services.AddRefitClient<IBookClient>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
                services.AddRefitClient<IGenreClient>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
        startupForm.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
