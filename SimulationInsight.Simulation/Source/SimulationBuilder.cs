using SimulationInsight.Radar;
using SimulationInsight.SystemMessages;

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

        simulation.DataRecorderSettings.SimulationName = simulation.SimulationSettings.SimulationName;
        simulation.DataRecorderSettings.OutputFolderTopLevel = @"C:\temp\RadarToolbox\Simulation";

        //todo: doesn't seem to automatically use the same settings object through DI. Need to understand and fix this.
        simulation.DataRecorder.DataRecorderSettings = simulation.DataRecorderSettings;

        simulation.Radar.RadarProfile.ProfileName = "Waveform_1";

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