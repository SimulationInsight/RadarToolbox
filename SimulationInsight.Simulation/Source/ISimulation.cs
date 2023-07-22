using SimulationInsight.Core;
using SimulationInsight.DataRecorder;
using SimulationInsight.Radar;

namespace SimulationInsight.Simulation;

public interface ISimulation : IExecutableModel
{
    ISimulationSettings SimulationSettings
    {
        get; set;
    }

    IDataRecorderSettings DataRecorderSettings
    {
        get; set;
    }

    ISystemClock SystemClock
    {
        get; set;
    }

    IRadar Radar
    {
        get; set;
    }

    IDataRecorder DataRecorder
    {
        get; set;
    }

    void Run();
}