namespace SimulationInsight.DataRecorder;

public interface IDataRecorderSettings
{
    string SimulationName
    {
        get; set;
    }

    string OutputFolderTopLevel
    {
        get; set;
    }

    string OutputFolder
    {
        get;
    }
}