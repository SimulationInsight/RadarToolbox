using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class ExportPage : Page
{
    public ExportViewModel ViewModel
    {
        get;
    }

    public ExportPage()
    {
        ViewModel = App.GetService<ExportViewModel>();
        InitializeComponent();
    }
}
