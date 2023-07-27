namespace SimulationInsight.SystemMessages;

public class TargetReportMessage : SystemMessage
{
    public TargetReportMessage()
    {
        MessageType = SystemMessageType.ScanData;
    }

    public List<TargetReport> TargetReports
    {
        get; set;
    }
}