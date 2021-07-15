using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using SimulationInsight.ESMDataViewer.ViewModels;

namespace SimulationInsight.ESMDataViewer.Views
{
    public sealed partial class TrackSummaryPage : Page
    {
        public TrackSummaryViewModel ViewModel { get; }

        public TrackSummaryPage()
        {
            ViewModel = Ioc.Default.GetService<TrackSummaryViewModel>();
            InitializeComponent();
        }
    }
}
