using static SimulationInsight.MathLibrary.PhysicalConstants;
using static SimulationInsight.RadarFunctions.RadarFunctions;

namespace SimulationInsight.RadarLibrary;

public record WaveformParameters
{
    public string WaveformName { get; set; } = "Undefined";

    public double RfFrequencyCentre { get; set; }

    public double RfWavelengthCentre { get => SpeedOfLight / RfFrequencyCentre; set => RfFrequencyCentre = SpeedOfLight / value; }

    public double PulseWidth { get; set; }

    public double PulseWidth_us { get => PulseWidth * 1.0e6; set => PulseWidth = value * 1.0e-6; }

    public double PulseBandwidth { get; set; }

    public double PulseRepetitionFrequency { get; set; }

    public double PulseRepetitionInterval { get => 1.0 / PulseRepetitionFrequency; set => PulseRepetitionFrequency = 1.0 / value; }

    public int NumberOfPulses { get; set; }

    public double BurstTime => PulseRepetitionInterval * NumberOfPulses;

    public double DutyRatio => PulseWidth * PulseRepetitionFrequency;

    public double DutyRatioPercent => DutyRatio * 100.0;

    public double UncompressedPulseWidth => CalculateTwoWayRangeFromDelayTime(PulseWidth);

    public double CompressedPulseWidth => UncompressedPulseWidth / PulseCompressionRatio;

    public double PulseCompressionRatio => PulseWidth * PulseBandwidth;

    public double MaximumUnambiguousRange => CalculateMaximumUnambiguousRange(PulseRepetitionFrequency);

    public double MaximumUnambiguousRangeRate => CalculateMaximumUnambiguousRangeRate(RfFrequencyCentre, PulseRepetitionFrequency);
}