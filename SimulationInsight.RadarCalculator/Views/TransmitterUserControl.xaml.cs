using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using SimulationInsight.RadarCalculator.Models;
using SimulationInsight.RadarCalculator.ViewModels;

namespace SimulationInsight.RadarCalculator.Views;

public sealed partial class TransmitterUserControl : UserControl
{
    public bool IsTransmitterPage { get; set; } = true;

    public TransmitterViewModelBase ViewModel
    {
        get;
    }

    public TransmitterUserControl()
    {
        //if (IsTransmitterPage)
        //{
            ViewModel = App.GetService<TransmitterViewModel>();
        //}
        //else
        //{
        //    ViewModel = App.GetService<WaveformViewModel>();
        //}

        InitializeComponent();
    }

    public void UpdateBindings()
    {
        DispatcherQueue.TryEnqueue(Bindings.Update);
    }
}
