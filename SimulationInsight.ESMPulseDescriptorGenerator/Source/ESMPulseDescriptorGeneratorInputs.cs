using SimulationInsight.ESMLibrary;
using SimulationInsight.MathLibrary;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public record ESMPulseDescriptorGeneratorInputs
    {
        public PulseDescriptorData PulseDescriptorData { get; init; }

        public double StartTime { get; init; }

        public double EndTime { get; init; }

        public Vector PulseWidth { get; init; }

        public Vector FrequencyCentre { get; init; }

        public Vector FrequencyBandwidth { get; init; }

        public Vector PulseRepetitionFrequency { get; init; }
    }
}