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
}