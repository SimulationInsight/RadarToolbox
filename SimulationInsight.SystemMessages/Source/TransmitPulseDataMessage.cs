namespace SimulationInsight.SystemMessages;

public class TransmitPulseDataMessage : SystemMessage
{
    public TransmitPulseDataMessage()
    {
        MessageType = SystemMessageType.TransmitPulseData;
    }

    public TransmitPulseData TransmitPulseData
    {
        get; set;
    }
}