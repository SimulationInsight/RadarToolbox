namespace SimulationInsight.Ais.Database;

public class AisDataService : IAisDataService
{
    public AisDataService()
    {
    }

    public int GetMMSIFromName(string name)
    {
        using var db = new AisDataContext();

        var mmsi = db.AisData.Where(s => s.Name.Contains(name)).Select(s => s.MMSI).FirstOrDefault();

        return mmsi;
    }

    public List<int> GetMMSIs()
    {
        using var db = new AisDataContext();

        var mmsis = db.AisData.Select(s => s.MMSI).Distinct().OrderBy(s => s).ToList();

        return mmsis;
    }

    public List<int> GetMMSIs(DateTime startTime, DateTime endTime)
    {
        using var db = new AisDataContext();

        var mmsis = db.AisData.FilterByTime(startTime, endTime).Select(s => s.MMSI).Distinct().OrderBy(s => s).ToList();

        return mmsis;
    }

    public List<int> GetMMSIs(DateTime startTime, DateTime endTime, double latitudeMinDeg, double latitudeMaxDeg, double longitudeMinDeg, double longitudeMaxDeg)
    {
        using var db = new AisDataContext();

        var mmsis = db.AisData.FilterByTime(startTime, endTime).FilterByLatitudeLongitude(latitudeMinDeg, latitudeMaxDeg, longitudeMinDeg, longitudeMaxDeg).Select(s => s.MMSI).Distinct().OrderBy(s => s).ToList();

        return mmsis;
    }

    public List<AisData> GetAisData(DateTime startTime, DateTime endTime)
    {
        using var db = new AisDataContext();

        var aisData = db.AisData.FilterByTime(startTime, endTime).OrderByTime().ToList();

        return aisData;
    }

    public List<AisData> GetAisData(DateTime startTime, DateTime endTime, double latitudeMinDeg, double latitudeMaxDeg, double longitudeMinDeg, double longitudeMaxDeg)
    {
        using var db = new AisDataContext();

        var aisData = db.AisData.FilterByTime(startTime, endTime).FilterByLatitudeLongitude(latitudeMinDeg, latitudeMaxDeg, longitudeMinDeg, longitudeMaxDeg).OrderByTime().ToList();

        return aisData;
    }

    public List<AisData> GetAisData(int mmsi)
    {
        using var db = new AisDataContext();

        var aisData = db.AisData.FilterByMMSI(mmsi).OrderByTime().ToList();

        return aisData;
    }

    public List<AisData> GetAisData(int mmsi, DateTime startTime, DateTime endTime)
    {
        using var db = new AisDataContext();

        var aisData = db.AisData.FilterByMMSI(mmsi).FilterByTime(startTime, endTime).OrderByTime().ToList(); ;

        return aisData;
    }

    public List<AisData> GetAisData(int mmsi, DateTime startTime, DateTime endTime, double latitudeMinDeg, double latitudeMaxDeg, double longitudeMinDeg, double longitudeMaxDeg)
    {
        using var db = new AisDataContext();

        var aisData = db.AisData.FilterByMMSI(mmsi).FilterByTime(startTime, endTime).FilterByLatitudeLongitude(latitudeMinDeg, latitudeMaxDeg, longitudeMinDeg, longitudeMaxDeg).OrderByTime().ToList(); ;

        return aisData;
    }
}

public static class Filters
{
    public static IQueryable<AisData> FilterByMMSI(this IQueryable<AisData> query, int mmsi)
    {
        query = query.Where(s => s.MMSI == mmsi);

        return query;
    }

    public static IQueryable<AisData> FilterByTime(this IQueryable<AisData> query, DateTime startTime, DateTime endTime)
    {
        query = query.Where(s => s.TimeStamp >= startTime && s.TimeStamp <= endTime);

        return query;
    }

    public static IQueryable<AisData> FilterByLatitudeLongitude(this IQueryable<AisData> query, double latitudeMinDeg, double latitudeMaxDeg, double longitudeMinDeg, double longitudeMaxDeg)
    {
        query = query.Where(s => s.Latitude >= latitudeMinDeg && s.Latitude <= latitudeMaxDeg && s.Longitude >= longitudeMinDeg && s.Longitude <= longitudeMaxDeg);

        return query;
    }

    public static IQueryable<AisData> OrderByTime(this IQueryable<AisData> query)
    {
        query = query.OrderBy(s => s.TimeStamp);

        return query;
    }
}