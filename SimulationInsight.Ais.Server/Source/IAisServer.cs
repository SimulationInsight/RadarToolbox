using SimulationInsight.Ais.Database;

namespace SimulationInsight.Ais.Server;

public interface IAisServer
{
    IAisServerSettings AisServerSettings
    {
        get;
        set;
    }

    IAisDataService AisDataService
    {
        get;
        set;
    }

    IAisDataList AisDataList
    {
        get;
        set;
    }

    void GetAisData();
}