using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Tracker;

public class TargetReportList : ITargetReportList
{
    public List<TargetReport> TargetReports
    {
        get;
        set;
    }

    public int NumberOfTargetReports => TargetReports.Count;

    public TargetReportList()
    {
        TargetReports = new List<TargetReport>();
    }
}
