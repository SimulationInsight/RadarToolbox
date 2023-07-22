using SimulationInsight.Core;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public class DataRecorder : IDataRecorder
{
    public IDataRecorderSettings DataRecorderSettings
    {
        get; set;
    }

    public List<ISystemMessage> SystemMessages
    {
        get; set;
    }

    public List<ScanDataMessage> ScanDataMessages
    {
        get; set;
    }

    public List<AzimuthChangePulseDataMessage> AzimuthChangePulseDataMessages
    {
        get; set;
    }

    public DataRecorder(IDataRecorderSettings dataRecorderSettings)
    {
        DataRecorderSettings = dataRecorderSettings;
        SystemMessages = new List<ISystemMessage>();
        ScanDataMessages = new List<ScanDataMessage>();
        AzimuthChangePulseDataMessages = new List<AzimuthChangePulseDataMessage>();
    }

    public void WriteData()
    {
        Initialise();

        SortMessages();

        WriteSystemMessages();
        WriteScanDataMessages();
        WriteAzimuthChangePulseDataMessages();
    }

    public void Initialise()
    {
        var path = DataRecorderSettings.OutputFolder;

        if (!Directory.Exists(path))
        {
            Logger.Information($"      Creating Output Directory...");
            Logger.Information($"         {path}");

            Directory.CreateDirectory(path);

            Logger.Information("      Finished.");
            Logger.Information("");
        }
    }

    public void SortMessages()
    {
        SystemMessages = SystemMessages.OrderBy(s => s.MessageTime).ThenBy(s => s.MessageType).ToList();

        ScanDataMessages = ScanDataMessages.OrderBy(s => s.MessageTime).ToList();

        AzimuthChangePulseDataMessages = AzimuthChangePulseDataMessages.OrderBy(s => s.MessageTime).ToList();
    }

    public void WriteSystemMessages()
    {
        var fileName = GetFullFileName("SystemMessages", ".csv");

        SystemMessages.WriteToCsvFile(fileName);
    }

    public void WriteScanDataMessages()
    {
        var fileName = GetFullFileName("ScanData", ".csv");

        ScanDataMessages.WriteToCsvFile(fileName);
    }

    public void WriteAzimuthChangePulseDataMessages()
    {
        var fileName = GetFullFileName("AzimuthChangePulseData", ".csv");

        AzimuthChangePulseDataMessages.WriteToCsvFile(fileName);
    }

    public string GetFullFileName(string fileNamePart, string extension)
    {
        var fileName = $"{DataRecorderSettings.SimulationName}_{fileNamePart}{extension}";

        var fileNameFull = Path.Combine(DataRecorderSettings.OutputFolder, fileName);

        return fileNameFull;
    }
}