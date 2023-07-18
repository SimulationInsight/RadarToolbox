using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.Core;

public class SystemClock : ISystemClock
{
    public DateTime DateTimeOrigin { get; set; } = DateTime.Now;

    public DateTime CurrentDateTime => DateTimeOrigin.AddSeconds(CurrentTime);

    public double CurrentTime { get; set; }

    public double 
        TimeStep { get; set; }

    public void Initialise(double time)
    {
        CurrentTime = time;
    }

    public void Update()
    {
        CurrentTime += TimeStep;
    }
}
