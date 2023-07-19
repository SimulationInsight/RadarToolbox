using Microsoft.Extensions.Logging;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public class ScanDataMessageHandler
{
    public IDataRecorder DataRecorder { get; set; }

    public ScanDataMessageHandler(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
    }

    public void Handle(ScanDataMessage scanDataMessage, ILogger<SystemMessageHandler> logger)
    {
        DataRecorder.SystemMessages.Add(scanDataMessage);

        DataRecorder.ScanDataMessages.Add(scanDataMessage);
    }
}