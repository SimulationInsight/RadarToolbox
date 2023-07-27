namespace SimulationInsight.Simulation;

public interface ISimulationRunner
{
    ISimulation Simulation
    {
        get;
        set;
    }
    ISimulationRunnerSettings SimulationRunnerSettings
    {
        get;
        set;
    }

    void Run();
}