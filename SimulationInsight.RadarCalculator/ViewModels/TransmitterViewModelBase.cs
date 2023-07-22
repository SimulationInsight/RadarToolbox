using SimulationInsight.RadarCalculator.Models;

namespace SimulationInsight.RadarCalculator.ViewModels;

public partial class TransmitterViewModelBase : ViewModelBase
{
    public bool IsShowHeaders
    {
        get;
        set;
    }

    public TransmitterModel TransmitterModel
    {
        get; 
        set;
    }

    public string GetHeaderString(string header)
    {
        return IsShowHeaders ? header : "";
    }
}