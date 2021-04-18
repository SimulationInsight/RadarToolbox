using SimulationInsight.MathLibrary;
using System.Collections.Generic;

namespace SimulationInsight.ScenarioGenerator
{
    public record Flightpath : IFlightpath
    {
        public LLA LLAOrigin { get; set; }

        public FlightpathSettings FlightpathSettings { get; set; }

        public List<FlightpathData> FlightpathData { get; set; }

        public Flightpath(LLA llaOrigin, FlightpathSettings flightpathSettings)
        {
            LLAOrigin = llaOrigin;
            FlightpathSettings = flightpathSettings;
        }

        public void GenerateFlightpath(double time1, double time2)
        {
            FlightpathData = new List<FlightpathData>();

            var f1 = GetFlightpathData(time1);
            var f2 = GetFlightpathData(time2);

            FlightpathData.Add(f1);
            FlightpathData.Add(f2);
        }

        public FlightpathData GetFlightpathData(double time)
        {
            var fp = FlightpathSettings;

            var flightpathData = new FlightpathData()
            {
                Time = time,
                LatitudeDeg = LLAOrigin.LatitudeDeg,
                LongitudeDeg = LLAOrigin.LongitudeDeg,
                Altitude = -fp.InitialPositionDown,
                PositionNorth = fp.InitialPositionNorth,
                PositionEast = fp.InitialPositionEast,
                PositionDown = fp.InitialPositionDown,
                VelocityNorth = fp.InitialVelocityNorth,
                VelocityEast = fp.InitialVelocityEast,
                VelocityDown = fp.InitialVelocityDown,
            };

            return flightpathData;
        }
    }
}