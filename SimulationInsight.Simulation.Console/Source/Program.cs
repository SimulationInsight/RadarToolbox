using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimulationInsight.Core;
using SimulationInsight.DataRecorder;
using SimulationInsight.MathLibrary;
using SimulationInsight.Radar;
using SimulationInsight.ScenarioGenerator;
using SimulationInsight.Tracker;
using Wolverine;

namespace SimulationInsight.Simulation;

public class Program
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="simulationSettingsFile"></param>
    /// <param name="scenarioSettingsFile"></param>
    /// <param name="isUseExampleFiles"></param>
    /// <param name="numberOfRuns"></param>
    /// <returns></returns>
    public static async Task Main(string simulationSettingsFile, string scenarioSettingsFile, bool isUseExampleFiles = false, int numberOfRuns = 1)
    {
        var h = Host.CreateDefaultBuilder();

        var simulationRunnerSettings = new SimulationRunnerSettings()
        {
            SimulationSettingsFile = simulationSettingsFile,
            ScenarioSettingsFile = scenarioSettingsFile,
            IsUseExampleFiles = isUseExampleFiles,
            NumberOfRuns = numberOfRuns
        };

        Worker.SimulationRunnerSettings = simulationRunnerSettings;

        h.UseWolverine(opts =>
        {
            opts.Services.AddHostedService<Worker>();

            opts.Services.AddSingleton(typeof(ISimulationRunnerSettings), typeof(SimulationRunnerSettings));
            opts.Services.AddSingleton(typeof(ISimulationRunner), typeof(SimulationRunner));
            opts.Services.AddSingleton(typeof(ISimulationSettings), typeof(SimulationSettings));
            opts.Services.AddSingleton(typeof(ISimulation), typeof(Simulation));
            opts.Services.AddSingleton(typeof(IScenarioSettings), typeof(ScenarioSettings));
            opts.Services.AddSingleton(typeof(IScenario), typeof(Scenario));
            opts.Services.AddSingleton(typeof(ILLAOrigin), typeof(LLAOrigin));
            opts.Services.AddSingleton(typeof(ISystemClock), typeof(SystemClock));
            opts.Services.AddSingleton(typeof(IRadar), typeof(Radar.Radar));
            opts.Services.AddSingleton(typeof(IRadarProfile), typeof(RadarProfile));
            opts.Services.AddSingleton(typeof(IScanner), typeof(Scanner));
            opts.Services.AddSingleton(typeof(ITargetReportGenerator), typeof(TargetReportGenerator));
            opts.Services.AddSingleton(typeof(ITrackManager), typeof(TrackManager));
            opts.Services.AddSingleton(typeof(ITrackManagerSettings), typeof(TrackManagerSettings));
            opts.Services.AddSingleton(typeof(IDataRecorderSettings), typeof(DataRecorderSettings));
            opts.Services.AddSingleton(typeof(IDataRecorder), typeof(DataRecorder.DataRecorder));
            opts.Discovery.IncludeAssembly(typeof(IDataRecorder).Assembly);
            opts.Discovery.IncludeAssembly(typeof(IRadar).Assembly);
            opts.Discovery.IncludeAssembly(typeof(ITrackManager).Assembly);
            opts.Discovery.IncludeAssembly(typeof(IScenario).Assembly);
            opts.Discovery.IncludeAssembly(typeof(Program).Assembly);
        });

        await h.StartAsync();
    }
}