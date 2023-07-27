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

        SimulationBuilder.Example1(Simulation);

        Simulation.Run();
    }
}
