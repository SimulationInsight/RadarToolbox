using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}