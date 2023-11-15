using SimulationInsight.Ais.Server;
using SimulationInsight.MathLibrary;
using SimulationInsight.Radar;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Simulation;

public class SimulationBuilder
{
    public static void Example1(ISimulation simulation)
    {
        var startDateTime = new DateTime(2023, 07, 27, 10, 00, 00);
        var startDateOffset = 5.0; 
        var endTime = 1000.0;
        var timeStep = 0.1;

        simulation.SimulationSettings.SimulationName = "Example_1";
        simulation.SimulationSettings.SimulationDescription = "Example_1 Description";
        simulation.SimulationSettings.SimulationStartDateTime = startDateTime;
        simulation.SimulationSettings.StartTime = startDateOffset;
        simulation.SimulationSettings.EndTime = endTime;
        simulation.SimulationSettings.TimeStep = timeStep;

        var ss = simulation.ScenarioSettings;
        var fp = simulation.ScenarioSettings.FlightpathSettings;

        ss.LLAOrigin.LLA = new LLA()
        {
            LatitudeDeg = 56.0,
            LongitudeDeg = 10.0,
            Altitude = 0.0
        };

        FlightpathSettingsBuilder.Example1(fp);

        //
        simulation.AisServer.AisServerSettings = new AisServerSettings()
        {
            DateTimeStart = startDateTime,
            DateTimeEnd = startDateTime.AddSeconds(endTime),
            LatitudeMinDeg = 55.958753,
            LatitudeMaxDeg = 56.224782,
            LongitudeMinDeg = 10.105650,
            LongitudeMaxDeg = 11.594830
        };

        //
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