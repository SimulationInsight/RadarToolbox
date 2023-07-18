using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oakton;
using SimulationInsight.Core;
using SimulationInsight.DataRecorder;
using SimulationInsight.Radar;
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
            opts.Services.AddScoped(typeof(ISimulationSettings), typeof(SimulationSettings));
            opts.Services.AddScoped(typeof(ISimulation), typeof(Simulation));
            opts.Services.AddScoped(typeof(ISystemClock), typeof(SystemClock));
            opts.Services.AddScoped(typeof(IRadar), typeof(Radar.Radar));
            opts.Services.AddScoped(typeof(IScanner), typeof(Scanner));
            opts.Services.AddScoped(typeof(IDataRecorder), typeof(DataRecorder.DataRecorder));
        });

        await h.RunOaktonCommands(args);
    }
}