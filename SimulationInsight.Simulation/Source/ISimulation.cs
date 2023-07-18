using SimulationInsight.Core;
using SimulationInsight.DataRecorder;
using SimulationInsight.Radar;

namespace SimulationInsight.Simulation
{
    public interface ISimulation
    {
        ISimulationSettings SimulationSettings { get; set; }

        ISystemClock SystemClock { get; set; }

        IRadar Radar { get; set; }

        IDataRecorder DataRecorder { get; set; }
    }
}