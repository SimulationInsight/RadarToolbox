using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using SimulationInsight.ESMDataViewer.ViewModels;

namespace SimulationInsight.ESMDataViewer.Views
{
    public sealed partial class PulseSummaryPage : Page
    {
        public PulseSummaryViewModel ViewModel { get; }

        public PulseSummaryPage()
        {
            ViewModel = Ioc.Default.GetService<PulseSummaryViewModel>();
            InitializeComponent();
        }
    }
}
