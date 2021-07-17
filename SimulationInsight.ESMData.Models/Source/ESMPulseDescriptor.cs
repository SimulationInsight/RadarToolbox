using SimulationInsight.MathLibrary;
using static System.Math;

namespace SimulationInsight.ESMData.Models
{
    public record ESMPulseDescriptor
    {
        public int RadarId { get; init; }

        public int PulseId { get; init; }

        public double PulseTimeStart { get; init; }

        public double PulseTimeEnd { get; init; }

        public double PulseWidth { get; init; }

        public double PulseWidth_us => PulseWidth.ToMicroseconds();

        public double PulseModulationType { get; init; }

        public double FrequencyStart { get; init; }

        public double FrequencyEnd { get; init; }

        public double FrequencyCentre => (FrequencyStart + FrequencyEnd) / 2.0;

        public double FrequencyBandwidth => Abs(FrequencyStart - FrequencyEnd);

        public double FrequencyRampRate { get; init; }

        public double FrequencyStart_MHz => FrequencyStart / 1.0e6;

        public double FrequencyEnd_MHz => FrequencyEnd / 1.0e6;

        public double FrequencyCentre_MHz => FrequencyCentre / 1.0e6;

        public double FrequencyBandwidth_MHz => FrequencyBandwidth / 1.0e6;

        public double FrequencyRampRate_THz_s => FrequencyRampRate / 1.0e12;

        public double SignalAmplitude => Sqrt(SignalPower);

        public double SignalPower { get; init; }

        public double SignalPower_dB => SignalPower.ToDecibels();

        public double SignalPower_dBm => SignalPower_dB + 30.0;

        public double SignalToNoiseRatio { get; init; }

        public double SignalToNoiseRatio_dB => SignalToNoiseRatio.ToDecibels();

        public double AzimuthAngleDeg { get; init; }

        public double ElevationAngleDeg { get; init; }

        public IQSignal Signal { get; set; }
    }
}