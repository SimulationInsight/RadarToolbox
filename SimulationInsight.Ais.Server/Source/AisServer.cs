using SimulationInsight.Ais.Database;

namespace SimulationInsight.Ais.Server;

public class AisServer : IAisServer
{
    public IAisServerSettings AisServerSettings
    {
        get;
        set;
    }

    public IAisDataService AisDataService
    {
        get;
        set;
    }

    public IAisDataList AisDataList
    {
        get;
        set;
    }

    public AisServer(IAisServerSettings aisServerSettings, IAisDataService aisDataService, IAisDataList aisDataList)
    {
        AisServerSettings = aisServerSettings;
        AisDataService = aisDataService;
        AisDataList = aisDataList;
    }

    public void GetAisData()
    {
        var s = AisServerSettings;

        var aisData = AisDataService.GetAisData(s.DateTimeStart, s.DateTimeEnd, s.LatitudeMinDeg, s.LatitudeMaxDeg, s.LongitudeMinDeg, s.LongitudeMaxDeg);

        AisDataList.AisData = aisData;

        AisDataList.ProcessAisData();
    }
}