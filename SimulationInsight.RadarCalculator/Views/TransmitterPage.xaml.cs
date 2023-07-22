using Microsoft.UI.Xaml.Controls;

using SimulationInsight.RadarCalculator.ViewModels;
using Syncfusion.UI.Xaml.Core;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class TransmitterPage : PageBase
{
    public TransmitterViewModel ViewModel
    {
        get;
    }

    public TransmitterPage()
    {
        ViewModel = App.GetService<TransmitterViewModel>();

        ViewModel.Page = this;

        InitializeComponent();
    }

    public override void UpdateBindings()
    {
        Bindings.Update();

        var control = this.FindChild<FrequencyUserControl>();

        if (control is not null)
        {
            control.UpdateBindings();
        }
    }
}
