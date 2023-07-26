using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public interface IDataRecorder
{
    IDataRecorderSettings DataRecorderSettings
    {
        get; set;
    }

    List<ISystemMessage> SystemMessages
    {
        get; set;
    }

    List<RadarProfileDemandMessage> RadarProfileDemandMessages
    {
        get; set;
    }

    List<RadarProfileStatusMessage> RadarProfileStatusMessages
    {
        get; set;
    }

    List<ScanControlDataMessage> ScanControlDataMessages
    {
        get; set;
    }

    List<ScanDataMessage> ScanDataMessages
    {
        get; set;
    }

    List<AzimuthChangePulseDataMessage> AzimuthChangePulseDataMessages
    {
        get; set;
    }

    void WriteData();
}