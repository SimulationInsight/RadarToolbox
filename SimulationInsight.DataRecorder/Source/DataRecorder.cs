using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public class DataRecorder : IDataRecorder
{
    public List<ISystemMessage> SystemMessages { get; set; }

    public List<ScanDataMessage> ScanDataMessages { get; set; }

    public DataRecorder()
    {
        SystemMessages = new List<ISystemMessage>();
        ScanDataMessages = new List<ScanDataMessage>();
    }
}