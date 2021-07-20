using SimulationInsight.MathLibrary;
using static System.Math;

namespace SimulationInsight.ESMData.Models
{
    public record IQSampleDTO
    {
        public int SampleNumber { get; init; }

        public double Time { get; init; }

        public double I { get; init; }

        public double Q { get; init; }

        public double Amplitude => Sqrt(Power);

        public double Power => I * I + Q * Q;

        public double Phase => Atan2(Q, I);

        public double PhaseUnwrapped { get; set; }

        public double PhaseDeg => Phase.ToDegrees();

        public double PhaseUnwrappedDeg => PhaseUnwrapped.ToDegrees();

        public double Power_dB => Power.ToDecibels();

        public double InstantaneousFrequency { get; set; }
    }
}