using SimulationInsight.MathLibrary;

namespace SimulationInsight.RadarLibrary;

public record RadarDetectionModelOutputs
{
    public double SignalPower { get; set; }

    public double NoisePower { get; set; }

    public double SignalToNoiseRatio { get; set; }

    public double SignalPower_dB => SignalPower.PowerToDecibels();

    public double NoisePower_dB => NoisePower.PowerToDecibels();

    public double SignalPower_dBm => SignalPower_dB + 30.0;

    public double NoisePower_dBm => NoisePower_dB + 30.0;

    public double SignalToNoiseRatio_dB => SignalToNoiseRatio.PowerToDecibels();
}