using SimulationInsight.Ais.Database;

namespace SimulationInsight.Ais.Server;

public interface IAisDataList
{
    List<AisData> AisData
    {
        get;
        set;
    }

    List<(int mmsi, string name)> AisSites
    {
        get;
        set;
    }

    List<IGrouping<int, AisData>> AisDataPerSite
    {
        get;
        set;
    }

    int NumberOfAisPoints
    {
        get;
    }

    int NumberOfAisSites
    {
        get;
    }

    void ProcessAisData();

    void GetAisSites();

    void GetAisDataPerSite();
}