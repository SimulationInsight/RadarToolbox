using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class EnvironmentPage : Page
{
    public EnvironmentViewModel ViewModel
    {
        get;
    }

    public EnvironmentPage()
    {
        ViewModel = App.GetService<EnvironmentViewModel>();
        InitializeComponent();
    }
}
