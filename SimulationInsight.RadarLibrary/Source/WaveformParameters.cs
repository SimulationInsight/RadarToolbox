using static SimulationInsight.MathLibrary.PhysicalConstants;
using static SimulationInsight.RadarFunctions.RadarFunctions;

namespace SimulationInsight.RadarLibrary;

public record WaveformParameters
{
    public string WaveformName
    {
        get;
        set;
    } = "Undefined";

    public double RfFrequency
    {
        get;
        set;
    }

    public double RfFrequency_kHz
    {
        get => RfFrequency / 1.0e3;
        set => RfFrequency = value * 1.0e3;
    }

    public double RfFrequency_MHz
    {
        get => RfFrequency / 1.0e6;
        set => RfFrequency = value * 1.0e6;
    }

    public double RfFrequency_GHz
    {
        get => RfFrequency / 1.0e9;
        set => RfFrequency = value * 1.0e9;
    }

    public double RfWavelength
    {
        get => SpeedOfLight / RfFrequency;
        set => RfFrequency = SpeedOfLight / value;
    }

    public double RfWavelength_cm
    {
        get => RfWavelength * 100.0;
        set => RfWavelength = value / 100.0;
    }

    public double RfWavelength_mm
    {
        get => RfWavelength * 1000.0;
        set => RfWavelength = value / 1000.0;
    }

    public double PulseWidth
    {
        get;
        set;
    }

    public double PulseWidth_us
    {
        get => PulseWidth * 1.0e6;
        set => PulseWidth = value * 1.0e-6;
    }

    public double PulseBandwidth
    {
        get;
        set;
    }

    public double PulseRepetitionFrequency
    {
        get;
        set;
    }

    public double PulseRepetitionInterval
    {
        get => 1.0 / PulseRepetitionFrequency;
        set => PulseRepetitionFrequency = 1.0 / value;
    }

    public int NumberOfPulses
    {
        get;
        set;
    }

    public double BurstTime => PulseRepetitionInterval * NumberOfPulses;

    public double DutyRatio => PulseWidth * PulseRepetitionFrequency;

    public double DutyRatioPercent => DutyRatio * 100.0;

    public double UncompressedPulseWidth => CalculateTwoWayRangeFromDelayTime(PulseWidth);

    public double CompressedPulseWidth => UncompressedPulseWidth / PulseCompressionRatio;

    public double PulseCompressionRatio => PulseWidth * PulseBandwidth;

    public double MaximumUnambiguousRange => CalculateMaximumUnambiguousRange(PulseRepetitionFrequency);

    public double MaximumUnambiguousRangeRate => CalculateMaximumUnambiguousRangeRate(RfFrequency, PulseRepetitionFrequency);
}