using SimulationInsight.Core;
using SimulationInsight.DataRecorder;
using SimulationInsight.Radar;

namespace SimulationInsight.Simulation;

public class Simulation : ISimulation
{
    public ISimulationSettings SimulationSettings { get; set; }

    public ISystemClock SystemClock { get; set; }

    public IRadar Radar { get; set; }

    public IDataRecorder DataRecorder { get; set; }

    public Simulation(ISimulationSettings simulationSettings, ISystemClock systemClock, IRadar radar, IDataRecorder dataRecorder)
    {
        SimulationSettings = simulationSettings;
        SystemClock = systemClock;
        Radar = radar;
        DataRecorder = dataRecorder;
    }

    public void Run()
    {
        Logger.Information("Running Simulation...");
        Logger.Information("");

        InitialiseClock();

        var time = SystemClock.CurrentTime;

        InitialiseSimulation(time);

        RunSimulation(time);

        FinaliseSimulation(time);

        Logger.Information("Simulation Finished.");
        Logger.Information("");
    }

    public void InitialiseClock()
    {
        SystemClock.DateTimeOrigin = SimulationSettings.SimulationStartDateTime;

        SystemClock.CurrentTime = SimulationSettings.StartTime;
    }

    public void InitialiseSimulation(double time)
    {
        Logger.Information("   Initialising Simulation...");

        Initialise(time);

        Logger.Information("   Finished...");
        Logger.Information("");
    }

    public void RunSimulation(double time)
    {
        Logger.Information("   Running Simulation...");

        while (time < SimulationSettings.EndTime)
        {
            Logger.Information($"      Time = {time:0000.000}s");

            Update(time);

            time += SimulationSettings.TimeStep;
        }

        Logger.Information("   Finished...");
        Logger.Information("");
    }

    public void FinaliseSimulation(double time)
    {
        Logger.Information("   Finalising Simulation...");

        Finalise(time);

        Logger.Information("   Finished...");
        Logger.Information("");
    }

    public void Initialise(double time)
    {
        Radar.Initialise(time);
    }

    public void Update(double time)
    {
        SystemClock.Update(time);
        Radar.Update(time);
    }

    public void Finalise(double time)
    {
        Radar.Finalise(time);
    }
}