using System.Collections.Generic;

namespace SimulationInsight.ESMData.Models
{
    public record ESMPulseDescriptorData
    {
        public List<ESMPulseDescriptor> PulseDescriptors { get; init; }

        public int NumberOfPulses => PulseDescriptors.Count;
    }
}