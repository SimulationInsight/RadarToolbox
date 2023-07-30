using SimulationInsight.Core;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Radar.TargetReportGenerator;

public interface ITargetReportGenerator : IExecutableModel
{
    List<TargetReport> TargetReports
    {
        get; set;
    }

    void GenerateTargetReports();
}