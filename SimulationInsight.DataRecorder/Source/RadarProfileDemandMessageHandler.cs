using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public class RadarProfileDemandMessageHandler
{
    public IDataRecorder DataRecorder
    {
        get; set;
    }

    public RadarProfileDemandMessageHandler(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
    }

    public void Handle(RadarProfileDemandMessage radarProfileDemandMessage)
    {
        DataRecorder.SystemMessages.Add(radarProfileDemandMessage);

        DataRecorder.RadarProfileDemandMessages.Add(radarProfileDemandMessage);
    }
}