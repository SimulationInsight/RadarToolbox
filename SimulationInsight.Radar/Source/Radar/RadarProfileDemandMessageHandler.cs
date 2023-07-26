using SimulationInsight.SystemMessages;

namespace SimulationInsight.Radar;

public class RadarProfileDemandMessageHandler
{
    public IRadar Radar
    {
        get; set;
    }

    public RadarProfileDemandMessageHandler(IRadar radar)
    {
        Radar = radar;
    }

    public void Handle(RadarProfileDemandMessage radarProfileDemandMessage)
    {
        Radar.ProcessRadarProfileDemandMessage(radarProfileDemandMessage);
    }
}