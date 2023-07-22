using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class ImportPage : Page
{
    public ImportViewModel ViewModel
    {
        get;
    }

    public ImportPage()
    {
        ViewModel = App.GetService<ImportViewModel>();
        InitializeComponent();
    }
}