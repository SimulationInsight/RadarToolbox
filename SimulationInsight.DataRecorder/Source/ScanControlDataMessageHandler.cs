using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public class ScanControlDataMessageHandler
{
    public IDataRecorder DataRecorder
    {
        get; set;
    }

    public ScanControlDataMessageHandler(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
    }

    public void Handle(ScanControlDataMessage scanControlDataMessage)
    {
        DataRecorder.SystemMessages.Add(scanControlDataMessage);

        DataRecorder.ScanControlDataMessages.Add(scanControlDataMessage);
    }
}