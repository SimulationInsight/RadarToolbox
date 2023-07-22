using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class TargetPage : Page
{
    public TargetViewModel ViewModel
    {
        get;
    }

    public TargetPage()
    {
        ViewModel = App.GetService<TargetViewModel>();
        InitializeComponent();
    }
}