using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class TransmitterPage : Page
{
    public TransmitterViewModel ViewModel
    {
        get;
    }

    public TransmitterPage()
    {
        ViewModel = App.GetService<TransmitterViewModel>();

        ViewModel.TransmitterPage = this;

        InitializeComponent();
    }

    public void UpdateBindings()
    {
        Bindings.Update();
    }
}
