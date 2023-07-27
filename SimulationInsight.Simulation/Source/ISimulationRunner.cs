namespace SimulationInsight.Simulation;

public interface ISimulationRunner
{
    ISimulationRunnerSettings SimulationRunnerSettings
    {
        get;
        set;
    }

    ISimulation Simulation
    {
        get;
        set;
    }

    void Run();
}