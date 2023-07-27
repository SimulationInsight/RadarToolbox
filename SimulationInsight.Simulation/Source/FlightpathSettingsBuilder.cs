using SimulationInsight.ScenarioGenerator;

namespace SimulationInsight.Simulation;

public static class FlightpathSettingsBuilder
{
    public static void Example1(List<FlightpathSettings> fp)
    {
        var fp1 = new FlightpathSettings()
        {
            FlightpathId = 102,
            FlightpathName = "Flightpath_1",
            InitialPositionNorth = 10000.0,
            InitialPositionEast = 5000.0,
            InitialPositionDown = 0.0,
            InitialVelocityNorth = 10.0,
            InitialVelocityEast = 5.0,
            InitialVelocityDown = 0.0,
        };

        var fp2 = new FlightpathSettings()
        {
            FlightpathId = 101,
            FlightpathName = "Flightpath_2",
            InitialPositionNorth = 5000.0,
            InitialPositionEast = -8000.0,
            InitialPositionDown = 0.0,
            InitialVelocityNorth = -10.0,
            InitialVelocityEast = -20.0,
            InitialVelocityDown = 0.0,
        };

        fp.Clear();

        fp.AddRange(new[] { fp1, fp2 });
    }
}