using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class SignalPowerPage : Page
{
    public SignalPowerViewModel ViewModel
    {
        get;
    }

    public SignalPowerPage()
    {
        ViewModel = App.GetService<SignalPowerViewModel>();
        InitializeComponent();
    }
}