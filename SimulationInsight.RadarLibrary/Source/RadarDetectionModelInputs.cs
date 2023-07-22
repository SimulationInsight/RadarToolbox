using SimulationInsight.MathLibrary;

namespace SimulationInsight.RadarLibrary;

public record RadarDetectionModelInputs
{
    public RfSystemType RfSystemType
    {
        get; set;
    }

    public WaveformParameters WaveformParameters
    {
        get; set;
    }

    public double TransmitPeakPower
    {
        get; set;
    }

    public double TransmitGain
    {
        get; set;
    }

    public double TransmitGain_dB
    {
        get => TransmitGain.PowerToDecibels(); set => TransmitGain = value.DecibelsToPower();
    }

    public double ReceiveGain
    {
        get; set;
    }

    public double ReceiveGain_dB
    {
        get => ReceiveGain.PowerToDecibels(); set => ReceiveGain = value.DecibelsToPower();
    }

    public double ReceiverNoiseFigure
    {
        get; set;
    }

    public double ReceiverNoiseFigure_dB
    {
        get => ReceiverNoiseFigure.PowerToDecibels(); set => ReceiverNoiseFigure = value.DecibelsToPower();
    }

    public double SystemLosses
    {
        get; set;
    }

    public double SystemLosses_dB
    {
        get => SystemLosses.PowerToDecibels(); set => SystemLosses = value.DecibelsToPower();
    }

    public double TargetRange
    {
        get; set;
    }

    public double TargetRadarCrossSection
    {
        get; set;
    }

    public double TargetRadarCrossSection_dB
    {
        get => TargetRadarCrossSection.PowerToDecibels(); set => TargetRadarCrossSection = value.DecibelsToPower();
    }
}