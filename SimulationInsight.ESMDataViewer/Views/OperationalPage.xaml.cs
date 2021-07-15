using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using SimulationInsight.ESMDataViewer.ViewModels;

namespace SimulationInsight.ESMDataViewer.Views
{
    public sealed partial class OperationalPage : Page
    {
        public OperationalViewModel ViewModel { get; }

        public OperationalPage()
        {
            ViewModel = Ioc.Default.GetService<OperationalViewModel>();
            InitializeComponent();
        }
    }
}
