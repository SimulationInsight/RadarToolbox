using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class CommunityPage : Page
{
    public CommunityViewModel ViewModel
    {
        get;
    }

    public CommunityPage()
    {
        ViewModel = App.GetService<CommunityViewModel>();
        InitializeComponent();
    }
}