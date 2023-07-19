using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder
{
    public interface IDataRecorder
    {
        IDataRecorderSettings DataRecorderSettings { get; set; }

        List<ISystemMessage> SystemMessages { get; set; }

        List<ScanDataMessage> ScanDataMessages { get; set; }

        void WriteData();
    }
}