namespace SimulationInsight.Simulation;

public interface ISimulationRunnerSettings
{
    string SimulationSettingsFile
    {
        get;
        set;
    }

    string ScenarioSettingsFile
    {
        get;
        set;
    }

    bool IsUseExampleFiles
    {
        get;
        set;
    }

    int NumberOfRuns
    {
        get;
        set;
    }

    void DisplaySettings();
}