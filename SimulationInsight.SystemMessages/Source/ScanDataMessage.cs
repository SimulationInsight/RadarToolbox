namespace SimulationInsight.SystemMessages;

public class ScanDataMessage : SystemMessage
{
    public ScanDataMessage()
    {
        MessageType = SystemMessageType.ScanData;
    }

    public ScanData ScanData { get; set; }
}