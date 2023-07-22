using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;
using Syncfusion.UI.Xaml.Core;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class WaveformPage : PageBase
{
    public WaveformViewModel ViewModel
    {
        get;
    }

    public WaveformPage()
    {
        ViewModel = App.GetService<WaveformViewModel>();

        ViewModel.Page = this;

        InitializeComponent();
    }

    public override void UpdateBindings()
    {
        DispatcherQueue.TryEnqueue(Bindings.Update);

        var control = this.FindChild<TransmitterUserControl>();

        if (control is not null)
        {
            control.UpdateBindings();
        }
    }
}
