using Microsoft.UI.Xaml.Controls;
using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class FrequencyUserControl : UserControl
{
    public TransmitterViewModel ViewModel
    {
        get;
        set;
    }

    public FrequencyUserControl()
    {
        ViewModel = App.GetService<TransmitterViewModel>();

        InitializeComponent();
    }

    public void UpdateBindings()
    {
        Bindings.Update();
    }
}