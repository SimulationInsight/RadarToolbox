using SimulationInsight.Ais.Database;

namespace SimulationInsight.Ais.Server;

public class AisDataList : IAisDataList
{
    public List<AisData> AisData
    {
        get;
        set;
    }

    public List<(int mmsi, string name)> AisSites
    {
        get;
        set;
    }

    public List<IGrouping<int, AisData>> AisDataPerSite
    {
        get;
        set;
    }

    public int NumberOfAisPoints => AisData.Count;

    public int NumberOfAisSites => AisSites.Count;

    public void ProcessAisData()
    {
        GetAisDataPerSite();
        GetAisSites();
    }

    public void GetAisDataPerSite()
    {
        AisDataPerSite = AisData.GroupBy(s => s.MMSI).OrderBy(s => s.Key).ToList();  
    }

    public void GetAisSites()
    {
        AisSites = AisDataPerSite.Select(s => s.Last()).Select(s => (s.MMSI, s.Name)).OrderBy(s => s.Name).ToList();
    }
}