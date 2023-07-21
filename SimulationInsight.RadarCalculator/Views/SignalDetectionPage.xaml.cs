using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class SignalDetectionPage : Page
{
    public SignalDetectionViewModel ViewModel
    {
        get;
    }

    public SignalDetectionPage()
    {
        ViewModel = App.GetService<SignalDetectionViewModel>();
        InitializeComponent();
    }
}
