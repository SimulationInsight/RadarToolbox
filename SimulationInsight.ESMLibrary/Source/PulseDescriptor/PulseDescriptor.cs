using PhysicalInsight.MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace SimulationInsight.ESMLibrary
{
    public record PulseDescriptor
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

        public double SignalPower { get; init; }

        public double SignalPower_dB => SignalPower.ToDecibels();

        public double SignalToNoiseRatio { get; init; }

        public double SignalToNoiseRatio_dB => SignalToNoiseRatio.ToDecibels();

        public double AzimuthAngleDeg { get; init; }

        public double ElevationAngleDeg { get; init; }
    }
}
