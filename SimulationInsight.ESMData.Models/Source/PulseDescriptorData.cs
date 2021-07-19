using System.Collections.Generic;

namespace SimulationInsight.ESMData.Models
{
    public record PulseDescriptorData
    {
        public List<PulseDescriptorDTO> PulseDescriptors { get; init; }

        public int NumberOfPulses => PulseDescriptors.Count;
    }
}