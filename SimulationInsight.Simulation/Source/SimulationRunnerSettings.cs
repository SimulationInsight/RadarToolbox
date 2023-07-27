using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationInsight.Core;

namespace SimulationInsight.Simulation;

public class SimulationRunnerSettings : ISimulationRunnerSettings
{
    public string SimulationSettingsFile
    {
        get;
        set;
    }

    public string ScenarioSettingsFile
    {
        get;
        set;
    }

    public bool IsUseExampleFiles
    {
        get;
        set;
    }

    public int NumberOfRuns
    {
        get;
        set;
    }

    public void DisplaySettings()
    {
        Logger.Information("");
        Logger.Information("Displaying Simulation Runner Settings...");

        Logger.Information($"   SimulationSettingsFile = {SimulationSettingsFile}");
        Logger.Information($"   ScenarioSettingsFile   = {ScenarioSettingsFile}");
        Logger.Information($"   IsUseExampleFiles      = {IsUseExampleFiles}");
        Logger.Information($"   Number Of Runs         = {NumberOfRuns}");

        Logger.Information("Finished.");
        Logger.Information("");

    }
}
