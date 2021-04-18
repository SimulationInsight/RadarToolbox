using SimulationInsight.ScenarioGenerator;
using System.Collections.Generic;
using System.IO;

namespace SimulationInsight.SimdisLibrary
{
    public class SimdisExporter
    {
        public Scenario Scenario { get; set; }

        public string AsiFileName { get; set; }

        public List<string> AsiStrings { get; set; }

        public int PlatformIdOffset { get; set; }

        public void ExportAsiFile()
        {
            CreateAsiData();

            WriteAsiFile();
        }

        public void CreateAsiData()
        {
            AsiStrings = new List<string>();

            CreateScenarioHeader();
            CreatePlatformsAll();
        }

        public void CreateScenarioHeader()
        {
            var lla = Scenario.ScenarioSettings.LLAOrigin;

            var s = SimdisUtilities.CreateScenarioHeader(lla.LatitudeDeg, lla.LongitudeDeg, lla.Altitude);

            AsiStrings.AddRange(s);
        }

        public void CreatePlatformsAll()
        {
            foreach (var flightpath in Scenario.Flightpaths)
            {
                CreatePlatform(flightpath);
            }
        }

        public void CreatePlatform(Flightpath flightpath)
        {
            var fs = flightpath.FlightpathSettings;

            var platformId = fs.FlightpathId + PlatformIdOffset;

            var s = SimdisUtilities.CreatePlatformInitialisation(platformId, fs.FlightpathName, fs.PlatformType, fs.PlatformIcon);

            AsiStrings.AddRange(s);

            foreach (var flightpathData in flightpath.FlightpathData)
            {
                var p = CreatePlatformDataRow(platformId, flightpathData);

                AsiStrings.Add(p);
            }

            AsiStrings.Add("");
        }

        public static string CreatePlatformDataRow(int platformId, FlightpathData f)
        {
            var s = SimdisUtilities.CreatePlatformData(platformId, f.Time, f.LatitudeDeg, f.LongitudeDeg, f.Altitude,
                f.VelocityNorth, f.VelocityEast, f.VelocityDown, f.HeadingAngleDeg, f.PitchAngleDeg, f.BankAngleDeg);

            return s;
        }

        public void WriteAsiFile()
        {
            File.WriteAllLines(AsiFileName, AsiStrings);
        }
    }
}