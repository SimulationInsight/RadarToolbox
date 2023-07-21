using System.Collections.Generic;
using static SimulationInsight.MathLibrary.PhysicalConstants;

namespace SimulationInsight.RadarFunctions;

public static class RadarFunctions
{
    public static double FrequencyToWavelength(double rfFrequency)
    {
        var rfWavelength = SpeedOfLight / rfFrequency;

        return rfWavelength;
    }

    public static double CalculateTwoWayRangeFromDelayTime(double time)
    {
        var range = SpeedOfLight * time / 2.0;

        return range;
    }

    public static double CalculateOneWayRangeFromDelayTime(double time)
    {
        var range = SpeedOfLight * time;

        return range;
    }

    public static double CalculateMaximumUnambiguousRange(double pulseRepetitionFrequency)
    {
        var maximumUnambiguousRange = SpeedOfLight / pulseRepetitionFrequency / 2.0;

        return maximumUnambiguousRange;
    }

    public static double CalculateMaximumUnambiguousRangeRate(double rfFrequency, double pulseRepetitionFrequency)
    {
        var rfWavelength = FrequencyToWavelength(rfFrequency);

        var maximumUnambiguousRangeRate = pulseRepetitionFrequency * rfWavelength / 2.0;

        return maximumUnambiguousRangeRate;
    }

    public static string GetIeeeRadarBand(double rfFrequency_GHz)
    {
        var ieeeBands = RadarConstants.IeeeBands;

        var ieeeBand = ieeeBands.Where(s => s.frequency_GHz > rfFrequency_GHz).FirstOrDefault().ieeeBand;

        ieeeBand ??= "Undefined";

        return ieeeBand;
    }

    public static string GetNatoRadarBand(double rfFrequency_GHz)
    {
        var natoBands = RadarConstants.NatoBands;

        var natoBand = natoBands.Where(s => s.frequency_GHz > rfFrequency_GHz).FirstOrDefault().natoBand;

        natoBand ??= "Undefined";

        return natoBand;
    }
}