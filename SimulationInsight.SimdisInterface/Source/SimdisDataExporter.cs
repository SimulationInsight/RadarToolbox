using SimulationInsight.DataRecorder;

namespace SimulationInsight.SimdisInterface;

public class SimdisDataExporter : ISimdisDataExporter
{
    public IDataRecorder DataRecorder
    {
        get;
        set;
    }

    public SimdisDataWriter SimdisDataWriter
    {
        get;
        set;
    }

    public SimdisDataExporter(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
        SimdisDataWriter = new SimdisDataWriter();
    }

    public void WriteAsiData(string fileName)
    {
        WriteScenarioHeader();

        WriteAisData();

        WriteAsiFile(fileName);
    }

    public void WriteScenarioHeader()
    {
        var lla = DataRecorder.LLAOrigin.LLA;

        var scenarioInfo = "Scenario Info 1";

        SimdisDataWriter.WriteScenarioHeader(lla, scenarioInfo);
    }

    public void WriteAisData()
    {
        var startDateTime = new DateTime(2023, 07, 27, 10, 00, 00);

        foreach (var aisData in DataRecorder.AisDataList.AisDataPerSite)
        {
            var mmsi = aisData.Key;

            var platformName = DataRecorder.AisDataList.AisSites.Where(s => s.mmsi == mmsi).Select(s => s.name).First();
            var platformType = "ship";
            var platformIcon = "containership";

            var platformData = aisData.Select(s => new SimdisPlatformData()
            {
                Time = (s.TimeStamp - startDateTime).TotalSeconds,
                LatitudeDeg = s.Latitude,
                LongitudeDeg = s.Longitude,
                HeadingAngleDeg = s.Heading ?? 0,
            }).ToList();

            SimdisDataWriter.WritePlatformDataAll(mmsi, platformData, platformName, platformType, platformIcon);
        }
    }

    public void WriteAsiFile(string fileName)
    {
        SimdisDataWriter.WriteAsiFile(fileName);
    }
}