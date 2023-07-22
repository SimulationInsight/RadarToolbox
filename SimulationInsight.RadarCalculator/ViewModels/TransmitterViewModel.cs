using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.RadarCalculator.Models;
using SimulationInsight.RadarCalculator.Views;

namespace SimulationInsight.RadarCalculator.ViewModels;

public partial class TransmitterViewModel : TransmitterViewModelBase
{
    public TransmitterViewModel(TransmitterModel transmitterModel)
    {
        TransmitterModel = transmitterModel;

        TransmitterModel.ViewModel = this;

        if (TransmitterModel.RfFrequency == 0)
        {
            TransmitterModel.RfFrequency = 9e9;
            TransmitterModel.TransmitPower = 500.0;
            TransmitterModel.AntennaGain_dB = 32.0;
        }

        IsShowHeaders = false;
    }
}
