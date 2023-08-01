using System.Text;
using SimulationInsight.MathLibrary;

namespace SimulationInsight.SimdisInterface;

public class SimdisDataWriter
{
    public StringBuilder AsiStrings
    {
        get;
        set;
    }

    public SimdisDataWriter()
    {
        AsiStrings = new StringBuilder();
    }

    public void WriteLine(string s = "")
    {
        AsiStrings.AppendLine(s);
    }

    public void WriteScenarioHeader(LLA lla, string scenarioInfo)
    {
        WriteLine(@$"Version          24");
        WriteLine(@$"RefLLA           {lla.LatitudeDeg} {lla.LongitudeDeg} {lla.Altitude}");
        WriteLine(@$"CoordSystem      ""LLA""");
        WriteLine(@$"ScenarioInfo     ""{scenarioInfo}""");
        WriteLine(@$"Classification   ""Unclassified"" 0x8000FF00");
        WriteLine(@$"DegreeAngles     1");
        WriteLine(@$"VerticalDatum    ""WGS84""");
        WriteLine(@$"ReferenceTimeECI ""0.0""");
        WriteLine();
    }

    public void WritePlatformDataAll(int platformId, List<SimdisPlatformData> platformData, string platformName, string platformType, string platformIcon = "")
    {
        WritePlatformInitialisation(platformId, platformName, platformType, platformIcon);
        WritePlatformData(platformId, platformData);
    }

    public void WritePlatformInitialisation(int platformId, string platformName, string platformType, string platformIcon = "")
    {
        WriteLine(@$"PlatformID          {platformId}");
        WriteLine(@$"PlatformName        {platformId} ""{platformName}""");
        WriteLine(@$"PlatformType        {platformId} ""{platformType}""");
        WriteLine(@$"PlatformInterpolate {platformId} 1");
        WriteLine(@$"PlatformIcon        {platformId} ""{platformIcon}""");

        if (!string.IsNullOrEmpty(platformIcon))
        {
            WriteLine(@$"PlatformIcon        {platformId} ""{platformIcon}""");
        }

        WriteLine();
    }

    public void WritePlatformData(int platformId, List<SimdisPlatformData> platformData)
    {
        foreach (var p in platformData)
        {
            WritePlatformDataSingle(platformId, p);
        }

        WriteLine();
    }

    public void WritePlatformDataSingle(int platformId, SimdisPlatformData p)
    {
        WriteLine(@$"PlatformData {platformId} {p.Time} {p.LatitudeDeg} {p.LongitudeDeg} {p.Altitude} {p.HeadingAngleDeg} {p.PitchAngleDeg} {p.RollAngleDeg} {p.VelocityNorth} {p.VelocityEast} {p.VelocityDown}");
    }

    public void WriteAsiFile(string filename)
    {
        var s = AsiStrings.ToString();

        File.WriteAllText(filename, s);
    }
}