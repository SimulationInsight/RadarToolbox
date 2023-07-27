using SimulationInsight.Core;

namespace SimulationInsight.Radar;

public interface ITargetReportGenerator : IExecutableModel
{
    List<TargetReport> TargetReports
    {
        get; set;
    }

    void GenerateTargetReports();
}