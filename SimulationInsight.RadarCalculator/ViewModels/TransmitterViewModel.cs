using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.RadarCalculator.Models;
using SimulationInsight.RadarCalculator.Views;

namespace SimulationInsight.RadarCalculator.ViewModels;

public partial class TransmitterViewModel : ObservableRecipient
{
    private bool isShowHeaders;

    public bool IsShowHeaders 
    {
        get => isShowHeaders;
        set
        {
            isShowHeaders = value;
            UpdateBindings();
        }
    }

    public TransmitterPage TransmitterPage
    {
        get; set;
    }

    public TransmitterModel TransmitterModel
    {
        get; set;
    }

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

        isShowHeaders = false;
    }

    public string GetHeaderString(string header)
    {
        return IsShowHeaders ? header : "";
    }

    public void UpdateBindings()
    {
        if (TransmitterPage is not null)
        {
            TransmitterPage.UpdateBindings();
        }
    }
}
