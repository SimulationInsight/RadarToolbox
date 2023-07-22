using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.Contracts.Services;
using SimulationInsight.RadarCalculator.ViewModels;
using SimulationInsight.RadarCalculator.Views;

namespace SimulationInsight.RadarCalculator.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<MainViewModel, MainPage>();
        Configure<TransmitterViewModel, TransmitterPage>();
        Configure<WaveformViewModel, WaveformPage>();
        Configure<AntennaViewModel, AntennaPage>();
        Configure<ScannerViewModel, ScannerPage>();
        Configure<EnvironmentViewModel, EnvironmentPage>();
        Configure<TargetViewModel, TargetPage>();
        Configure<SignalPowerViewModel, SignalPowerPage>();
        Configure<SignalDetectionViewModel, SignalDetectionPage>();
        Configure<TrackingViewModel, TrackingPage>();
        Configure<ImportViewModel, ImportPage>();
        Configure<ExportViewModel, ExportPage>();
        Configure<LearnViewModel, LearnPage>();
        Configure<SettingsViewModel, SettingsPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.ContainsValue(type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}