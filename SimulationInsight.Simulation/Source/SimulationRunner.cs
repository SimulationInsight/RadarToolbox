using System.ComponentModel.DataAnnotations;
using SimulationInsight.Core;
using SimulationInsight.DataRecorder;

namespace SimulationInsight.Simulation;

public class SimulationRunner : ISimulationRunner
{
    public ISimulationRunnerSettings SimulationRunnerSettings
    {
        get;
        set;
    }

    public ISimulation Simulation
    {
        get;
        set;
    }

    public SimulationRunner(ISimulationRunnerSettings simulationRunnerSettings, ISimulation simulation)
    {
        SimulationRunnerSettings = simulationRunnerSettings;
        Simulation = simulation;
    }

    public void Run()
    {
        SimulationRunnerSettings.DisplaySettings();

        ReadInputFiles();

        SimulationBuilder.Example1(Simulation);

        SetInputFileNames();

        WriteInputFiles();

        Simulation.Run();
    }

    public void ReadInputFiles()
    {
    }

    public void SetInputFileNames()
    {
        if (SimulationRunnerSettings.IsUseExampleFiles)
        {
            SimulationRunnerSettings.SimulationSettingsFile = GetInputFileName("SimulationSettings", ".json");

            SimulationRunnerSettings.ScenarioSettingsFile = GetInputFileName("ScenarioSettings", ".json");
        }
    }

    public void WriteInputFiles()
    {
        Logger.Information("Writing Settings Files...");

        WriteSimulationSettingsFile();

        WriteScenarioSettingsFile();

        Logger.Information("Finished.");
        Logger.Information("");
    }

    public void WriteSimulationSettingsFile()
    {
        var simulationSettingsFile = GetOutputFileName(SimulationRunnerSettings.SimulationSettingsFile);

        Simulation.SimulationSettings.WriteToJsonFile(simulationSettingsFile);
    }

    public void WriteScenarioSettingsFile()
    {
        var scenarioSettingsFile = GetOutputFileName(SimulationRunnerSettings.ScenarioSettingsFile);

        Simulation.ScenarioSettings.WriteToJsonFile(scenarioSettingsFile);
    }

    public string GetOutputFileName(string inputFilePath)
    {
        var outputFileName = Path.GetFileName(inputFilePath);

        var outputFilePath = Path.Combine(Simulation.DataRecorderSettings.OutputFolder, outputFileName);

        return outputFilePath;
    }

    public string GetInputFileName(string fileNamePart, string extension)
    {
        var fileName = $"{Simulation.DataRecorderSettings.SimulationName}_{fileNamePart}{extension}";

        return fileName;
    }
}
