using SimulationInsight.ScenarioGenerator;

namespace SimulationInsight.Radar;

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

    public IRadar Radar
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