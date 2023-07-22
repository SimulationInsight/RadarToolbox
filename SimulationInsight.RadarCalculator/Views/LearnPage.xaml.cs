using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class LearnPage : Page
{
    public LearnViewModel ViewModel
    {
        get;
    }

    public LearnPage()
    {
        ViewModel = App.GetService<LearnViewModel>();
        InitializeComponent();
    }
}