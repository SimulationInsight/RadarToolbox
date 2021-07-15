using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using SimulationInsight.ESMDataViewer.ViewModels;

namespace SimulationInsight.ESMDataViewer.Views
{
    public sealed partial class PulseDetailsPage : Page
    {
        public PulseDetailsViewModel ViewModel { get; }

        public PulseDetailsPage()
        {
            ViewModel = Ioc.Default.GetService<PulseDetailsViewModel>();
            InitializeComponent();
        }

        private void OnViewStateChanged(object sender, ListDetailsViewState e)
        {
            if (e == ListDetailsViewState.Both)
            {
                ViewModel.EnsureItemSelected();
            }
        }
    }
}
