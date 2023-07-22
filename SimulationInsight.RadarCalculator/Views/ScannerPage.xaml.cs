using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class ScannerPage : Page
{
    public ScannerViewModel ViewModel
    {
        get;
    }

    public ScannerPage()
    {
        ViewModel = App.GetService<ScannerViewModel>();
        InitializeComponent();
    }
}