using SimulationInsight.Ais.Server;
using SimulationInsight.Core;
using SimulationInsight.DataRecorder;
using SimulationInsight.Radar;
using SimulationInsight.ScenarioGenerator;

namespace SimulationInsight.Simulation;

public interface ISimulation : IExecutableModel
{
    ISimulationSettings SimulationSettings
    {
        get; set;
    }

    IScenarioSettings ScenarioSettings
    {
        get; set;
    }

    IAisServer AisServer
    {
        get;
        set;
    }

    IDataRecorderSettings DataRecorderSettings
    {
        get; set;
    }

    IScenario Scenario
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