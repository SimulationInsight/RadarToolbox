using System.Collections.Generic;

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