using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.Simulation;

public class SimulationSettings : ISimulationSettings
{
    public string SimulationName { get; set; }

    public string SimulationDescription { get; set; }

    public DateTime SimulationStartDateTime { get; set; }
}
