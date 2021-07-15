using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

using SimulationInsight.ESMDataViewer.Activation;
using SimulationInsight.ESMDataViewer.Contracts.Services;
using SimulationInsight.ESMDataViewer.Core.Contracts.Services;
using SimulationInsight.ESMDataViewer.Core.Services;
using SimulationInsight.ESMDataViewer.Helpers;
using SimulationInsight.ESMDataViewer.Models;
using SimulationInsight.ESMDataViewer.Services;
using SimulationInsight.ESMDataViewer.ViewModels;
using SimulationInsight.ESMDataViewer.Views;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace SimulationInsight.ESMDataViewer
{
    public partial class App : Application
    {
        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public App()
        {
            InitializeComponent();
            UnhandledException += App_UnhandledException;
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var activationService = Ioc.Default.GetService<IActivationService>();
            await activationService.ActivateAsync(args);
        }

        private System.IServiceProvider ConfigureServices()
        {
            // TODO WTS: Register your services, viewmodels and pages here
            var services = new ServiceCollection();

            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<IWebViewService, WebViewService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IESMDataService, ESMDataService>();

            // Views and ViewModels
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();
            services.AddTransient<OperationalViewModel>();
            services.AddTransient<OperationalPage>();
            services.AddTransient<TrackSummaryViewModel>();
            services.AddTransient<TrackSummaryPage>();
            services.AddTransient<TrackDetailsViewModel>();
            services.AddTransient<TrackDetailsPage>();
            services.AddTransient<TrackDataViewModel>();
            services.AddTransient<TrackDataPage>();
            services.AddTransient<PulseSummaryViewModel>();
            services.AddTransient<PulseSummaryPage>();
            services.AddTransient<PulseDetailsViewModel>();
            services.AddTransient<PulseDetailsPage>();
            services.AddTransient<PulseDataViewModel>();
            services.AddTransient<PulseDataPage>();
            services.AddTransient<ClassificationDatabaseViewModel>();
            services.AddTransient<ClassificationDatabasePage>();
            services.AddTransient<ESMDatabaseViewModel>();
            services.AddTransient<ESMDatabasePage>();
            services.AddTransient<WebViewViewModel>();
            services.AddTransient<WebViewPage>();
            services.AddTransient<ContentGridViewModel>();
            services.AddTransient<ContentGridPage>();
            services.AddTransient<ContentGridDetailViewModel>();
            services.AddTransient<ContentGridDetailPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            return services.BuildServiceProvider();
        }
    }
}
