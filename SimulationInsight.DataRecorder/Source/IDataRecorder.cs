using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder
{
    public interface IDataRecorder
    {
        List<ISystemMessage> SystemMessages { get; set; }

        List<ScanDataMessage> ScanDataMessages { get; set; }
    }
}