using SimulationInsight.DataRecorder;

namespace SimulationInsight.SimdisInterface;

public interface ISimdisDataExporter
{
    IDataRecorder DataRecorder
    {
        get;
        set;
    }

    SimdisDataWriter SimdisDataWriter
    {
        get;
        set;
    }

    void WriteAsiData(string fileName);
}