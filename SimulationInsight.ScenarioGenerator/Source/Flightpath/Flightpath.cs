using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ScenarioGenerator
{
    public record Flightpath : IFlightpath
    {
        public FlightpathDescription FlightpathDescription { get; init; }

        public List<FlightpathData> FlightpathData { get; init; }

        public FlightpathData GetFlightpathData(double time)
        {
            var flightpathData = new FlightpathData();

            return flightpathData;
        }
    }
}
