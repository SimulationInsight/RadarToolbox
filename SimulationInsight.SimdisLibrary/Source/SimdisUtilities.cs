using System.Collections.Generic;

namespace SimulationInsight.SimdisLibrary
{
    public static class SimdisUtilities
    {
        public static List<string> CreateScenarioHeader(double latitudeDeg, double longitudeDeg, double altitude)
        {
            var s = new List<string>
            {
                @"Version          24",
                $"RefLLA           {latitudeDeg} {longitudeDeg} {altitude}",
                @"CoordSystem      ""LLA""",
                @"Classification   ""Unclassified"" 0x8000FF00",
                @"DegreeAngles     1",
                @"VerticalDatum    ""WGS84""",
                @"ReferenceTimeECI ""0.0""",
                ""
            };

            return s;
        }

        public static List<string> CreatePlatformInitialisation(int platformId, string platformName, string platformType, string platformIcon)
        {
            var s = new List<string>
            {
                $"PlatformID   {platformId}",
                $"PlatformName {platformId} {platformName}",
                @$"PlatformType {platformId} ""{platformType}""",
                @$"PlatformIcon {platformId} ""{platformIcon}""",
                ""
            };

            return s;
        }

        public static string CreatePlatformData(int platformId, double time,
            double latitudeDeg, double longitudeDeg, double altitude,
            double velocityNorth, double velocityEast, double velocityDown,
            double headingAngleDeg, double pitchAngleDeg, double bankAngleDeg)
        {
            var s = $"PlatformData {platformId} {time} " +
                $"{latitudeDeg} {longitudeDeg} {altitude} " +
                $"{headingAngleDeg} {pitchAngleDeg} {bankAngleDeg} " +
                $"{velocityNorth} {velocityEast} {velocityDown}";

            return s;
        }
    }
}