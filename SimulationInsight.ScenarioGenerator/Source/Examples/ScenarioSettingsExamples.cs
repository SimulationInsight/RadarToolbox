using SimulationInsight.MathLibrary;
using System.Collections.Generic;

namespace SimulationInsight.ScenarioGenerator
{
    public static class ScenarioSettingsExamples
    {
        public static ScenarioSettings Example_1()
        {
            var lla = new LLA()
            {
                LatitudeDeg = 54.0,
                LongitudeDeg = 12.0,
                Altitude = 0.0
            };

            var flightpathSettings1 = new FlightpathSettings()
            {
                FlightpathId = 1,
                FlightpathName = "Ownship_XXX",
                PlatformType = "aircraft",
                PlatformIcon = "c-130_hercules",
                InitialPositionNorth = 0.0,
                InitialPositionEast = 0.0,
                InitialPositionDown = -5000.0,
                InitialVelocityNorth = 0.0,
                InitialVelocityEast = 0.0,
                InitialVelocityDown = 0.0
            };

            var flightpathSettings2 = new FlightpathSettings()
            {
                FlightpathId = 2,
                FlightpathName = "Target_001",
                PlatformType = "landsite",
                PlatformIcon = "sa-15_launcher_des",
                InitialPositionNorth = 30000.0,
                InitialPositionEast = 20000.0,
                InitialPositionDown = 0.0,
                InitialVelocityNorth = 0.0,
                InitialVelocityEast = 0.0,
                InitialVelocityDown = 0.0
            };

            var flightpathSettings3 = new FlightpathSettings()
            {
                FlightpathId = 3,
                FlightpathName = "Target_002",
                PlatformType = "landsite",
                PlatformIcon = "sa-15_launcher_des",
                InitialPositionNorth = -30000.0,
                InitialPositionEast = 30000.0,
                InitialPositionDown = 0.0,
                InitialVelocityNorth = 0.0,
                InitialVelocityEast = 0.0,
                InitialVelocityDown = 0.0
            };

            var flightpathSettings = new List<FlightpathSettings>()
            {
                flightpathSettings1,
                flightpathSettings2,
                flightpathSettings3
            };

            var s = new ScenarioSettings()
            {
                LLAOrigin = lla,
                FlightpathSettings = flightpathSettings
            };

            return s;
        }
    }
}