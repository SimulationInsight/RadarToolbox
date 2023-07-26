using SimulationInsight.RadarLibrary;

namespace SimulationInsight.Radar;

public interface IRadarProfile
{
    string ProfileName
    {
        get;
        set;
    }

    WaveformParameters WaveformParameters
    {
        get;
        set;
    }

    double AzimuthScanRate_RPM
    {
        get;
        set;
    }
}