namespace SimulationInsight.SystemMessages;

public class RadarProfileDemandMessage : SystemMessage
{
    public RadarProfileDemandMessage()
    {
        MessageType = SystemMessageType.RadarProfileDemand;
    }

    public RadarProfileDemand RadarProfileDemand
    {
        get; set;
    }
}