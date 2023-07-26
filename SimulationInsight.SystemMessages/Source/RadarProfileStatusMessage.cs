namespace SimulationInsight.SystemMessages;

public class RadarProfileStatusMessage : SystemMessage
{
    public RadarProfileStatusMessage()
    {
        MessageType = SystemMessageType.RadarProfileStatus;
    }

    public RadarProfileStatus RadarProfileStatus
    {
        get; set;
    }
}