using SimulationInsight.Core;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Radar;

public interface IRadar : IExecutableModel
{
    IRadarProfile RadarProfile
    {
        get; set;
    }

    IScanner Scanner
    {
        get; set;
    }

    void ProcessRadarProfileDemandMessage(RadarProfileDemandMessage radarProfileDemandMessage);

    void SendRadarProfileDemandMessage();

    void SendRadarProfileStatusMessage();
}