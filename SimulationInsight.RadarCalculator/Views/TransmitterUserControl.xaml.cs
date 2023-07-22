using Microsoft.UI.Xaml.Controls;
using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class TransmitterUserControl : UserControl
{
    public TransmitterViewModel ViewModel
    {
        get;
    }

    public TransmitterUserControl()
    {
        ViewModel = App.GetService<TransmitterViewModel>();

        InitializeComponent();
    }

    public void UpdateBindings()
    {
        Bindings.Update();
    }
}
