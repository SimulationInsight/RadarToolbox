using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class TrackingPage : Page
{
    public TrackingViewModel ViewModel
    {
        get;
    }

    public TrackingPage()
    {
        ViewModel = App.GetService<TrackingViewModel>();
        InitializeComponent();
    }
}
