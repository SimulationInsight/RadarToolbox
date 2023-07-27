using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oakton;
using SimulationInsight.Core;
using SimulationInsight.DataRecorder;
using SimulationInsight.Radar;
using SimulationInsight.ScenarioGenerator;
using SimulationInsight.Tracker;
using Wolverine;

namespace SimulationInsight.Simulation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var h = Host.CreateDefaultBuilder(args);

        h.UseWolverine(opts =>
        {
            opts.Services.AddHostedService<Worker>();
            opts.Services.AddSingleton(typeof(IDataRecorderSettings), typeof(DataRecorderSettings));
            opts.Services.AddScoped(typeof(ISimulationSettings), typeof(SimulationSettings));
            opts.Services.AddScoped(typeof(ISimulation), typeof(Simulation));
            opts.Services.AddScoped(typeof(ISystemClock), typeof(SystemClock));
            opts.Services.AddScoped(typeof(IScenario), typeof(Scenario));
            opts.Services.AddScoped(typeof(IRadar), typeof(Radar.Radar));
            opts.Services.AddScoped(typeof(IRadarProfile), typeof(RadarProfile));
            opts.Services.AddScoped(typeof(IScanner), typeof(Scanner));
            opts.Services.AddScoped(typeof(ITargetReportGenerator), typeof(TargetReportGenerator));
            opts.Services.AddScoped(typeof(ITrackManager), typeof(TrackManager));
            opts.Services.AddScoped(typeof(ITrackManagerSettings), typeof(TrackManagerSettings));
            opts.Services.AddSingleton(typeof(IDataRecorder), typeof(DataRecorder.DataRecorder));
            opts.Discovery.IncludeAssembly(typeof(IDataRecorder).Assembly);
            opts.Discovery.IncludeAssembly(typeof(IRadar).Assembly);
            opts.Discovery.IncludeAssembly(typeof(ITrackManager).Assembly);
            opts.Discovery.IncludeAssembly(typeof(IScenario).Assembly);
        });

        await h.RunOaktonCommands(args);
    }
}