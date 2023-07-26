namespace SimulationInsight.SystemMessages;

public class ScanControlDataMessage : SystemMessage
{
    public ScanControlDataMessage()
    {
        MessageType = SystemMessageType.ScanData;
    }

    public ScanControlData ScanControlData
    {
        get; set;
    }
}