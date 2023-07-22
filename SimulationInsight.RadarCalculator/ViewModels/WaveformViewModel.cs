using SimulationInsight.RadarCalculator.Models;

namespace SimulationInsight.RadarCalculator.ViewModels;

public partial class WaveformViewModel : TransmitterViewModelBase
{
    public WaveformModel WaveformModel
    {
        get; set;
    }

    public WaveformViewModel(WaveformModel waveformModel)
    {
        WaveformModel = waveformModel;

        WaveformModel.ViewModel = this;

        if (WaveformModel.RfFrequency == 0)
        {
            WaveformModel.RfFrequency = 9e9;
            WaveformModel.TransmitPower = 500.0;
            WaveformModel.AntennaGain_dB = 32.0;
        }

        IsShowHeaders = false;
    }
}