using SimulationInsight.Radar;
using SimulationInsight.SystemMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.Simulation;

public class SimulationBuilder
{
    public static void Example1(ISimulation simulation)
    {
        simulation.SimulationSettings.SimulationName = "Example_1";
        simulation.SimulationSettings.SimulationDescription = "Example_1 Description";
        simulation.SimulationSettings.SimulationStartDateTime = new DateTime(2023, 07, 16, 10, 15, 00);
        simulation.SimulationSettings.StartTime = 5.0;
        simulation.SimulationSettings.EndTime = 50.0;
        simulation.SimulationSettings.TimeStep = 0.1;

        simulation.Radar.Scanner.ScanData = new ScanData()
        {
            RadarId = 1,
            AzimuthAngleDeg = 10.0,
            AzimuthAngleRateDeg = 0.0,
        };

        simulation.Radar.Scanner.ScanPattern = new ScanPattern()
        {
            RadarId = 1,
            ScanPatternType = ScanPatternType.CircularScan,
            AzimuthScanRateDeg = 180.0
        };
    }
}
