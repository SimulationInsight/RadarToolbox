using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ScenarioGenerator
{
    public record FlightpathDescription
    {
        public int FlightpathId { get; init; }

        public string FlightpathName { get; init; }
    }
}
