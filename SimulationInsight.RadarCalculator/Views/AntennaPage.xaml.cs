using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class AntennaPage : Page
{
    public AntennaViewModel ViewModel
    {
        get;
    }

    public AntennaPage()
    {
        ViewModel = App.GetService<AntennaViewModel>();
        InitializeComponent();
    }
}