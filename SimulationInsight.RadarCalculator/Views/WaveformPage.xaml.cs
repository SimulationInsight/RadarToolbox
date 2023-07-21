using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class WaveformPage : Page
{
    public WaveformViewModel ViewModel
    {
        get;
    }

    public WaveformPage()
    {
        ViewModel = App.GetService<WaveformViewModel>();
        InitializeComponent();
    }
}
