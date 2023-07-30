using System;
using System.Collections.Generic;

namespace SimulationInsight.Ais.Database;

public interface IAisService
{
    List<int> GetMMSIs(DateTime startTime, DateTime endTime);

    List<int> GetMMSIs(DateTime startTime, DateTime endTime, double latitudeMinDeg, double latitudeMaxDeg, double longitudeMinDeg, double longitudeMaxDeg);

    List<AisData> GetAisData(DateTime startTime, DateTime endTime);

    List<AisData> GetAisData(DateTime startTime, DateTime endTime, double latitudeMinDeg, double latitudeMaxDeg, double longitudeMinDeg, double longitudeMaxDeg);

    List<AisData> GetAisData(int mmsi);

    List<AisData> GetAisData(int mmsi, DateTime startTime, DateTime endTime);

    List<AisData> GetAisData(int mmsi, DateTime startTime, DateTime endTime, double latitudeMinDeg, double latitudeMaxDeg, double longitudeMinDeg, double longitudeMaxDeg);
}