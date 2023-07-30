using SimulationInsight.SystemMessages;

namespace SimulationInsight.Tracker;

public interface ITargetReportList
{
    List<TargetReport> TargetReports
    {
        get;
        set;
    }

    int NumberOfTargetReports
    {
        get;
    }
}