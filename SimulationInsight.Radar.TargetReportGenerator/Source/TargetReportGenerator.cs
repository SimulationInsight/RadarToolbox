using SimulationInsight.ScenarioGenerator;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Radar.TargetReportGenerator;

public class TargetReportGenerator : ITargetReportGenerator
{
    public List<TargetReport> TargetReports
    {
        get;
        set;
    }

    public IScenario Scenario
    {
        get;
        set;
    }

    public TargetReportGenerator(IScenario scenario)
    {
        Scenario = scenario;
    }

    public void GenerateTargetReports()
    {
    }

    public void Initialise(double time)
    {
    }

    public void Update(double time)
    {
    }

    public void Finalise(double time)
    {
    }
}