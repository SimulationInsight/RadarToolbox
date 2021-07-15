using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using SimulationInsight.ESMDataViewer.ViewModels;

namespace SimulationInsight.ESMDataViewer.Views
{
    // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on DataGridPage.xaml.
    // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
    public sealed partial class PulseDataPage : Page
    {
        public PulseDataViewModel ViewModel { get; }

        public PulseDataPage()
        {
            ViewModel = Ioc.Default.GetService<PulseDataViewModel>();
            InitializeComponent();
        }
    }
}
