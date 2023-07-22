namespace SimulationInsight.SystemMessages;

public class AzimuthChangePulseDataMessage : SystemMessage
{
    public AzimuthChangePulseDataMessage()
    {
        MessageType = SystemMessageType.AzimuthChangePulse;
    }

    public AzimuthChangePulseData AzimuthChangePulseData
    {
        get; set;
    }
}