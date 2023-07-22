namespace SimulationInsight.DataRecorder;

public class DataRecorderSettings : IDataRecorderSettings
{
    public string SimulationName
    {
        get; set;
    }

    public string OutputFolderTopLevel
    {
        get; set;
    }

    public string OutputFolder => Path.Combine(OutputFolderTopLevel, SimulationName);
}