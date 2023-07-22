using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using SimulationInsight.Antenna;
using SimulationInsight.RadarCalculator.Activation;
using SimulationInsight.RadarCalculator.Contracts.Services;
using SimulationInsight.RadarCalculator.Core.Contracts.Services;
using SimulationInsight.RadarCalculator.Core.Services;
using SimulationInsight.RadarCalculator.Helpers;
using SimulationInsight.RadarCalculator.Models;
using SimulationInsight.RadarCalculator.Services;
using SimulationInsight.RadarCalculator.ViewModels;
using SimulationInsight.RadarCalculator.Views;
using SimulationInsight.RadarLibrary;

namespace SimulationInsight.RadarCalculator;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public static UIElement? AppTitlebar { get; set; }

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<ExportViewModel>();
            services.AddTransient<ExportPage>();
            services.AddTransient<ImportViewModel>();
            services.AddTransient<ImportPage>();
            services.AddTransient<LearnViewModel>();
            services.AddTransient<LearnPage>();
            services.AddTransient<TrackingViewModel>();
            services.AddTransient<TrackingPage>();
            services.AddTransient<SignalDetectionViewModel>();
            services.AddTransient<SignalDetectionPage>();
            services.AddTransient<SignalPowerViewModel>();
            services.AddTransient<SignalPowerPage>();
            services.AddTransient<TargetViewModel>();
            services.AddTransient<TargetPage>();
            services.AddTransient<EnvironmentViewModel>();
            services.AddTransient<EnvironmentPage>();
            services.AddTransient<ScannerViewModel>();
            services.AddTransient<ScannerPage>();
            services.AddTransient<AntennaViewModel>();
            services.AddTransient<AntennaPage>();
            services.AddTransient<WaveformViewModel>();
            services.AddTransient<WaveformPage>();
            services.AddTransient<TransmitterViewModel>();
            services.AddTransient<TransmitterPage>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Models:
            services.AddSingleton<TransmitterModel>();
            services.AddSingleton<TransmitterParameters>();
            services.AddSingleton<AntennaParameters>();
            services.AddSingleton<WaveformParameters>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
