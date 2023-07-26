using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public class RadarProfileStatusMessageHandler
{
    public IDataRecorder DataRecorder
    {
        get; set;
    }

    public RadarProfileStatusMessageHandler(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
    }

    public void Handle(RadarProfileStatusMessage radarProfileStatusMessage)
    {
        DataRecorder.SystemMessages.Add(radarProfileStatusMessage);

        DataRecorder.RadarProfileStatusMessages.Add(radarProfileStatusMessage);
    }
}