﻿using SimulationInsight.RadarLibrary;

namespace SimulationInsight.Radar;

public class RadarProfile : IRadarProfile
{
    public string ProfileName
    {
        get;
        set;
    }

    public WaveformParameters WaveformParameters
    {
        get;
        set;
    }

    public double AzimuthScanRate_RPM
    {
        get;
        set;
    }
}