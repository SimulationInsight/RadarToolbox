using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wolverine;

namespace SimulationInsight.Simulation;

public class Worker : BackgroundService
{
    public static ISimulationRunnerSettings SimulationRunnerSettings
    {
        get;
        set;
    }

    public ILogger<Worker> Logger
    {
        get; 
        set;
    }

    public IMessageBus Bus
    {
        get; 
        set;
    }

    public ISimulationRunner SimulationRunner
    {
        get; 
        set;
    }

    public Worker(ILogger<Worker> logger, IMessageBus bus, ISimulationRunner simulationRunner)
    {
        Logger = logger;
        Bus = bus;
        SimulationRunner = simulationRunner;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        CreateLogger();

        SimulationRunner.SimulationRunnerSettings = SimulationRunnerSettings;

        SimulationRunner.Run();
    }

    private static void CreateLogger()
    {
        var logFileName = @"C:\temp\RadarToolbox\RadarDetectionModel\RadarDetectionModel.log";

        Core.Logger.Initialise(logFileName);
    }
}