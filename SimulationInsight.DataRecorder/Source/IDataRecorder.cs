using SimulationInsight.Ais.Server;
using SimulationInsight.MathLibrary;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public interface IDataRecorder
{
    IDataRecorderSettings DataRecorderSettings
    {
        get; set;
    }

    public ILLAOrigin LLAOrigin
    {
        get;
        set;
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

    public IAisDataList AisDataList
    {
        get;
        set;
    }

    void WriteData();

    string GetFullFileName(string fileNamePart, string extension);
}