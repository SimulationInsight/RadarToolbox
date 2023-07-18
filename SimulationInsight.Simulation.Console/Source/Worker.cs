using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wolverine;

namespace SimulationInsight.Simulation;

public class Worker : BackgroundService
{
    public ILogger<Worker> Logger { get; set; }
    public IMessageBus Bus { get; set; }
    public ISimulation Simulation { get; set; }

    public Worker(ILogger<Worker> logger, IMessageBus bus, ISimulation simulation)
    {
        Logger = logger;
        Bus = bus;
        Simulation = simulation;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        CreateLogger();

        SimulationBuilder.Example1(Simulation);

        Simulation.Run();
    }

    private static void CreateLogger()
    {
        var logFileName = @"C:\temp\RadarToolbox\RadarDetectionModel\RadarDetectionModel.log";

        Core.Logger.Initialise(logFileName);
    }
}