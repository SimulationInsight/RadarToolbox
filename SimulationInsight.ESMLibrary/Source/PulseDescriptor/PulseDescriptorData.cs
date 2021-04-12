using System.Collections.Generic;

namespace SimulationInsight.ESMLibrary
{
    public record PulseDescriptorData
    {
        public List<PulseDescriptor> PulseDescriptors { get; init; }

        public int NumberOfPulses => PulseDescriptors.Count;
    }
}