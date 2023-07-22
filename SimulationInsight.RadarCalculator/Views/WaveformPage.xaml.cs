using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;
using Syncfusion.UI.Xaml.Core;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class WaveformPage : Page
{
    public WaveformViewModel ViewModel
    {
        get;
    }

    public WaveformPage()
    {
        ViewModel = App.GetService<WaveformViewModel>();

        ViewModel.WaveformPage = this;

        InitializeComponent();
    }

    public void UpdateBindings()
    {
        Bindings.Update();

        var control = this.FindChild<TransmitterUserControl>();

        control.UpdateBindings();
    }
}
